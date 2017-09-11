using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Swagger.Model;
using IO.Swagger.Model;
using Newtonsoft.Json;

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

    public class EnrichedComponent : SecuredComponent
    {
        public EnrichedComponent(string href)
            : base()
        {
        }

        public ComponentInstanceHolder Instances { get; set; }

        public long? StorageBlocks { get; set; }

        public int? MinimumInstanceCount { get; set; }

        public int? MaximumInstanceCount { get; set; }

        public bool HttpMapped { get; set; }

        public ResourceBase Files { get; set; }

        public ScalingType? ScalingType { get; set; }

        public bool IsOperatorOverride { get; set; }

        public ICollection<MonitoringConnectionDetailsDTO> MonitoringConnectionDetails { get; set; }

        public IEnumerable<ScheduledScalingEvent> ScalingSchedule { get; set; }
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
            : base(href)
        {
            EnvironmentVariables = new List<NameValuePair>();
            SystemProperties = new List<NameValuePair>();
        }

        public new List<NameValuePair> EnvironmentVariables { get; set; }

        public List<NameValuePair> SystemProperties { get; set; }

        public List<Certificate> Certificates { get; set; }

        public string Runtime { get; set; }


        public string LogPattern { get; set; }


        public string Container { get; set; }


        public bool? JMXEnabled { get; set; }
    }

    public class EnrichedComponentModel : EnrichedWarComponent
    {
        public EnrichedComponentModel(string href)
            : base(href)
        {
        }

        public PipelineMode? PipelineMode { get; set; }
    }
}
