using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class StorageQuotaReference : ResourceBase
    {
        public string Name { get; set; }
    }

    public class ResourceAllocationPolicyReference : ResourceBase
    {
        public string Name { get; set; }

        public ResourceAllocationPolicyReference(string href) : base(href)
        {
        }
    }

    public class Component : ResourceBase
    {
       
        public ResourceBase Version { get; set; }


        public StorageQuotaReference StorageQuoata { get; set; }


        public ResourceAllocationPolicyReference ResourcePolicy { get; set; }


        public ResourceBase CustomProperties { get; set; }


        public string Name { get; set; }


        public string Type { get; set; }


        public string Alias { get; set; }


        public new string Href { get; set; }


        public ResourceBase EnvironmentVariables { get; set; }
    }
}
