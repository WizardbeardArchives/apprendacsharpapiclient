using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.SOC.Kubernetes
{
    public class KubernetesCluster
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int CloudId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GatewayHostnames { get; set; }
        public string HeapsterUrl { get; set; }
        public string ClientCertificate { get; set; }
        public string ClientCertificatePassword { get; set; }
        public string AuthenticationMode { get; set; }
    }
}
