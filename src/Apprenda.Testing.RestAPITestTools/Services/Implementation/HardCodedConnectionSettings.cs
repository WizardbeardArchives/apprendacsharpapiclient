using System;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.Repositories;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient;

namespace Apprenda.Testing.RestAPITests
{
    /// <summary>
    /// Connection settings that are done through code.  Usually only used by developers for local testing
    /// </summary>
    internal class HardCodedConnectionSettings : ISmokeTestSettings
    {
        public string AppsUrl => "https://apps.apprenda.msterling10";
        public IUserLogin UserLogin { get; set; } = 
            new UserLogin {UserName = "gsterling@apprenda.com", Password = "password"};

        public TimeSpan TestRunPollTime => new TimeSpan(0, 0, 1);

        public IUserLogin AdminUserLogin { get; set; } =
            new UserLogin {UserName = "admin@apprenda.com", Password = "password"};

        public string IntegrationTestResourcesDirectory => "..\\..\\Archives";
        public string RepositoryServer => "";
        public string AdminTenantAlias => string.Empty;
        public string RootUrl => "https://apprenda.msterling10";
        public TimeSpan MaxPromotionWaitTime => new TimeSpan(0, 15, 0);
        public bool IsEUSEnvironment => EnvironmentFeaturesAvailable != null && EnvironmentFeaturesAvailable.IsExternalUserStore;
        public IEnvironmentInformation EnvironmentInformation { get; }
        public IEnvironmentFeaturesAvailable EnvironmentFeaturesAvailable => null;
    }

    internal class HardCodedEnvironmentInformation : IEnvironmentInformation
    {
        public bool IsEUS => true;
        public string EUSGroupName => "";
        public string EUSGroupId => "S-1-5-32-574";
    }

    public  class HardCodedConnectionSettingsFactory : ISmokeTestSettingsRepository
    {
        public IConnectionSettings GetConnectionSettings()
        {
            return new HardCodedConnectionSettings();
        }

        public Task<ISmokeTestSettings> GetSmokeTestSettings()
        {
            return Task.FromResult(new HardCodedConnectionSettings() as ISmokeTestSettings);
        }
    }
}
