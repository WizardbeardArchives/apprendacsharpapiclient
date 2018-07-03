using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Factories;
using ApprendaAPIClient.Services;

namespace Apprenda.Testing.RestAPITestTools.ValueItems.Implementation
{
    /// <summary>
    /// Holds authentication info, and exposes a client via it
    /// </summary>
    internal class ApprendaTestSession : IApprendaTestSession
    {
        private readonly IApprendaApiClientFactory _clientFactory;
        private IApprendaApiClient _currentApiClient;
        private readonly ITelemetryReportingService _reportingService;
        private readonly string _testName;
        private readonly IUserLogin _login;
        private string _sessionToken;

        public  static int NumberOfSessionsInUse { get; private set; }

        public ApprendaTestSession(IApprendaApiClientFactory clientFactory, ISmokeTestSettings connectionSettings, TestIsolationLevel isolationLevel,
            ITelemetryReportingService reportingService, string testName, IUserLogin loginToUse = null)
        {
            _clientFactory = clientFactory;
            ConnectionSettings = connectionSettings;
            _reportingService = reportingService;
            _testName = testName;
            _login = loginToUse ?? connectionSettings.UserLogin;
            TestIsolationLevel = isolationLevel;

            NumberOfSessionsInUse++;
        }

        public void Dispose()
        {
            try
            {
                NumberOfSessionsInUse--;
                _reportingService?.ReportInfo($"Ending test {_testName}", new List<string> { "testend", _testName });

                //logout via the helper
                if (!string.IsNullOrWhiteSpace(_sessionToken))
                {
                    _currentApiClient?.Logout(_sessionToken);
                }
            }
            catch (Exception e)
            {
                _reportingService?.ReportInfo($"Error while disconnecting from test {_testName}::{e.Message}",
                    new List<string> { "testend", _testName, "logoutfailure" });
            }
        }

        public async Task<IApprendaApiClient> GetClient()
        {
            if (_currentApiClient == null)
            {
                _currentApiClient = _reportingService == null 
                    ? _clientFactory.GetV1Client() 
                    : _clientFactory.GetV1Client(_reportingService);
            }

            if (string.IsNullOrEmpty(_sessionToken))
            {
                _sessionToken = await _currentApiClient.Login(_login.UserName, _login.Password);
            }

            return _currentApiClient;
        }

        public Task<IApprendaApiClient> GetClient(ApiPortals portal)
        {
            return GetClient();
        }

        public ISmokeTestSettings ConnectionSettings { get; }
        public TestIsolationLevel TestIsolationLevel { get; private set; }

        public string SessionToken => _sessionToken;
    }
}
