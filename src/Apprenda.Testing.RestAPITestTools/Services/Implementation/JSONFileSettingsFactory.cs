using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITests;
using Apprenda.Testing.RestAPITestTools.Repositories;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient;
using ApprendaAPIClient.Services;
using Newtonsoft.Json;

namespace Apprenda.Testing.RestAPITestTools.Services.Implementation
{
    public class JsonFileSettingsFactory : ISmokeTestSettingsRepository
    {
        private readonly string _fileLocation;
        private readonly bool _saveIfNotPresent;
        private readonly ISmokeTestSettingsRepository _backupFactory;
        private readonly ITelemetryReportingService _logger;

        public JsonFileSettingsFactory(ITelemetryReportingService logger, string fileLocation="connectionSettings.json", bool saveHardCodedIfNotPresent = true, 
            ISmokeTestSettingsRepository backupFactory = null)
        {
            _logger = logger;
            _fileLocation = fileLocation;
            _saveIfNotPresent = saveHardCodedIfNotPresent;
            _backupFactory = backupFactory ?? new HardCodedConnectionSettingsFactory();
        }

        public IConnectionSettings GetConnectionSettings()
        {
            return GetSmokeTestSettings().Result;
        }

        public async Task<ISmokeTestSettings> GetSmokeTestSettings()
        {
            //does the file exist?
            if (File.Exists(_fileLocation))
            {
                await _logger.ReportInfo($"Loading settings from {_fileLocation}", new[] {"settings"});
                var task = Task.Run(() => File.ReadAllText(_fileLocation));

                var contents = await task;

                var deser = JsonConvert.DeserializeObject<SmokeTestConnectionStorage>(contents);

                if (deser == null)
                {
                    throw new SerializationException("Could not deserialize from " + _fileLocation);
                }

                return new SmokeTestConnections(deser);
            }

            await _logger.ReportInfo("Cannot load settings, retrieving from backup", new[] {"settings"});
            var settings = await _backupFactory.GetSmokeTestSettings();

            var formatted = new SmokeTestConnectionStorage(settings);
            if (_saveIfNotPresent)
            {
                await _logger.ReportInfo("Saving connection settings to " + _fileLocation, new []{"save", "settings"});
                await SaveSettings(formatted);
            }

            return new SmokeTestConnections(formatted);
        }

        private Task SaveSettings(SmokeTestConnectionStorage settings)
        {
            var write = JsonConvert.SerializeObject(settings);

            var writeTask = Task.Run(() => File.WriteAllText(_fileLocation, write));

            return writeTask;
        }

        public class UserLoginS : IUserLogin
        {
            public UserLoginS() { }

            public UserLoginS(IUserLogin source)
            {
                UserName = source.UserName;
                Password = source.Password;
            }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class SmokeTestConnections : ISmokeTestSettings
        {
            public SmokeTestConnections(SmokeTestConnectionStorage source)
            {
                AppsUrl = source.AppsUrl;
                UserLogin = new UserLogin {UserName = source.UserName, Password = source.UserPassword};
                MaxPromotionWaitTime = source.MaxPromotionWaitTime;
                TestRunPollTime = source.TestRunPollTime;
                AdminUserLogin = new UserLogin {UserName = source.AdminUserName, Password = source.AdminUserPassword};
                IntegrationTestResourcesDirectory = source.IntegrationTestResourcesDirectory;
                RepositoryServer = source.RepositoryServer;
                AdminTenantAlias = source.AdminTenantAlias;
                RootUrl = source.RootUrl;
                EnvironmentFeaturesAvailable = new EnvironmentFeaturesAvailableS
                {
                    IsExternalUserStore = source.IsExternalUserStore,
                    IsMultipleNodes = source.IsMultipleNodes
                };
                EnvironmentInformation = new EnvironmentInformationS
                {
                    IsEUS = source.IsExternalUserStore,
                    EUSGroupId = source.EUSGroupId,
                    EUSGroupName = source.EUSGroupName
                };
            }
            public string AppsUrl { get; set; }
            public IUserLogin UserLogin { get; set; }
            public TimeSpan MaxPromotionWaitTime { get; set; }
            public TimeSpan TestRunPollTime { get; set; }
            public IUserLogin AdminUserLogin { get; set; }
            public string IntegrationTestResourcesDirectory { get; set; }
            public string RepositoryServer { get; set; }
            public string AdminTenantAlias { get; set; }
            public string RootUrl { get; set; }
            public IEnvironmentFeaturesAvailable EnvironmentFeaturesAvailable { get; set; }
            public IEnvironmentInformation EnvironmentInformation { get; set; }
        }
        public class SmokeTestConnectionStorage
        {
            public SmokeTestConnectionStorage() { }

            public SmokeTestConnectionStorage(ISmokeTestSettings source)
            {
                AppsUrl = source.AppsUrl;
                UserName = source.UserLogin?.UserName;
                UserPassword = source.UserLogin?.Password;
                MaxPromotionWaitTime = source.MaxPromotionWaitTime;
                AdminTenantAlias = source.AdminTenantAlias;
                AdminUserName = source.AdminUserLogin?.UserName;
                AdminUserPassword = source.AdminUserLogin?.Password;
                IntegrationTestResourcesDirectory = source.IntegrationTestResourcesDirectory;
                RepositoryServer = source.RepositoryServer;
                AdminTenantAlias = source.AdminTenantAlias;
                RootUrl = source.RootUrl;

                IsExternalUserStore = source.EnvironmentFeaturesAvailable?.IsExternalUserStore ?? false;
                IsMultipleNodes = source.EnvironmentFeaturesAvailable?.IsMultipleNodes ?? false;
                EUSGroupId = source.EnvironmentInformation?.EUSGroupId;
                EUSGroupName = source.EnvironmentInformation?.EUSGroupName;
            }

            public string AppsUrl { get; set; }

            public string UserName { get; set; }
            public string UserPassword { get; set; }

            public TimeSpan MaxPromotionWaitTime { get; set; }
            public TimeSpan TestRunPollTime { get; set; }

            public string AdminUserName { get; set; }
            public string AdminUserPassword { get; set; }

            public string IntegrationTestResourcesDirectory { get; set; }
            public string RepositoryServer { get; set; }
            public string AdminTenantAlias { get; set; }
            public string RootUrl { get; set; }

            public bool IsExternalUserStore { get; set; }
            public bool IsMultipleNodes { get; set; }
            public string EUSGroupName { get; set; }
            public string EUSGroupId { get; set; }
        }

        public class EnvironmentFeaturesAvailableS : IEnvironmentFeaturesAvailable
        {
            public EnvironmentFeaturesAvailableS() { }

            public EnvironmentFeaturesAvailableS(IEnvironmentFeaturesAvailable source)
            {
                IsExternalUserStore = source.IsExternalUserStore;
                IsMultipleNodes = source.IsMultipleNodes;
            }
            public bool IsExternalUserStore { get; set; }
            public bool IsMultipleNodes { get; set; }
        }

        public class EnvironmentInformationS : IEnvironmentInformation
        {
            public bool IsEUS { get; set; }
            public string EUSGroupName { get; set; }
            public string EUSGroupId { get; set; }
        }
    }
}
