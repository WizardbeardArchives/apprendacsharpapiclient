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


        public Task<Plan> GetPlan(string appAlias, string versionAlias, string planId)
        {
            return GetResultAsync<Plan>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"plans/{planId}", DEV);
        }

        public Task<IEnumerable<User>> GetUsers(string appAlias, string versionAlias)
        {
            //'/api/v1/apps/{appAlias}/versions/{versionAlias}/users'
            return Task.Run(() => EnumeratePagedResults<User>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "users",
                DEV));
        }

        public Task<User> GetUser(string appAlias, string versionAlias, string userId)
        {
            return GetResultAsync<User>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) +
                                        $"users/user?identifier={userId}", DEV);
        }

        public Task<IEnumerable<UserGroup>> GetGroups(string appAlias, string versionAlias)
        {
            return Task.Run(() => EnumeratePagedResults<UserGroup>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "groups",
                DEV));
        }

        public Task<UserGroup> GetGroup(string appAlias, string versionAlias, string groupName)
        {
            return GetResultAsync<UserGroup>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) +
                                        $"groups/group?groupName={groupName}", DEV);
        }

        public Task CreateAuthZUserSubscription(string appAlias, string versionAlias, IEnumerable<string> userIds, string planName)
        {
            var arg = new AddUserAuthZSubscritpionRequest
            {
                PlanName = planName,
                UserIdentifiers = userIds.ToList()
            };

            return PostAsync<bool>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "/users", arg, DEV);
        }

        public Task RemoveAuthZUserSubscription(string appAlias, string versionAlias, IEnumerable<string> userIds)
        {
            return DeleteAsync(GetAppVersionStartPoint(appAlias, versionAlias, DEV), DEV);
        }
    }
}
