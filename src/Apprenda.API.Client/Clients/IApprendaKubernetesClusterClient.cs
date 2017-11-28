using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.SOC.Kubernetes;

namespace ApprendaAPIClient.Clients
{
    public interface IApprendaKubernetesClusterClient
    {
        Task<IEnumerable<KubernetesCluster>> GetAllKubernetesClusters();
        Task<KubernetesCluster> GetKubernetesCluser(string clusterName);

        Task<KubernetesClusterReportCard> AddKubernetesCluster(KubernetesCluster cluster);
        Task<KubernetesClusterReportCard> UpdateKubernetesCluster(KubernetesCluster cluster);

        Task<bool> DeleteKubernetesCluster(string clusterName);

        Task<KubernetesClusterReportCard> ValidateKubernetesCluster(string clusterName);
    }
}
