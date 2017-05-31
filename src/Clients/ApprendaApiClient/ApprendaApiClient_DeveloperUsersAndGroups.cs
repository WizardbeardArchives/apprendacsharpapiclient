using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models.DeveloperPortal;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        public Task<IEnumerable<Plan>> GetPlans(string appAlias, string versionAlias)
        {

            return Task.Run(() => EnumeratePagedResults<Plan>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "/plans", DEV));
        }


        public Task<Plan> GetPlan(string appAlias, string versionAlias, string planId)
        {
            return GetResultAsync<Plan>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"/plans/{planId}");
        }

        public Task<IEnumerable<User>> GetUsers(string appAlias, string versionAlias)
        {
            //'/api/v1/apps/{appAlias}/versions/{versionAlias}/users'
            return Task.Run(() => EnumeratePagedResults<User>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "/users",
                DEV));
        }

        public Task<User> GetUser(string appAlias, string versionAlias, string userId)
        {
            return GetResultAsync<User>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) +
                                        $"users/user?userId={userId}");
        }

        public Task<IEnumerable<UserGroup>> GetGroups(string appAlias, string versionAlias)
        {
            return Task.Run(() => EnumeratePagedResults<UserGroup>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "/groups",
                DEV));
        }

        public Task<UserGroup> GetGroup(string appAlias, string versionAlias, string groupName)
        {
            return GetResultAsync<UserGroup>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) +
                                        $"groups/group?groupName={groupName}");
        }
    }
}
