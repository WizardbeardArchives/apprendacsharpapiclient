using ApprendaAPIClient.Models.AccountPortal;
using System.Collections.Generic;

namespace ApprendaAPIClient.Clients
{
    /// <summary>
    /// Version of the client that supports all syncronous (no Task) operations.  Used for consumption by Powershell
    /// </summary>
    public interface IApprendaSyncronousAPIClient
    {
        /// <summary>
        /// Logs into the platform with the given credentials
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Session token for the login</returns>
        string Login(string userName, string password, string tenantAlias = null);

        /// <summary>
        /// Login with the stored credential
        /// </summary>
        /// <returns></returns>
        string Login();

        void Logout(string sessionToken);

        IEnumerable<string> GetTenants();
        
        #region Account Portal
        bool CreateUser(UserResource user);

        IEnumerable<ApplicationVersionResource> GetApplicationVersions();

        ApplicationVersionResource GetApplicationVersion(string appAlias, string versionAlias);

        IEnumerable<PlanResource> GetPlans(string appAlias, string versionAlias);
        PlanResource GetPlan(string appAlias, string versionAlias, string planId);


        IEnumerable<SubscriptionResource> GetSubscriptions(string appAlias, string versionAlias);

        bool CreateSubscription(string appAlias, string versionAlias, string locator, string userId);

        bool AssignRoles(string userId, string[] roles);

        IEnumerable<RoleResource> GetRoles();
     
        #endregion
        
        #region Developer Portal
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

        #endregion
        
        #region Kubernetes Cluster
        IEnumerable<KubernetesCluster> GetAllKubernetesClusters();
        KubernetesCluster GetKubernetesCluser(string clusterName);

        KubernetesClusterReportCard AddKubernetesCluster(KubernetesCluster cluster);
        KubernetesClusterReportCard UpdateKubernetesCluster(KubernetesCluster cluster);

        bool DeleteKubernetesCluster(string clusterName);

        KubernetesClusterReportCard ValidateKubernetesCluster(string clusterName);
        #endregion
        
        #region SOC
        Task<IEnumerable<Host>> GetAllHosts();

        Task<IEnumerable<Cloud>> GetClouds();

        Task<Cloud> GetCloud(int id);

        Task<IEnumerable<HealthReport>> GetHealthReports(string hostName);

        Task<IEnumerable<CustomProperty>> GetAllCustomProperties();
        Task<CustomProperty> GetCustomProperty(int id);

        /// <summary>
        /// POST to the custom property endpoint
        /// </summary>
        /// <param name="customProperty"></param>
        /// <returns></returns>
        Task<CustomProperty> CreateCustomProperty(CustomProperty customProperty);

        bool UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate);
        bool DeleteCustomProperty(int id);

        Task<IEnumerable<RegistrySetting>> GetRegistrySettings();
        Task<RegistrySetting> GetRegistrySetting(string name);
        Task<RegistrySetting> CreateRegistrySetting(RegistrySetting setting);

        bool UpdateRegistrySetting(RegistrySetting setting);
        bool DeleteRegistrySetting(string name);

        Task<IEnumerable<Group>> GetExternalUserStoreGroups();
        Task<Group> GetExternalUserStoreGroup(string groupId);

        Task<IEnumerable<Node>> GetNodes();
        Task<Node> GetNode(string name);

        Task<EnrichedResourcePolicies> GetResourcePolicies();

        Task<EnrichedResourcePolicy> GetResourcePolicy(Guid policyId);

        bool CreateResourcePolicy(EnrichedResourcePolicy policy);
        Task UpdateResourcePolicy(EnrichedResourcePolicy policy);

        Task<IEnumerable<Workload>> GetWorkloads();
        Task<IEnumerable<ExtendedWorkload>> GetWorkloads(string appAlias, string versionAlias);

        Task<Workload> GetWorkload(int artifactId);
        Task<ExtendedWorkload> GetWorkload(string host);
      

        bool RelocateWorkload(int id);
        bool RemoveWorkload(int id);

        Task<string> GetExportLogs();

        Task<IEnumerable<BootstrapPolicy>> GetBootstrapPolicies();
        Task<BootstrapPolicy> GetBootstrapPolicy(Guid id);
        Task<BootstrapPolicy> CreateBootstrapPolicy(BootstrapPolicy policy);
        Task UpdateBootstrapPolicy(Guid id, BootstrapPolicy policy);
        bool DeleteBootstrapPolicy(Guid id);
        #endregion
    }
}