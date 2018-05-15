using System;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITests;
using Apprenda.Testing.RestAPITestTools.Repositories;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient;
using ApprendaAPIClient.Services;

namespace Apprenda.Testing.RestAPITestTools.Services.Implementation
{
    /*
    /// <summary>
    /// Uses gauntlet tokens to get our information about our platform
    /// </summary>
    public class GauntletConnectionSettingsFactory : ISmokeTestSettingsRepository
    {
        private readonly ITelemetryReportingService _reportingService;
        private readonly ISmokeTestSettingsRepository _backupRepo;
        public GauntletConnectionSettingsFactory(ITelemetryReportingService reportingService, ISmokeTestSettingsRepository backupRepo)
        {
            _reportingService = reportingService;
            _backupRepo = backupRepo;
        }
        private static ISmokeTestSettings _instance;

        public IConnectionSettings GetConnectionSettings()
        {
            return GetSmokeTestSettings().Result;
        }

        public async Task<ISmokeTestSettings> GetSmokeTestSettings()
        {
            try
            {
                if (_instance != null)
                {
                    return _instance;
                }

                var backup = await _backupRepo.GetSmokeTestSettings();


                var rootUrlHost = gauntletReader.GetValue("$SG$SaaSGridInstanceRootUrlHost$SG$");

                if (string.IsNullOrEmpty(rootUrlHost))
                {
                    throw new InvalidOperationException("Loaded tokens have no root URL set");
                }

                var appsUrl = "https://apps." + rootUrlHost;


                var userName = gauntletReader.GetValue("$TEST$ApprendaAdminUser$TEST$");
                var userPassword = gauntletReader.GetValue("$TEST$ApprendaAdminPassword$TEST$");

                var settings = new GauntletConnectionSettings(backup,
                    string.IsNullOrEmpty(rootUrlHost) ? backup.RootUrl : rootUrlHost,
                    string.IsNullOrEmpty(rootUrlHost) ? backup.AppsUrl : appsUrl,
                    string.IsNullOrEmpty(userName) ? backup.UserLogin.UserName : userName,
                    string.IsNullOrEmpty(userPassword) ? backup.UserLogin.UserName : userPassword,
                    backup.AdminUserLogin.UserName,
                    backup.AdminUserLogin.Password);

                _instance = settings;
                return settings;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo("Error loading settings from Gauntlet, attempting to load from local machine.  Error: " +e.Message,
                    new[] { "settings", "hard-coded bypass" });

                return await _backupRepo.GetSmokeTestSettings();
            }
        }

        public class GauntletConnectionSettings : ISmokeTestSettings
        {
            private readonly ISmokeTestSettings _hardCoded;
            private IUserLogin _adminLogin;

            public GauntletConnectionSettings(ISmokeTestSettings hardCoded, string rootUrl, string appUrl, string userLogin, string userPassword,
                string adminLogin, string adminPassword)
            {
                _hardCoded = hardCoded;
                RootUrl = rootUrl;
                AppsUrl = appUrl;
                UserLogin = new UserLogin {UserName = userLogin, Password = userPassword};
                _adminLogin = new UserLogin {UserName = adminLogin, Password = adminPassword};
            }

            public string AppsUrl { get; }

            public IUserLogin UserLogin { get; set; }

            public TimeSpan TestRunPollTime => _hardCoded.TestRunPollTime;

            IUserLogin ISmokeTestSettings.AdminUserLogin
            {
                get { return _adminLogin; }
                set { _adminLogin = value; }
            }


            string ISmokeTestSettings.RepositoryServer => _hardCoded.RepositoryServer;

            string ISmokeTestSettings.AdminTenantAlias => _hardCoded.AdminTenantAlias;
            public string RootUrl { get; }

            public IEnvironmentFeaturesAvailable EnvironmentFeaturesAvailable =>
                _hardCoded.EnvironmentFeaturesAvailable;

            string ISmokeTestSettings.IntegrationTestResourcesDirectory => _hardCoded.IntegrationTestResourcesDirectory;


            TimeSpan ISmokeTestSettings.MaxPromotionWaitTime => _hardCoded.MaxPromotionWaitTime;

            public IEnvironmentInformation EnvironmentInformation => _hardCoded.EnvironmentInformation;
        }
    }*/
}
