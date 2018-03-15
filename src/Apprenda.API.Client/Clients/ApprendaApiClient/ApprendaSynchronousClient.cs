using System;
using System.Collections.Generic;
using ApprendaAPIClient.Models.AccountPortal;
using ApprendaAPIClient.Models.DeveloperPortal;
using ApprendaAPIClient.Models.SOC;
using ApprendaAPIClient.Models.SOC.Kubernetes;
using DeveloperPortal.Swagger.Model;
using IO.Swagger.Model;
using Application = ApprendaAPIClient.Models.DeveloperPortal.Application;
using Cloud = ApprendaAPIClient.Models.SOC.Cloud;
using Component = ApprendaAPIClient.Models.DeveloperPortal.Component;
using CustomProperty = ApprendaAPIClient.Models.SOC.CustomProperty;
using EnrichedComponentModel = ApprendaAPIClient.Models.DeveloperPortal.EnrichedComponentModel;
using Plan = ApprendaAPIClient.Models.DeveloperPortal.Plan;
using SubscribedTenant = ApprendaAPIClient.Models.DeveloperPortal.SubscribedTenant;
using SubscriptionRequest = ApprendaAPIClient.Models.DeveloperPortal.SubscriptionRequest;
using User = ApprendaAPIClient.Models.DeveloperPortal.User;
using Version = IO.Swagger.Model.Version;
using Workload = ApprendaAPIClient.Models.SOC.Workload;
using Subscription = ApprendaAPIClient.Models.DeveloperPortal.Subscriptions.Subscription;
namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal class ApprendaSynchronousClientAdapter : IApprendaSynchronousClient
    {
        private readonly IApprendaApiClient _asyncClient;

        /// <summary>
        /// Construct a syncronous client from an async one
        /// </summary>
        /// <param name="asyncClient"></param>
        public ApprendaSynchronousClientAdapter(IApprendaApiClient asyncClient)
        {
            _asyncClient = asyncClient;
        }


        public string Login(string userName, string password, string tenantAlias = null)
        {
            return _asyncClient.Login(userName, password, tenantAlias).Result;
        }

        public string Login()
        {
            return _asyncClient.Login().Result;
        }

        public void Logout(string sessionToken)
        {
            var task = _asyncClient.Logout(sessionToken);
            task.Wait();
        }

        public IEnumerable<string> GetTenants()
        {
            return _asyncClient.GetTenants().Result;
        }

        public bool CreateUser(UserResource user)
        {
            return _asyncClient.CreateUser(user).Result;
        }

        public IEnumerable<ApplicationVersionResource> GetApplicationVersions()
        {
            return _asyncClient.GetApplicationVersions().Result;
        }

        public ApplicationVersionResource GetApplicationVersion(string appAlias, string versionAlias)
        {
            return _asyncClient.GetApplicationVersion(appAlias, versionAlias).Result;
        }

        public IEnumerable<PlanResource> GetAccountPlans(string appAlias, string versionAlias)
        {
            return ((IApprendaAccountPortalApiClient)_asyncClient).GetPlans(appAlias, versionAlias).Result;
        }

        public PlanResource GetPlan(string appAlias, string versionAlias, string planId)
        {
            return _asyncClient.GetPlan(appAlias, versionAlias, planId).Result;
        }

        public IEnumerable<SubscriptionResource> GetSubscriptions(string appAlias, string versionAlias)
        {
            return _asyncClient.GetSubscriptions(appAlias, versionAlias).Result;
        }

        public bool CreateSubscription(string appAlias, string versionAlias, string locator, string userId)
        {
            return _asyncClient.CreateSubscription(appAlias, versionAlias, locator, userId).Result;
        }

        public bool AssignRoles(string userId, string[] roles)
        {
            return _asyncClient.AssignRoles(userId, roles).Result;
        }

        public IEnumerable<RoleResource> GetRoles()
        {
            return _asyncClient.GetRoles().Result;
        }

        public IEnumerable<Application> GetApplications()
        {
            return _asyncClient.GetApplications().Result;
        }

        public EnrichedApplication GetApplication(string appAlias)
        {
            return _asyncClient.GetApplication(appAlias).Result;
        }

        public bool PostApp(Application app)
        {
            return _asyncClient.PostApp(app).Result;
        }

        public bool DeleteApplication(string appAlias)
        {
            return _asyncClient.DeleteApplication(appAlias).Result;
        }

        public IEnumerable<Version> GetVersionsForApplication(string appAlias)
        {
            return _asyncClient.GetVersionsForApplication(appAlias).Result;
        }

        public EnrichedVersion GetVersion(string appAlias, string versionAlias)
        {
            return _asyncClient.GetVersion(appAlias, versionAlias).Result;
        }

        public PublishReportCardDTO PatchVersion(string appAlias, string versionAlias, bool constructive, byte[] file,
            string newVersionAlias = null, string newVersionName = null, string useScalingSettingsFrom = null,
            bool async = false)
        {
            return _asyncClient.PatchVersion(appAlias, versionAlias, constructive, file, newVersionAlias, newVersionName,
                useScalingSettingsFrom, async).Result;
        }

        public bool PromoteVersion(string appAlias, string versionAlias, ApplicationVersionStage desiredStage,
            bool waitForMinInstanceCount = false, bool inheritPublishedScalingSettings = false, bool async = true)
        {
            return _asyncClient.PromoteVersion(appAlias, versionAlias, desiredStage, waitForMinInstanceCount,
                inheritPublishedScalingSettings, async).Result;
        }

        public bool DemoteVersion(string appAlias, string versionAlias)
        {
            return _asyncClient.DemoteVersion(appAlias, versionAlias).Result;
        }

        public IEnumerable<Component> GetComponents(string appAlias, string versionAlias)
        {
            return _asyncClient.GetComponents(appAlias, versionAlias).Result;
        }

        public Component GetComponent(string appAlias, string versionAlias, string componentAlias)
        {
            return _asyncClient.GetComponent(appAlias, versionAlias, componentAlias).Result;
        }

        public Certificate GetCertificatesForComponent(string appAlias, string versionAlias, string componentAlias)
        {
            return _asyncClient.GetCertificatesForComponent(appAlias, versionAlias, componentAlias).Result;
        }

        public bool SetInstanceCountForComponent(string appAlias, string versionAlias, string componentAlias, int? numInstances,
            int? minInstances)
        {
            return _asyncClient
                .SetInstanceCountForComponent(appAlias, versionAlias, componentAlias, numInstances, minInstances)
                .Result;
        }

        public bool UpdateComponent(string appAlias, string versionAlias, string componentAlias, EnrichedComponentModel component)
        {
            return _asyncClient.UpdateComponent(appAlias, versionAlias, componentAlias, component).Result;
        }

        public EnvironmentVariableData GetEnvironmentVariables(string appAlias, string versionAlias, string componentAlias)
        {
            return _asyncClient.GetEnvironmentVariables(appAlias, versionAlias, componentAlias).Result;
        }

        public bool SetEnvironmentVariable(string appAlias, string versionAlias, string componentAlias, EnvironmentVariableData data)
        {
            return _asyncClient.SetEnvironmentVariable(appAlias, versionAlias, componentAlias, data).Result;
        }

        public IEnumerable<Plan> GetPlans(string appAlias, string versionAlias)
        {
            return ((IApprendaDeveloperPortalApiClient)_asyncClient).GetPlans(appAlias, versionAlias).Result;
        }

        public Plan GetPlan(string appAlias, string versionAlias, Guid planId)
        {
            return _asyncClient.GetPlan(appAlias, versionAlias, planId).Result;
        }

        public IEnumerable<User> GetUsersAuthZSubscribedTo(string appAlias, string versionAlias)
        {
            return _asyncClient.GetUsersAuthZSubscribedTo(appAlias, versionAlias).Result;
        }

        public User GetUserAuthZSubscribedTo(string appAlias, string versionAlias, string userId)
        {
            return _asyncClient.GetUserAuthZSubscribedTo(appAlias, versionAlias, userId).Result;
        }

        public bool RemoveAuthZUserFromApplication(string appAlias, string versionAlias, IEnumerable<string> userIds)
        {
            return _asyncClient.RemoveAuthZUserFromApplication(appAlias, versionAlias, userIds).Result;
        }

        public void CreateAuthZUserSubscription(string appAlias, string versionAlias, IEnumerable<string> userIds, string planName)
        {
            _asyncClient.CreateAuthZUserSubscription(appAlias, versionAlias, userIds, planName).Wait();
        }

        public IEnumerable<UserGroup> GetGroupsAuthZSubscribedTo(string appAlias, string versionAlias)
        {
            return _asyncClient.GetGroupsAuthZSubscribedTo(appAlias, versionAlias).Result;
        }

        public UserGroup GetGroupAuthZSubscribedTo(string appAlias, string versionAlias, string identifier)
        {
            return _asyncClient.GetGroupAuthZSubscribedTo(appAlias, versionAlias, identifier).Result;
        }

        public void CreateAuthZGroupSubscription(string appAlias, string versionAlias, IEnumerable<string> groupIds, string planName)
        {
            _asyncClient.CreateAuthZGroupSubscription(appAlias, versionAlias, groupIds, planName).Wait();
        }

        public bool RemoveAuthZGroupFromApplication(string appAlias, string currentVersionAlias, List<string> identifiers, string planName)
        {
            return _asyncClient.RemoveAuthZGroupFromApplication(appAlias, currentVersionAlias, identifiers, planName)
                .Result;
        }

        public Subscription CreateMultiTenantSubscription(string appAlias, string versionAlias, string tenantAlias,
            SubscriptionRequest request)
        {
            return _asyncClient.CreateMultiTenantSubscription(appAlias, versionAlias, tenantAlias, request).Result;
        }

        public IEnumerable<Subscription> GetSubscriptions(string appAlias, string versionAlias, string tenantAlias)
        {
            return _asyncClient.GetSubscriptions(appAlias, versionAlias, tenantAlias).Result;
        }

        public Subscription GetSubscription(string appAlias, string versionAlias, string tenantAlias, string locator)
        {
            return _asyncClient.GetSubscription(appAlias, versionAlias, tenantAlias, locator).Result;
        }

        public bool DeleteSubscription(string appAlias, string versionAlias, string tenantAlias, string locator)
        {
            return _asyncClient.DeleteSubscription(appAlias, versionAlias, tenantAlias, locator).Result;
        }

        public IEnumerable<SubscribedTenant> GetSubscribedTenants(string appAlias, string versionAlias, string tenantAlias)
        {
            return _asyncClient.GetSubscribedTenants(appAlias, versionAlias, tenantAlias).Result;
        }

        public AggregateVersionAllocationDTO GetVersionAllocationInformation(string appAlias, string versionAlias)
        {
            return _asyncClient.GetVersionAllocationInformation(appAlias, versionAlias).Result;
        }

        public IEnumerable<KubernetesCluster> GetAllKubernetesClusters()
        {
            return _asyncClient.GetAllKubernetesClusters().Result;
        }

        public KubernetesCluster GetKubernetesCluser(string clusterName)
        {
            return _asyncClient.GetKubernetesCluser(clusterName).Result;
        }

        public KubernetesClusterReportCard AddKubernetesCluster(KubernetesCluster cluster)
        {
            return _asyncClient.AddKubernetesCluster(cluster).Result;
        }

        public KubernetesClusterReportCard UpdateKubernetesCluster(KubernetesCluster cluster)
        {
            return _asyncClient.UpdateKubernetesCluster(cluster).Result;
        }

        public bool DeleteKubernetesCluster(string clusterName)
        {
            return _asyncClient.DeleteKubernetesCluster(clusterName).Result;
        }

        public KubernetesClusterReportCard ValidateKubernetesCluster(string clusterName)
        {
            return _asyncClient.ValidateKubernetesCluster(clusterName).Result;
        }

        public IEnumerable<Host> GetAllHosts()
        {
            return _asyncClient.GetAllHosts().Result;
        }

        public IEnumerable<Cloud> GetClouds()
        {
            return _asyncClient.GetClouds().Result;
        }

        public Cloud GetCloud(int id)
        {
            return _asyncClient.GetCloud(id).Result;
        }

        public IEnumerable<HealthReport> GetHealthReports(string hostName)
        {
            return _asyncClient.GetHealthReports(hostName).Result;
        }

        public IEnumerable<CustomProperty> GetAllCustomProperties()
        {
            return _asyncClient.GetAllCustomProperties().Result;
        }

        public CustomProperty GetCustomProperty(int id)
        {
            return _asyncClient.GetCustomProperty(id).Result;
        }

        public CustomProperty CreateCustomProperty(CustomProperty customProperty)
        {
            return _asyncClient.CreateCustomProperty(customProperty).Result;
        }

        public bool UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate)
        {
            return _asyncClient.UpdateCustomProperty(customPropertyUpdate).Result;
        }

        public bool DeleteCustomProperty(int id)
        {
            return _asyncClient.DeleteCustomProperty(id).Result;
        }

        public IEnumerable<RegistrySetting> GetRegistrySettings()
        {
            return _asyncClient.GetRegistrySettings().Result;
        }

        public RegistrySetting GetRegistrySetting(string name)
        {
            return _asyncClient.GetRegistrySetting(name).Result;
        }

        public RegistrySetting CreateRegistrySetting(RegistrySetting setting)
        {
            return _asyncClient.CreateRegistrySetting(setting).Result;
        }

        public bool UpdateRegistrySetting(RegistrySetting setting)
        {
            return _asyncClient.UpdateRegistrySetting(setting).Result;
        }

        public bool DeleteRegistrySetting(string name)
        {
            return _asyncClient.DeleteRegistrySetting(name).Result;
        }

        public IEnumerable<Group> GetExternalUserStoreGroups()
        {
            return _asyncClient.GetExternalUserStoreGroups().Result;
        }

        public Group GetExternalUserStoreGroup(string groupId)
        {
            return _asyncClient.GetExternalUserStoreGroup(groupId).Result;
        }

        public IEnumerable<Node> GetNodes()
        {
            return _asyncClient.GetNodes().Result;
        }

        public Node GetNode(string name)
        {
            return _asyncClient.GetNode(name).Result;
        }

        public EnrichedResourcePolicies GetResourcePolicies()
        {
            return _asyncClient.GetResourcePolicies().Result;
        }

        public EnrichedResourcePolicy GetResourcePolicy(Guid policyId)
        {
            return _asyncClient.GetResourcePolicy(policyId).Result;
        }

        public bool CreateResourcePolicy(EnrichedResourcePolicy policy)
        {
            return _asyncClient.CreateResourcePolicy(policy).Result;
        }

        public void UpdateResourcePolicy(EnrichedResourcePolicy policy)
        {
            _asyncClient.UpdateResourcePolicy(policy).Wait();
        }

        public IEnumerable<Workload> GetWorkloads()
        {
            return _asyncClient.GetWorkloads().Result;
        }

        public IEnumerable<ExtendedWorkload> GetWorkloads(string appAlias, string versionAlias)
        {
            return _asyncClient.GetWorkloads(appAlias, versionAlias).Result;
        }

        public Workload GetWorkload(int artifactId)
        {
            return _asyncClient.GetWorkload(artifactId).Result;
        }

        public ExtendedWorkload GetWorkload(string host)
        {
            return _asyncClient.GetWorkload(host).Result;
        }

        public bool RelocateWorkload(int id)
        {
            return _asyncClient.RelocateWorkload(id).Result;
        }

        public bool RemoveWorkload(int id)
        {
            return _asyncClient.RemoveWorkload(id).Result;
        }

        public string GetExportLogs()
        {
            return _asyncClient.GetExportLogs().Result;
        }

        public IEnumerable<BootstrapPolicy> GetBootstrapPolicies()
        {
            return _asyncClient.GetBootstrapPolicies().Result;
        }

        public BootstrapPolicy GetBootstrapPolicy(Guid id)
        {
            return _asyncClient.GetBootstrapPolicy(id).Result;
        }

        public BootstrapPolicy CreateBootstrapPolicy(BootstrapPolicy policy)
        {
            return _asyncClient.CreateBootstrapPolicy(policy).Result;
        }

        public void UpdateBootstrapPolicy(Guid id, BootstrapPolicy policy)
        {
            var task = _asyncClient.UpdateBootstrapPolicy(id, policy);
            task.Wait();
        }

        public bool DeleteBootstrapPolicy(Guid id)
        {
            return _asyncClient.DeleteBootstrapPolicy(id).Result;
        }
    }
}
