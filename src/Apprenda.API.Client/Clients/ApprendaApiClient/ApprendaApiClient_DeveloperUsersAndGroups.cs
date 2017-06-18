using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApprendaAPIClient.Models.DeveloperPortal;
using ApprendaAPIClient.Models.DeveloperPortal.Subscriptions;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        public Task<IEnumerable<Plan>> GetPlans(string appAlias, string versionAlias)
        {

            return Task.Run(() => EnumeratePagedResults<Plan>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "plans", DEV));
        }


        public Task<Plan> GetPlan(string appAlias, string versionAlias, Guid planId)
        {
            return GetResultAsync<Plan>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"plans/{planId}", DEV);
        }

        public Task<IEnumerable<User>> GetUsersAuthZSubscribedTo(string appAlias, string versionAlias)
        {
            //'/api/v1/apps/{appAlias}/versions/{versionAlias}/users'
            return Task.Run(() => EnumeratePagedResults<User>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "users",
                DEV));
        }

        public Task<User> GetUserAuthZSubscribedTo(string appAlias, string versionAlias, string userId)
        {
            return GetResultAsync<User>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) +
                                        $"users/user?identifier={userId}", DEV);
        }

        public Task<bool> RemoveAuthZUserFromApplication(string appAlias, string versionAlias, IEnumerable<string> userIds)
        {
            var args = new RemoveUserAuthZSubscriptionRequest
            {
                UserIdentifiers = userIds.ToList()
            };
            return DeleteAsync(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"users", args, DEV);
        }

        public Task<IEnumerable<UserGroup>> GetGroupsAuthZSubscribedTo(string appAlias, string versionAlias)
        {
            return Task.Run(() => EnumeratePagedResults<UserGroup>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "groups",
                DEV));
        }

        public Task<UserGroup> GetGroupAuthZSubscribedTo(string appAlias, string versionAlias, string identifier)
        {
            return GetResultAsync<UserGroup>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) +
                                        $"groups/group?identifier={identifier}", DEV);
        }

        public Task CreateAuthZUserSubscription(string appAlias, string versionAlias, IEnumerable<string> userIds, string planName)
        {
            var arg = new AddUserAuthZSubscritpionRequest
            {
                PlanName = planName,
                UserIdentifiers = userIds.ToList()
            };

            return PostAsync<bool>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "users", arg, DEV);
        }

        public Task CreateAuthZGroupSubscription(string appAlias, string versionAlias, IEnumerable<string> groupIds, string planName)
        {
            var arg = new AddGroupsRequest
            {
                GroupIdentifiers = groupIds.ToList()
            };

            return PostAsync<bool>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "groups", arg, DEV);
        }

        public Task<IEnumerable<SubscribedTenant>> GetSubscribedTenants(string appAlias, string versionAlias, string tenantAlias)
        {
            return Task.Run(() => EnumeratePagedResults<SubscribedTenant>($"tenants/{tenantAlias}/subscriptions", DEV));
        }

        public Task<bool> CreateMultiTenantSubscription(string appAlias, string versionAlias, string tenantAlias, SubscriptionRequest request)
        {
            return PostAsync<bool>($"tenants/{tenantAlias}/subscriptions", request, DEV);
        }

        public Task<bool> RemoveAuthZGroupFromApplication(string appAlias, string currentVersionAlias, List<string> identifiers, string planName)
        {
            var arg = new RemoveGroupsRequest
            {
                GroupIdentifiers = identifiers.ToList()
            };

            return DeleteAsync(GetAppVersionStartPoint(appAlias, currentVersionAlias, DEV) + "groups", arg, DEV);
        }
    }
}
