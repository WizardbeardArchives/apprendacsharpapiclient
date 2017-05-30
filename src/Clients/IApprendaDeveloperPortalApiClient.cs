using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.DeveloperPortal;
using IO.Swagger.Model;
using Application = ApprendaAPIClient.Models.DeveloperPortal.Application;
using Plan = ApprendaAPIClient.Models.DeveloperPortal.Plan;
using User = ApprendaAPIClient.Models.DeveloperPortal.User;
using Version = IO.Swagger.Model.Version;

namespace ApprendaAPIClient.Clients
{
    public interface IApprendaDeveloperPortalApiClient
    {
        Task<IEnumerable<Application>> GetApplications();

        Task<EnrichedApplication> GetApplication(string appAlias);

        Task<bool> PostApp(Application app);

        Task<bool> DeleteApplication(string appAlias);

        Task<IEnumerable<Version>> GetVersionsForApplication(string appAlias);

        Task<EnrichedVersion> GetVersion(string appAlias, string versionAlias);

        Task<PublishReportCardDTO> PatchVersion(string appAlias, string versionAlias, bool constructive,
            byte[] file,
            string newVersionAlias = null, string newVersionName = null,
            string useScalingSettingsFrom = null, bool async = false);

        Task<bool> PromoteVersion(string appAlias, string versionAlias, 
            ApplicationVersionStage desiredStage,
            bool waitForMinInstanceCount = false,
            bool inheritPublishedScalingSettings = false,
            bool async= true);

        Task<IEnumerable<Models.DeveloperPortal.Component>> GetComponents(string appAlias, string versionAlias);

        Task<EnvironmentVariableData> GetEnvironmentVariables(string appAlias, string versionAlias, string componentAlias);

        Task<bool> SetEnvironmentVariable(string appAlias, string versionAlias, string componentAlias, EnvironmentVariableData data);

        //new features for tenant works
        Task<IEnumerable<Plan>> GetPlans(string appAlias, string versionAlias);

        Task<Plan> GetPlan(string appAlias, string versionAlias, string planId);

        Task<IEnumerable<User>> GetUsers(string appAlias, string versionAlias);

        Task<User> GetUser(string appAlias, string versionAlias, string userId);
    }
}
