using System;
using System.Collections.Generic;
using DeveloperPortal.Swagger.Model;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class StorageQuotaReference : ResourceBase
    {
        public string Name { get; set; }
    }


    [Serializable]
    public enum PipelineMode : byte
    {
        Integrated,
        Classic,
    }

    public enum ScalingType : byte
    {
        Manual,
        Scheduled,
        Automatic,
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


    public class SecuredComponent : Component
    {

        public string Domain { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class EnrichedWarComponent : EnrichedComponent
    {
        public EnrichedWarComponent(string href)
        {
            EnvironmentVariables = new List<NameValuePair>();
            SystemProperties = new List<NameValuePair>();
        }

        public List<NameValuePair> EnvironmentVariables { get; set; }

        public List<NameValuePair> SystemProperties { get; set; }

        public List<Certificate> Certificates { get; set; }

        public string Runtime { get; set; }


        public string LogPattern { get; set; }


        public string Container { get; set; }


        public bool? JMXEnabled { get; set; }
    }
}
