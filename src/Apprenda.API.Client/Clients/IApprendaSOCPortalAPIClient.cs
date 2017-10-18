using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models.SOC;
using Cloud = ApprendaAPIClient.Models.SOC.Cloud;
using CustomProperty = ApprendaAPIClient.Models.SOC.CustomProperty;

namespace ApprendaAPIClient.Clients
{
    public interface IApprendaSOCPortalApiClient
    {
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

        Task<bool> UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate);
        Task<bool> DeleteCustomProperty(int id);

        Task<IEnumerable<RegistrySetting>> GetRegistrySettings();
        Task<RegistrySetting> GetRegistrySetting(string name);
        Task<RegistrySetting> CreateRegistrySetting(RegistrySetting setting);

        Task<bool> UpdateRegistrySetting(RegistrySetting setting);
        Task<bool> DeleteRegistrySetting(string name);

        Task<IEnumerable<Group>> GetExternalUserStoreGroups();
        Task<Group> GetExternalUserStoreGroup(string groupId);

        Task<IEnumerable<Node>> GetNodes();
        Task<Node> GetNode(string name);

        Task<EnrichedResourcePolicies> GetResourcePolicies();

        Task<EnrichedResourcePolicy> GetResourcePolicy(Guid policyId);

        Task<bool> CreateResourcePolicy(EnrichedResourcePolicy policy);
        Task UpdateResourcePolicy(EnrichedResourcePolicy policy);

        Task<IEnumerable<Workload>> GetWorkloads();
        Task<IEnumerable<ExtendedWorkload>> GetWorkloads(string appAlias, string versionAlias);

        Task<Workload> GetWorkload(int artifactId);
        Task<ExtendedWorkload> GetWorkload(string host);
      

        Task<bool> RelocateWorkload(int id);
        Task<bool> RemoveWorkload(int id);

        Task<string> GetExportLogs();

        Task<IEnumerable<BootstrapPolicy>> GetBootstrapPolicies();
        Task<BootstrapPolicy> GetBootstrapPolicy(Guid id);
        Task<BootstrapPolicy> CreateBootstrapPolicy(BootstrapPolicy policy);
        Task UpdateBootstrapPolicy(Guid id, BootstrapPolicy policy);
        Task<bool> DeleteBootstrapPolicy(Guid id);
    }
}
