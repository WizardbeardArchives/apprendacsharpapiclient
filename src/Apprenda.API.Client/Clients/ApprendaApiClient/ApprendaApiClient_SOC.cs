using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.SOC;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        private const string INTERNAL = "socinternal";
        public async Task<IEnumerable<Cloud>> GetClouds()
        {
            var res = await GetResultAsync<UnpagedResourceBase<Cloud>>("clouds", SOC);
            return res?.Items;
        }

        public Task<Cloud> GetCloud(int id)
        {
            return GetResultAsync<Cloud>($"clouds/{id}", SOC);
        }

        public Task<IEnumerable<HealthReport>> GetHealthReports(string hostName)
        {
            return Task.Run(() => EnumeratePagedResults<HealthReport>($"hosts/{hostName}/healthreports", SOC));
        }

        public Task<IEnumerable<CustomProperty>> GetAllCustomProperties()
        {
            return Task.Run(() => EnumeratePagedResults<CustomProperty>("customproperties", SOC));
        }

        public Task<CustomProperty> GetCustomProperty(int id)
        {
            return GetResultAsync<CustomProperty>($"customproperties/{id}", SOC);
        }

        public Task<CustomProperty> CreateCustomProperty(CustomProperty customProperty)
        {
            return PostAsync<CustomProperty>("customproperties", customProperty, SOC);
        }

        public Task<bool> UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate)
        {
            return PutVoid($"customproperties/{customPropertyUpdate.Id}", customPropertyUpdate, SOC);
        }

        public Task<bool> DeleteCustomProperty(int id)
        {
            return DeleteAsync($"customproperties/{id}", SOC);
        }

        public Task<IEnumerable<RegistrySetting>> GetRegistrySettings()
        {
            return Task.Run(() => EnumeratePagedResults<RegistrySetting>("/registry", SOC));
        }

        public Task<RegistrySetting> GetRegistrySetting(string name)
        {
            return GetResultAsync<RegistrySetting>($"/registry/{name}", SOC);
        }

        public Task<RegistrySetting> CreateRegistrySetting(RegistrySetting setting)
        {
            return PostAsync<RegistrySetting>("/registry", setting, SOC);
        }

        public Task<bool> UpdateRegistrySetting(RegistrySetting setting)
        {
            return PutVoid($"/registry/{setting.Name}", setting, SOC);
        }

        public Task<bool> DeleteRegistrySetting(string name)
        {
            return DeleteAsync($"/registry/{name}", SOC);
        }

        public Task<IEnumerable<Group>> GetExternalUserStoreGroups()
        {
            return Task.Run(() => EnumeratePagedResults<Group>("/groups", INTERNAL));
        }

        public Task<Group> GetExternalUserStoreGroup(string groupId)
        {
            return GetResultAsync<Group>($"groups/{groupId}", SOC);
        }

        public Task<IEnumerable<Node>> GetNodes()
        {
            return Task.Run(() => EnumeratePagedResults<Node>("nodes", SOC));
        }

        public Task<Node> GetNode(string name)
        {
            return GetResultAsync<Node>($"nodes?nodename={name}", SOC);
        }

        public Task<EnrichedResourcePolicies> GetResourcePolicies()
        {
            return GetResultAsync<EnrichedResourcePolicies>("resourcepolicies", SOC);
        }

        public Task<EnrichedResourcePolicy> GetResourcePolicy(Guid policyId)
        {
            return GetResultAsync<EnrichedResourcePolicy>($"resourcepolicies/{policyId}", SOC);
        }

        public Task<bool> CreateResourcePolicy(EnrichedResourcePolicy policy)
        {
            return PostAsync<bool>("resourcepolicies", policy, SOC);
        }

        public Task UpdateResourcePolicy(EnrichedResourcePolicy policy)
        {
            return PutVoid("resourcepolicies", policy, SOC);
        }

        public Task<IEnumerable<Workload>> GetWorkloads()
        {
            return GetResultAsync<IEnumerable<Workload>>("workloads", INTERNAL);
        }

        public Task<IEnumerable<ExtendedWorkload>> GetWorkloads(string appAlias, string versionAlias)
        {
            return GetResultAsync<IEnumerable<ExtendedWorkload>>($"workloads/{appAlias}/{versionAlias}", INTERNAL);
        }

        public Task<Workload> GetWorkload(int id)
        {
            return GetResultAsync<Workload>($"workloads/{id}", INTERNAL);
        }

        public Task<ExtendedWorkload> GetWorkload(string host)
        {
            return GetResultAsync<ExtendedWorkload>($"workloads?host={host}", INTERNAL);
        }

        public Task<bool> RelocateWorkload(int id)
        {
            return PostAsync<bool>($"workloads/{id}?action=relocate", null, INTERNAL);
        }

        public Task<bool> RemoveWorkload(int id)
        {
            return PostAsync<bool>($"workloads/{id}?action=remove", null, INTERNAL);
        }

        public Task<IEnumerable<BootstrapPolicy>> GetBootstrapPolicies()
        {
            return Task.Run(() => EnumeratePagedResults<BootstrapPolicy>("bootstrappolicies", SOC));
        }

        public Task<BootstrapPolicy> GetBootstrapPolicy(Guid id)
        {
            return GetResultAsync<BootstrapPolicy>($"bootstrappolicies/{id}", SOC);
        }

        public Task<BootstrapPolicy> CreateBootstrapPolicy(BootstrapPolicy policy)
        {
            return PostAsync<BootstrapPolicy>("bootstrappolicies", policy, SOC);
        }

        public Task UpdateBootstrapPolicy(Guid id, BootstrapPolicy policy)
        {
            return PutVoid($"bootstrappolicies/{id}", policy, SOC);
        }

        public Task<bool> DeleteBootstrapPolicy(Guid id)
        {
            return DeleteAsync($"bootstrappolicies/{id}", SOC);
        }

        public Task<IEnumerable<DeploymentPolicy>> GetDeploymentPolicies()
        {
            return Task.Run(() => EnumeratePagedResults<DeploymentPolicy>("deploymentpolicies", SOC));
        }

        public Task<DeploymentPolicy> GetDeploymentPolicy(int id)
        {
            return GetResultAsync<DeploymentPolicy>($"deploymentpolicies/{id}", SOC);
        }

        public Task<DeploymentPolicy> CreateDeploymentPolicy (DeploymentPolicy policy)
        {
            return PostAsync<DeploymentPolicy>("deploymentpolicies", policy, SOC);
        }

        public Task UpdateDeploymentPolicy(int id, DeploymentPolicy policy)
        {
            return PutVoid($"deploymentpolicies/{id}", policy, SOC);
        }

        public Task<bool> DeleteDeploymentPolicy(int id)
        {
            return DeleteAsync($"deploymentpolicies/{id}", SOC);
        }
    }
}
