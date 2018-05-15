using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ExtensionMethods;
using Apprenda.Testing.RestAPITestTools.Repositories;
using Apprenda.Testing.RestAPITestTools.Repositories.Implementation;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Apprenda.Testing.RestAPITestTools.ValueItems.Implementation;
using ApprendaAPIClient;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Factories;
using ApprendaAPIClient.Models.DeveloperPortal;
using ApprendaAPIClient.Services;
using IO.Swagger.Model;

namespace Apprenda.Testing.RestAPITestTools
{
    /// <summary>
    /// Base class for any smoke test, that provides the items you need to do full integration tests with reporting
    /// </summary>
    public abstract class BaseSmokeTest
    {
        private readonly ISmokeTestSettingsRepository _connectionSettingsFactory;
        private readonly ISmokeTestApplicationRepository _smokeTestApplicationRepository;
        private readonly ITelemetryReportingService _reportingService;
        private readonly IApprendaApiClientFactory _apiClientFactory;
        private readonly IUserLoginRepository _userLoginRepository;

        protected BaseSmokeTest(ISmokeTestSettingsRepository connectionSettingsFactory,
            ISmokeTestApplicationRepository smokeTestApplicationRepository,
            ITelemetryReportingService reportingService,
            IUserLoginRepository userLoginRepository = null,
            IApprendaApiClientFactory apiClientFactory = null)
        {
            _connectionSettingsFactory = connectionSettingsFactory;
            _smokeTestApplicationRepository = smokeTestApplicationRepository;
            _reportingService = reportingService;
            _apiClientFactory = apiClientFactory ?? new ApprendaApiClientFactory(_connectionSettingsFactory);
            _userLoginRepository = userLoginRepository ?? new SingleUserLoginRepository(_connectionSettingsFactory);
        }


        protected async Task<IApprendaTestSession> StartSession(TestIsolationLevel isolationLevel = TestIsolationLevel.None, [CallerMemberName] string testName = "")
        {
            if (isolationLevel == TestIsolationLevel.CompletelyIsolated)
            {
                await WaitUntilNoOtherTestsAreRunnning();
            }

            var connectionProperties = await _connectionSettingsFactory.GetSmokeTestSettings();
            if (connectionProperties.UserLogin == null)
            {
                connectionProperties.UserLogin = _userLoginRepository.GetNextAvailableUserLogin();
            }
            var session = new ApprendaTestSession(_apiClientFactory, connectionProperties, isolationLevel, _reportingService, testName);

            //ping that we've started!
            _reportingService?.ReportInfo($"Starting test {testName}", new List<string> { "teststart", testName });

            return session;
        }

        protected async Task<IApprendaTestSession> StartAdminSession(TestIsolationLevel isolationLevel = TestIsolationLevel.None, [CallerMemberName] string testName = "")
        {
            if (isolationLevel == TestIsolationLevel.CompletelyIsolated)
            {
                await WaitUntilNoOtherTestsAreRunnning();
            }

            var connectionProperties = await _connectionSettingsFactory.GetSmokeTestSettings();
            if (connectionProperties.AdminUserLogin == null)
            {
                connectionProperties.AdminUserLogin = _userLoginRepository.GetAdminUserLogin();
            }
            var session = new ApprendaTestSession(_apiClientFactory, connectionProperties, isolationLevel, _reportingService, testName, connectionProperties.AdminUserLogin);

            //ping that we've started!
            _reportingService?.ReportInfo($"Starting test {testName} as admin", new List<string> { "teststart", testName });

            return session;
        }

        protected async Task<IApprendaTestSession> StartSession(string userName, string password, TestIsolationLevel isolationLevel = TestIsolationLevel.None, [CallerMemberName] string testName = "")
        {
            if (isolationLevel == TestIsolationLevel.CompletelyIsolated)
            {
                await WaitUntilNoOtherTestsAreRunnning();
            }

            var connectionProperties = await _connectionSettingsFactory.GetSmokeTestSettings();
            connectionProperties.UserLogin = new UserLogin
            {
                UserName = userName,
                Password = password
            };

            return new ApprendaTestSession(_apiClientFactory, connectionProperties, isolationLevel, _reportingService, testName);
        }


        protected Task<ISmokeTestApplication> CreateAppIfDoesNotExist(IApprendaTestSession session, string smokeTestname = "helloworld")
        {
            return CreateAppIfDoesNotExist(session, smokeTestname, smokeTestname);
        }

        protected async Task<ISmokeTestApplication> CreateAppIfDoesNotExist(IApprendaTestSession currentSession, string smokeTestName, string appAlias)
        {
            if (currentSession.TestIsolationLevel == TestIsolationLevel.IsolatedApplication)
            {
                await WaitForApplicationToBeFree(appAlias);
            }
            return await _smokeTestApplicationRepository.GetSmokeTestOnPlatform(currentSession, smokeTestName, appAlias);
        }


        protected async Task PromoteAppToSandbox(IApprendaTestSession currentSession, string appAlias)
        {
            var client = await currentSession.GetClient();

            var appOnPlatform = await client.GetApplication(appAlias);

            if (appOnPlatform == null)
            {
                throw new ArgumentException("Cannot find application " + appAlias);
            }

            var connectionSettings = _connectionSettingsFactory.GetSmokeTestSettings();
            if (appOnPlatform.IsInStage("definition"))
            {
                await client.PromoteVersion(appAlias, appOnPlatform.CurrentVersion.Alias,
                    ApplicationVersionStage.Sandbox);
            }

            await WaitForPromotionToFinish(appAlias, await connectionSettings, client);

        }

        protected async Task DemoteAppFromSandbox(IApprendaTestSession currentSession, string appAlias)
        {
            var client = await currentSession.GetClient();
            var appOnPlatform = await client.GetApplication(appAlias);

            if (appOnPlatform == null)
            {
                throw new ArgumentException("Cannot find application " + appAlias);
            }

            var connectionSettings = _connectionSettingsFactory.GetSmokeTestSettings();
            if (appOnPlatform.IsInStage("sandbox"))
            {
                await client.DemoteVersion(appAlias, appOnPlatform.CurrentVersion.Alias);
            }

            await WaitForPromotionToFinish(appAlias, await connectionSettings, client);
        }

        protected async Task PromoteAppToPublished(IApprendaTestSession currentSession, string appAlias)
        {
            await PromoteAppToSandbox(currentSession, appAlias);
            var client = await currentSession.GetClient();

            var appOnPlatform = await client.GetApplication(appAlias);


            if (appOnPlatform.IsInStage("sandbox"))
            {
                await client.PromoteVersion(appAlias, appOnPlatform.CurrentVersion.Alias,
                    ApplicationVersionStage.Published);
            }

            var connectionSettings = await _connectionSettingsFactory.GetSmokeTestSettings();
            var currentState = await WaitForPromotionToFinish(appAlias, connectionSettings, client);

            if (currentState.IsCurrentlyPromoting())
            {
                throw new Exception("Timed out while waiting for promotion!");
            }
        }

        private async Task<EnrichedApplication> WaitForPromotionToFinish(string appAlias, ISmokeTestSettings connectionSettings, IApprendaDeveloperPortalApiClient client)
        {
            var maxWait = connectionSettings.MaxPromotionWaitTime;
            var startTIme = DateTime.UtcNow;

            var currentState = await client.GetApplication(appAlias);

            while (DateTime.UtcNow - startTIme < maxWait)
            {
                try
                {
                    var isPromoting = currentState.IsCurrentlyPromoting();
                    if (!isPromoting)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    _reportingService?.ReportInfo("Waiting for promotion: " + e.Message,
                        new List<string> {"promotion", "debug", "exception"});
                }
                Thread.Sleep(new TimeSpan(0, 0, 15));
                currentState = await client.GetApplication(appAlias);
            }
            return currentState;
        }

        protected async Task DeleteAppIfExists(string appAlias)
        {
            var client = GetClient();

            try
            {
                await client.DeleteApplication(appAlias);
            }
            catch (Exception e)
            {
                _reportingService?.ReportInfo("Error while deleting: " + e.Message, new List<string> {"delete", "exception"});
            }
        }

        protected Task<ISmokeTestApplication> GetArchiveForSmokeTestApplication(string name)
        {
            return _smokeTestApplicationRepository.GetSmokeTestApplication(name);
        }

        private IApprendaApiClient GetClient()
        {
            var client = _reportingService == null
                ? _apiClientFactory.GetV1Client()
                : _apiClientFactory.GetV1Client(_reportingService);
            return client;
        }

        private async Task WaitForApplicationToBeFree(string appAlias)
        {
            var settings = await _connectionSettingsFactory.GetSmokeTestSettings();
            while (_smokeTestApplicationRepository.IsAppCurrentlyBeingUsedByTests(appAlias))
            {
                await Task.Delay(settings.TestRunPollTime);
            }
        }

        private async Task WaitUntilNoOtherTestsAreRunnning()
        {
            var settings = await _connectionSettingsFactory.GetSmokeTestSettings();
            while (ApprendaTestSession.NumberOfSessionsInUse > 0)
            {
                await Task.Delay(settings.TestRunPollTime);
            }
        }
    }
}
