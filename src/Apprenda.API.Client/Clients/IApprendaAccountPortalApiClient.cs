using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models.AccountPortal;

namespace ApprendaAPIClient.Clients
{
    public interface IApprendaAccountPortalApiClient
    {
        Task<bool> CreateUser(UserResource user);

        Task<IEnumerable<ApplicationVersionResource>> GetApplicationVersions();

        Task<ApplicationVersionResource> GetApplicationVersion(string appAlias, string versionAlias);

        Task<IEnumerable<PlanResource>> GetPlans(string appAlias, string versionAlias);
        Task<PlanResource> GetPlan(string appAlias, string versionAlias, string planId);


        Task<IEnumerable<SubscriptionResource>> GetSubscriptions(string appAlias, string versionAlias);

        Task<bool> CreateSubscription(string appAlias, string versionAlias, string locator, string userId);

        Task<bool> AssignRoles(string userId, string[] roles);

        Task<IEnumerable<RoleResource>> GetRoles();
    }
}
