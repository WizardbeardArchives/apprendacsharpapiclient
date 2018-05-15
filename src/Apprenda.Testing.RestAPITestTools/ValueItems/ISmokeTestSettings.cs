using System;
using ApprendaAPIClient;

namespace Apprenda.Testing.RestAPITestTools.ValueItems
{
    public interface ISmokeTestSettings : IConnectionSettings
    {
        TimeSpan MaxPromotionWaitTime { get; }

        /// <summary>
        /// If tests aren't parallel, how long to test between polling to see if we can run
        /// </summary>
        TimeSpan TestRunPollTime { get; }

        IUserLogin AdminUserLogin { get; set; }

        /// <summary>
        /// Data directory for files to retrieve to be used by the test
        /// </summary>
        string IntegrationTestResourcesDirectory { get; }

        string RepositoryServer { get; }

        string AdminTenantAlias { get; }

        string RootUrl { get; }

        IEnvironmentFeaturesAvailable EnvironmentFeaturesAvailable { get; }

        IEnvironmentInformation EnvironmentInformation { get; }
    }
}
