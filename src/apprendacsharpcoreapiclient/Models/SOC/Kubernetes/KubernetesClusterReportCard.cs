using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.SOC.Kubernetes
{
    public class KubernetesClusterReportCard
    {
        public List<KubernetesClusterReportCardGroup> Groups { get; internal set; }
    }

    public class KubernetesClusterReportCardGroup
    {
        public string Name { get; internal set; }
        public List<KubernetesClusterReportCardSection> Sections { get; internal set; }
    }

    public class KubernetesClusterReportCardSection
    {
        public string Name { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCanceled { get; set; }
        public List<KubernetesClusterReportCardMessage> Messages { get; set; }
        public string Description { get; set; }
    }

    public class KubernetesClusterReportCardMessage
    {
        public string Level { get; internal set; }
        public string Message { get; internal set; }
    }
}
