using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models.DeveloperPortal;
using Application = ApprendaAPIClient.Models.DeveloperPortal.Application;
using Component = ApprendaAPIClient.Models.DeveloperPortal.Component;
using EnrichedComponentModel = ApprendaAPIClient.Models.DeveloperPortal.EnrichedComponentModel;
using Plan = ApprendaAPIClient.Models.DeveloperPortal.Plan;
using SubscribedTenant = ApprendaAPIClient.Models.DeveloperPortal.SubscribedTenant;
using Subscription = ApprendaAPIClient.Models.DeveloperPortal.Subscriptions.Subscription;
using SubscriptionRequest = ApprendaAPIClient.Models.DeveloperPortal.SubscriptionRequest;
using User = ApprendaAPIClient.Models.DeveloperPortal.User;
using Version = ApprendaAPIClient.Models.DeveloperPortal.Version;

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
            bool async = true);

        Task<bool> DemoteVersion(string appAlias, string versionAlias);

        Task<IEnumerable<Component>> GetComponents(string appAlias, string versionAlias);

        Task<Component> GetComponent(string appAlias, string versionAlias, string componentAlias);

        Task<Certificate> GetCertificatesForComponent(string appAlias, string versionAlias, string componentAlias);

        //  public HttpResponseMessage Post(string alias, string subAlias, string identifier, [FromUri] string action, [FromUri] int? count = null, [FromUri] int? minCount = null)
        Task<bool> SetInstanceCountForComponent(string appAlias, string versionAlias, string componentAlias,
            int? numInstances, int? minInstances);

        Task<bool> UpdateComponent(string appAlias, string versionAlias, string componentAlias,
            EnrichedComponentModel component);

        Task<EnvironmentVariableData> GetEnvironmentVariables(string appAlias, string versionAlias, string componentAlias);

        Task<bool> SetEnvironmentVariable(string appAlias, string versionAlias, string componentAlias, EnvironmentVariableData data);

        //new features for tenant works
        Task<IEnumerable<Plan>> GetPlans(string appAlias, string versionAlias);

        Task<Plan> GetPlan(string appAlias, string versionAlias, Guid planId);

        Task<IEnumerable<User>> GetUsersAuthZSubscribedTo(string appAlias, string versionAlias);

        Task<User> GetUserAuthZSubscribedTo(string appAlias, string versionAlias, string userId);
        Task<bool> RemoveAuthZUserFromApplication(string appAlias, string versionAlias, IEnumerable<string> userIds);

        Task CreateAuthZUserSubscription(string appAlias, string versionAlias, IEnumerable<string> userIds,
            string planName);

        Task<IEnumerable<UserGroup>> GetGroupsAuthZSubscribedTo(string appAlias, string versionAlias);
        Task<UserGroup> GetGroupAuthZSubscribedTo(string appAlias, string versionAlias, string identifier);

        Task CreateAuthZGroupSubscription(string appAlias, string versionAlias, IEnumerable<string> groupIds,
            string planName);

        Task<bool> RemoveAuthZGroupFromApplication(string appAlias, string currentVersionAlias, List<string> identifiers, string planName);

        Task<Subscription> CreateMultiTenantSubscription(string appAlias, string versionAlias, string tenantAlias, SubscriptionRequest request);

        Task<IEnumerable<Subscription>> GetSubscriptions(string appAlias, string versionAlias, string tenantAlias);
        Task<Subscription> GetSubscription(string appAlias, string versionAlias, string tenantAlias, string locator);
        Task<bool> DeleteSubscription(string appAlias, string versionAlias, string tenantAlias, string locator);

        Task<IEnumerable<SubscribedTenant>> GetSubscribedTenants(string appAlias, string versionAlias, string tenantAlias);

    }
}
