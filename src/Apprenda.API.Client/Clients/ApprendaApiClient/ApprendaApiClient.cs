using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.AccountPortal;
using ApprendaAPIClient.Models.DeveloperPortal;
using ApprendaAPIClient.Models.SOC;
using ApprendaAPIClient.Services.ClientHelpers;
using IO.Swagger.Model;
using Application = ApprendaAPIClient.Models.DeveloperPortal.Application;
using Component = ApprendaAPIClient.Models.DeveloperPortal.Component;
using EnrichedComponent = ApprendaAPIClient.Models.DeveloperPortal.EnrichedComponent;
using EnrichedComponentModel = ApprendaAPIClient.Models.DeveloperPortal.EnrichedComponentModel;
using Version = IO.Swagger.Model.Version;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient : BaseApprendaApiClient, IApprendaApiClient
    {
        public ApprendaApiClient(IConnectionSettings connectionSettings)
            : base(connectionSettings)
        {
        }

        public ApprendaApiClient(IConnectionSettings connectionSettings, IRestSession restSession)
            : base(connectionSettings, restSession)
        {
        }

        public Task<IEnumerable<Application>> GetApplications()
        {
            return GetResultAsync<IEnumerable<Application>>("apps", DEV);
        }

        public Task<EnrichedApplication> GetApplication(string appAlias)
        {
            return GetResultAsync<EnrichedApplication>("apps/" + appAlias, DEV);
        }

        public async Task<bool> PostApp(Application app)
        {
            await PostAsync<bool>("apps", app, DEV);
            return true;
        }

        public Task<bool> DeleteApplication(string appAlias)
        {
            return DeleteAsync("apps/" + appAlias, DEV);
        }

        public Task<IEnumerable<Version>> GetVersionsForApplication(string appAlias)
        {
            return GetResultAsync<IEnumerable<Version>>("versions/" + appAlias, DEV);
        }

        public Task<EnrichedVersion> GetVersion(string appAlias, string versionAlias)
        {
            return GetResultAsync<EnrichedVersion>("versions/" + appAlias + "/" + versionAlias, DEV);
        }

        public Task<IEnumerable<Host>> GetAllHosts()
        {
            return GetResultAsync<IEnumerable<Host>>("hosts", "socinternal");
        }

        public Task<string> GetExportLogs()
        {
            return GetResultAsync<string>("logs/extract.json", SOC);
        }


        public async Task<ReportCard> SetArchive(string appAlias, string versionAlias, bool destructive, byte[] archive)
        {
            var queryParams = new { action = "setArchive", destructive = 1, };
            var res = await PostBinaryAsync<ReportCard>($"versions/{appAlias}/{versionAlias}", archive, queryParams, DEV);

            return res;
        }

        public Task<PublishReportCardDTO> PatchVersion(string appAlias, string versionAlias, bool constructive,
            byte[] file, string newVersionAlias = null, string newVersionName = null,
            string useScalingSettingsFrom = null, bool async = false)
        {
            var queryParams =
                new
                {
                    action = "patch",
                    patchMode = constructive ? "constructive" : "destructive",
                    async,
                    newVersionAlias,
                    newVersionName
                };

            return PostBinaryAsync<PublishReportCardDTO>($"versions/{appAlias}/{versionAlias}", file, queryParams, DEV);
        }

        public async Task<bool> PromoteVersion(string appAlias, string versionAlias, ApplicationVersionStage desiredStage,
            bool waitForMinInstanceCount = false, bool inheritPublishedScalingSettings = false, bool async = true)
        {
            var qp = new
            {
                async,
                action = "promote",
                waitForMinInstanceCount,
                stage = desiredStage.ToString(),
                inheritPublishedScalingSettings
            };

            await PostAsync<bool>($"versions/{appAlias}/{versionAlias}", null, DEV, qp);

            return true;
        }

        public async Task<bool> DemoteVersion(string appAlias, string versionAlias)
        {
            var qp = new
            {
                action = "demote"
            };
            return await PostAsync<bool>($"versions/{appAlias}/{versionAlias}", null, DEV, qp);
        }

        public async Task<IEnumerable<Component>> GetComponents(string appAlias, string versionAlias)
        {
            var res = await GetResultAsync<UnpagedResourceBase<Component>>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "/components", DEV);

            return res == null ? new List<Component>() : res.Items;
        }

        public Task<Component> GetComponent(string appAlias, string versionAlias, string componentAlias)
        {
            return GetResultAsync<Component>(GetAppVersionStartPoint(appAlias, versionAlias, DEV),
                $"components/{componentAlias}", DEV);
        }

        public Task<bool> SetInstanceCountForComponent(string appAlias, string versionAlias, string componentAlias, int? numInstances,
            int? minInstances)
        {
            if (!numInstances.HasValue && !minInstances.HasValue)
            {
                throw new ArgumentException("Either minimum instances or number of instances must be specified");
            }

            return PostAsync<bool>(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + "/components",
                new {action = "SetInstanceCount", count = numInstances, minCount = minInstances}, DEV);
        }

        public Task<bool> UpdateComponent(string appAlias, string versionAlias, string componentAlias, EnrichedComponentModel component)
        {
            return PutVoid(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"/components/{componentAlias}", component,
                DEV);
        }


        public Task<EnvironmentVariableData> GetEnvironmentVariables(string appAlias, string versionAlias, string componentAlias)
        {
            return GetResultAsync<EnvironmentVariableData>(
                GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"components/{componentAlias}/environmentvariables", DEV);
        }


        public Task<bool> SetEnvironmentVariable(string appAlias, string versionAlias, string componentAlias, EnvironmentVariableData data)
        {
            return PutVoid(GetAppVersionStartPoint(appAlias, versionAlias, DEV) + $"components/{componentAlias}/environmentvariables", data, DEV);
        }


        public Task<IEnumerable<string>> GetTenants()
        {
            var helper = new GenericApiHelper(ConnectionSettings, "developer");

            var tenants = helper.Authenticator.GetTenants(ConnectionSettings.UserLogin.UserName,
                ConnectionSettings.UserLogin.Password);

            return Task.FromResult(tenants);
        }

        public Task<bool> CreateUser(UserResource user)
        {
            return PostAsync<bool>("users/", user, ACCOUNT);
        }

        public async Task<IEnumerable<ApplicationVersionResource>> GetApplicationVersions()
        {
            var resources = await GetResultAsync<PagedResourceBase<ApplicationVersionResource>>("applicationVersions", ACCOUNT);
            return resources == null ? new List<ApplicationVersionResource>() : resources.Items;
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
