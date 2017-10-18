using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.AccountPortal;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        private const string ACCOUNT = "account";

        public Task<bool> CreateUser(UserResource user)
        {
            return PostAsync<bool>("users/", user, ACCOUNT);
        }

        public Task<IEnumerable<ApplicationVersionResource>> GetApplicationVersions()
        {
            return Task.Run(() => EnumeratePagedResults<ApplicationVersionResource>("applicationVersions", ACCOUNT));
        }

        public Task<ApplicationVersionResource> GetApplicationVersion(string appAlias, string versionAlias)
        {
            return GetResultAsync<ApplicationVersionResource>($"applicationVersions/{appAlias}-{versionAlias}",
                ACCOUNT);
        }

        async Task<IEnumerable<PlanResource>> IApprendaAccountPortalApiClient.GetPlans(string appAlias, string versionAlias)
        {

            var plans = await GetResultAsync<UnpagedResourceBase<PlanResource>>($"applicationVersions/{appAlias}-{versionAlias}/plans",
                ACCOUNT);

            return plans.Items;
        }

        public Task<PlanResource> GetPlan(string appAlias, string versionAlias, string planId)
        {
            return GetResultAsync<PlanResource>($"applicationVersions/{appAlias}-{versionAlias}/plans/{planId}",
                ACCOUNT);
        }

        public async Task<IEnumerable<SubscriptionResource>> GetSubscriptions(string appAlias, string versionAlias)
        {
            var resources = await GetResultAsync<UnpagedResourceBase<SubscriptionResource>>(GetAppVersionStartPoint(appAlias, versionAlias, ACCOUNT) + "subscriptions", ACCOUNT);
            return resources == null ? new List<SubscriptionResource>() : resources.Items;
        }


        public Task<bool> CreateSubscription(string appAlias, string versionAlias, string locator, string userId)
        {
            return PostAsync<bool>(GetAppVersionStartPoint(appAlias, versionAlias, ACCOUNT) + $"subscriptions/{locator}/assignedto", null, ACCOUNT, new { userId = userId });
        }

        public Task<bool> AssignRoles(string userId, string[] roles)
        {
            return PostAsync<bool>("users/roles", roles, ACCOUNT, new { userId = userId });
        }

        public async Task<IEnumerable<RoleResource>> GetRoles()
        {
            var roles = await GetResultAsync<UnpagedResourceBase<RoleResource>>("roles", ACCOUNT);
            return roles == null ? new List<RoleResource>() : roles.Items;
        }
    }
}
