using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;

namespace Apprenda.Testing.RestAPITestTools.Repositories
{
    public interface ISmokeTestApplicationRepository
    {
        Task<ISmokeTestApplication> GetSmokeTestApplication(string smokeTestApplicationName);

        Task<ISmokeTestApplication> GetSmokeTestOnPlatform(IApprendaTestSession session, string smokeTestApplicationName, string appAlias);

        /// <summary>
        /// Mark that our test is done with with this app, and possible destroy it if no longer needed
        /// </summary>
        /// <param name="session"></param>
        /// <param name="smApplication"></param>
        Task MarkAsNoLongerUsedByTest(IApprendaTestSession session, ISmokeTestApplication smApplication);


        /// <summary>
        /// Lets us know if tests are currently using an app
        /// </summary>
        /// <param name="appAlias"></param>
        /// <returns></returns>
        bool IsAppCurrentlyBeingUsedByTests(string appAlias);
    }
}
