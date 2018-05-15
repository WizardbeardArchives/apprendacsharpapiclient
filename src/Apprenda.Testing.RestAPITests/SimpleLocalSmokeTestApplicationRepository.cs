using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.Repositories;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Apprenda.Testing.RestAPITestTools.ValueItems.Implementation;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Models.DeveloperPortal;

namespace Apprenda.Testing.RestAPITests
{
    public enum AvailableSmokeTestApplications
    {
        HelloWorld,
        TimeCard,
        EchoAuthZ,
        TaskrPlans,
        TaskrPlansAuthorization,
        EnvyMTWithPlansDefined,
        NoAuth
    }

    /// <summary>
    /// Repository which looks for the items in the Archives folder of this project.  Also tracks if applicaitons need to be removed after use from the platform
    /// </summary>
    internal class SimpleLocalSmokeTestApplicationRepository : ISmokeTestApplicationRepository
    {
        private readonly ISmokeTestSettingsRepository _settingsFactory;

        private readonly ConcurrentDictionary<string, int> _numberOfTestsUsingApplicationCurrently;


        public SimpleLocalSmokeTestApplicationRepository(ISmokeTestSettingsRepository factory)
        {
            _settingsFactory = factory;

            _numberOfTestsUsingApplicationCurrently = new ConcurrentDictionary<string, int>();
        }


        public async Task<ISmokeTestApplication> GetSmokeTestApplication(string smokeTestApplicationName)
        {
            var settings = await _settingsFactory.GetSmokeTestSettings();
            var dir = settings.IntegrationTestResourcesDirectory;

            string fileName;
            bool reqEntitlement;

            var app = (AvailableSmokeTestApplications)Enum.Parse(typeof(AvailableSmokeTestApplications), smokeTestApplicationName, true);
            switch (app)
            {
                case AvailableSmokeTestApplications.HelloWorld:
                    fileName = "Hello World Archive.zip";
                    reqEntitlement = true;
                    break;
                case AvailableSmokeTestApplications.TimeCard:
                    fileName = "TimeCard Archive.zip";
                    reqEntitlement = false;
                    break;
                case AvailableSmokeTestApplications.EchoAuthZ:
                    fileName = "EchoAppWithAuthZandFeatures Archive.zip";
                    reqEntitlement = false;
                    break;
                case AvailableSmokeTestApplications.TaskrPlans:
                    fileName = "TaskrPlanCreation.zip";
                    reqEntitlement = true;
                    break;
                case AvailableSmokeTestApplications.TaskrPlansAuthorization:
                    fileName = "TaskrPlanCreationAuthorization.zip";
                    reqEntitlement = true;
                    break;
                case AvailableSmokeTestApplications.EnvyMTWithPlansDefined:
                    fileName = "EnvyMTwithPlansDefined.zip";
                    reqEntitlement = true;
                    break;
                case AvailableSmokeTestApplications.NoAuth:
                    fileName = "NoAuth.zip";
                    reqEntitlement = false;
                    break;
                default:
                    throw new ArgumentException($"No application for {app} is known");
            }

            var fullPath = dir + "\\" + fileName;

            var bytes = File.ReadAllBytes(fullPath);

            ISmokeTestApplication res = new SmokeTestApplication
            {
                SmokeTestApplicationName = smokeTestApplicationName,
                ArchiveContents = bytes,
                RequiresEntitlement = reqEntitlement
            };

            return res;
        }

        //todo keep track if any tests are using it

        public async Task<ISmokeTestApplication> GetSmokeTestOnPlatform(IApprendaTestSession session, string smokeTestApplicationName, string appAlias)
        {
            var baseSmokeTest = await GetSmokeTestApplication(smokeTestApplicationName);

            var createdWrapped = new CreatedSmokeTestApplication(baseSmokeTest, this, session) {AppAlias = appAlias};

            var existsToUs = _numberOfTestsUsingApplicationCurrently.ContainsKey(appAlias);

            //check if we need to wait for other apps to stop using the app (or any!)
            
            //does it exist?
            bool existsOnPlatform;
            try
            {
                var client = await session.GetClient();
                var get = await client.GetApplication(appAlias);
                existsOnPlatform = get != null;
                if (existsOnPlatform)
                {
                    createdWrapped.AppAlias = get.Alias;
                }
            }
            catch (Exception)
            {
                existsOnPlatform = false;
            }

            if (!existsOnPlatform)
            {
                if (existsToUs)
                {
                    //we have a problem!
                    throw new Exception("Error maintaining state of applicaiton instances!");
                }
                var client = await session.GetClient();
                await CreateAppOnPlatform(client, createdWrapped);
            }

            if (_numberOfTestsUsingApplicationCurrently.ContainsKey(appAlias))
            {
                _numberOfTestsUsingApplicationCurrently[appAlias] =
                    _numberOfTestsUsingApplicationCurrently[appAlias] + 1;
            }
            else
            {
                _numberOfTestsUsingApplicationCurrently[appAlias] = 1;
            }
            return createdWrapped;
        }

        private async Task<string> CreateAppOnPlatform(IApprendaDeveloperPortalApiClient client, ISmokeTestApplication smApp)
        {
            //create it!
            var app = new Application("")
            {
                Alias = smApp.AppAlias,
                Description = $"{smApp.SmokeTestApplicationName} created by Smoke Tests",
                Name = $"st_{smApp.AppAlias}",
            };

            var res = await client.PostApp(app);
            if (!res)
            {
                throw new Exception("Error while posting application");
            }

            //check it exists!
            var getRes = await client.GetApplication(app.Alias);


            //check adding the archive
            var archive = await GetSmokeTestApplication(smApp.SmokeTestApplicationName);

            var rc = await client.PatchVersion(getRes.Alias, getRes.CurrentVersion.Alias, true,
                archive.ArchiveContents);

            if (rc.Status != ReportCardStatus.Succeeded)
            {
                throw new Exception($"Patching app returned status of {rc.Status}");
            }
            return app.Alias;
        }

        public async Task MarkAsNoLongerUsedByTest(IApprendaTestSession session, ISmokeTestApplication smApplication)
        {
            var numberUsing = _numberOfTestsUsingApplicationCurrently.ContainsKey(smApplication.AppAlias)
                ? _numberOfTestsUsingApplicationCurrently[smApplication.AppAlias]
                : 0;
            //do we have instances using it?
            if (numberUsing <= 1)
            {
                var client = await session.GetClient();
                try
                {
                    var res = await client.DeleteApplication(smApplication.AppAlias);
                }
                catch (Exception)
                {
                    
                }
            }

            _numberOfTestsUsingApplicationCurrently[smApplication.AppAlias] = numberUsing - 1;
        }

        public bool IsAppCurrentlyBeingUsedByTests(string appAlias)
        {
            return _numberOfTestsUsingApplicationCurrently != null
                   && _numberOfTestsUsingApplicationCurrently.ContainsKey(appAlias)
                   && _numberOfTestsUsingApplicationCurrently[appAlias] > 0;
        }
    }
}
