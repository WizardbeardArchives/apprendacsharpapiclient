using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.SOC.Kubernetes;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        public async Task<IEnumerable<KubernetesCluster>> GetAllKubernetesClusters()
        {
            var res = await GetResultAsync<UnpagedResourceBase<KubernetesCluster>>("clusters", SOC);

            return res.Items;
        }

        public Task<KubernetesCluster> GetKubernetesCluser(string clusterName)
        {
            return GetResultAsync<KubernetesCluster>($"clusters/{clusterName}", SOC);
        }

        public Task<KubernetesClusterReportCard> AddKubernetesCluster(KubernetesCluster cluster)
        {
            return PostAsync<KubernetesClusterReportCard>("clusters", cluster, SOC);
        }

        public Task<KubernetesClusterReportCard> UpdateKubernetesCluster(KubernetesCluster cluster)
        {
            if (string.IsNullOrEmpty(cluster.Name))
            {
                throw new ArgumentException("Cluster must have a name to update - did you mean to add instead?");
            }
            return PutAsync<KubernetesClusterReportCard>($"clusters/{cluster.Name}", cluster, SOC);
        }

        public Task<bool> DeleteKubernetesCluster(string clusterName)
        {
            return DeleteAsync($"clusters/{clusterName}", SOC);
        }

        public Task<KubernetesClusterReportCard> ValidateKubernetesCluster(string clusterName)
        {
            return GetResultAsync<KubernetesClusterReportCard>($"clusters/{clusterName}/validate", SOC);
        }
    }
}
