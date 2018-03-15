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

namespace ApprendaAPIClient.Clients
{
    /// <summary>
    /// Version of the client present synchronous (no Task) method for consumption in Powershell
    /// </summary>
    public interface IApprendaSynchronousClient
    {
        /// <summary>
        /// Logs into the platform with the given credentials
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="tenantAlias"></param>
        /// <returns>Session token for the login</returns>
        string Login(string userName, string password, string tenantAlias = null);

        /// <summary>
        /// Login with the stored credential
        /// </summary>
        /// <returns></returns>
        string Login();

        void Logout(string sessionToken);

        IEnumerable<string> GetTenants();

        #region Account
        bool CreateUser(UserResource user);

        IEnumerable<ApplicationVersionResource> GetApplicationVersions();

        ApplicationVersionResource GetApplicationVersion(string appAlias, string versionAlias);

        IEnumerable<PlanResource> GetAccountPlans(string appAlias, string versionAlias);
        PlanResource GetPlan(string appAlias, string versionAlias, string planId);


        IEnumerable<SubscriptionResource> GetSubscriptions(string appAlias, string versionAlias);

        bool CreateSubscription(string appAlias, string versionAlias, string locator, string userId);

        bool AssignRoles(string userId, string[] roles);

        IEnumerable<RoleResource> GetRoles();
        #endregion

        #region Dev
        IEnumerable<Application> GetApplications();

        EnrichedApplication GetApplication(string appAlias);

        bool PostApp(Application app);

        bool DeleteApplication(string appAlias);

        IEnumerable<Version> GetVersionsForApplication(string appAlias);

        EnrichedVersion GetVersion(string appAlias, string versionAlias);

        PublishReportCardDTO PatchVersion(string appAlias, string versionAlias, bool constructive,
            byte[] file,
            string newVersionAlias = null, string newVersionName = null,
            string useScalingSettingsFrom = null, bool async = false);

        bool PromoteVersion(string appAlias, string versionAlias,
            ApplicationVersionStage desiredStage,
            bool waitForMinInstanceCount = false,
            bool inheritPublishedScalingSettings = false,
            bool async = true);

        bool DemoteVersion(string appAlias, string versionAlias);

        IEnumerable<Component> GetComponents(string appAlias, string versionAlias);

        Component GetComponent(string appAlias, string versionAlias, string componentAlias);

        Certificate GetCertificatesForComponent(string appAlias, string versionAlias, string componentAlias);

        //  public HttpResponseMessage Post(string alias, string subAlias, string identifier, [FromUri] string action, [FromUri] int? count = null, [FromUri] int? minCount = null)
        bool SetInstanceCountForComponent(string appAlias, string versionAlias, string componentAlias,
            int? numInstances, int? minInstances);

        bool UpdateComponent(string appAlias, string versionAlias, string componentAlias,
            EnrichedComponentModel component);

        EnvironmentVariableData GetEnvironmentVariables(string appAlias, string versionAlias, string componentAlias);

        bool SetEnvironmentVariable(string appAlias, string versionAlias, string componentAlias, EnvironmentVariableData data);

        //new features for tenant works
        IEnumerable<Plan> GetPlans(string appAlias, string versionAlias);

        Plan GetPlan(string appAlias, string versionAlias, Guid planId);

        IEnumerable<User> GetUsersAuthZSubscribedTo(string appAlias, string versionAlias);

        User GetUserAuthZSubscribedTo(string appAlias, string versionAlias, string userId);
        bool RemoveAuthZUserFromApplication(string appAlias, string versionAlias, IEnumerable<string> userIds);

        void CreateAuthZUserSubscription(string appAlias, string versionAlias, IEnumerable<string> userIds,
            string planName);

        IEnumerable<UserGroup> GetGroupsAuthZSubscribedTo(string appAlias, string versionAlias);
        UserGroup GetGroupAuthZSubscribedTo(string appAlias, string versionAlias, string identifier);

        void CreateAuthZGroupSubscription(string appAlias, string versionAlias, IEnumerable<string> groupIds,
            string planName);

        bool RemoveAuthZGroupFromApplication(string appAlias, string currentVersionAlias, List<string> identifiers, string planName);

        Subscription CreateMultiTenantSubscription(string appAlias, string versionAlias, string tenantAlias, SubscriptionRequest request);

        IEnumerable<Subscription> GetSubscriptions(string appAlias, string versionAlias, string tenantAlias);
        Subscription GetSubscription(string appAlias, string versionAlias, string tenantAlias, string locator);
        bool DeleteSubscription(string appAlias, string versionAlias, string tenantAlias, string locator);

        IEnumerable<SubscribedTenant> GetSubscribedTenants(string appAlias, string versionAlias, string tenantAlias);

        AggregateVersionAllocationDTO GetVersionAllocationInformation(string appAlias, string versionAlias);
        #endregion

        #region Kubernetes
        IEnumerable<KubernetesCluster> GetAllKubernetesClusters();
        KubernetesCluster GetKubernetesCluser(string clusterName);

        KubernetesClusterReportCard AddKubernetesCluster(KubernetesCluster cluster);
        KubernetesClusterReportCard UpdateKubernetesCluster(KubernetesCluster cluster);

        bool DeleteKubernetesCluster(string clusterName);

        KubernetesClusterReportCard ValidateKubernetesCluster(string clusterName);
        #endregion

        #region SOC
        IEnumerable<Host> GetAllHosts();

        IEnumerable<Cloud> GetClouds();

        Cloud GetCloud(int id);

        IEnumerable<HealthReport> GetHealthReports(string hostName);

        IEnumerable<CustomProperty> GetAllCustomProperties();
        CustomProperty GetCustomProperty(int id);

        /// <summary>
        /// POST to the custom property endpoint
        /// </summary>
        /// <param name="customProperty"></param>
        /// <returns></returns>
        CustomProperty CreateCustomProperty(CustomProperty customProperty);

        bool UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate);
        bool DeleteCustomProperty(int id);

        IEnumerable<RegistrySetting> GetRegistrySettings();
        RegistrySetting GetRegistrySetting(string name);
        RegistrySetting CreateRegistrySetting(RegistrySetting setting);

        bool UpdateRegistrySetting(RegistrySetting setting);
        bool DeleteRegistrySetting(string name);

        IEnumerable<Group> GetExternalUserStoreGroups();
        Group GetExternalUserStoreGroup(string groupId);

        IEnumerable<Node> GetNodes();
        Node GetNode(string name);

        EnrichedResourcePolicies GetResourcePolicies();

        EnrichedResourcePolicy GetResourcePolicy(Guid policyId);

        bool CreateResourcePolicy(EnrichedResourcePolicy policy);
        void UpdateResourcePolicy(EnrichedResourcePolicy policy);

        IEnumerable<Workload> GetWorkloads();
        IEnumerable<ExtendedWorkload> GetWorkloads(string appAlias, string versionAlias);

        Workload GetWorkload(int artifactId);
        ExtendedWorkload GetWorkload(string host);


        bool RelocateWorkload(int id);
        bool RemoveWorkload(int id);

        string GetExportLogs();

        IEnumerable<BootstrapPolicy> GetBootstrapPolicies();
        BootstrapPolicy GetBootstrapPolicy(Guid id);
        BootstrapPolicy CreateBootstrapPolicy(BootstrapPolicy policy);
        void UpdateBootstrapPolicy(Guid id, BootstrapPolicy policy);
        bool DeleteBootstrapPolicy(Guid id);
        #endregion
    }
}
