using System;

namespace ApprendaAPIClient.Models.SOC
{
    public enum ComponentType
    {
        UserInterface = 1,
        Database = 2,
        WcfService = 3,
        LinuxService = 4,
        JavaWebApplication = 5,
        WindowsService = 6,
        Kubernetes = 7,
    }

    public class Component : ResourceBase
    {
        public Component(string href)
            : base(href)
        {
        }

        public ComponentType ComponentType { get; set; }
        public string ArtifactName { get; set; }
        public Guid ArtifactId { get; set; }
        public string VersionAlias { get; set; }
        public string ApplicationAlias { get; set; }
        public string DeveloperAlias { get; set; }
    }

    public class Workload : Component
    {
        public Workload(string href)
            : base(href)
        {
        }

        public int DeployedArtifactId { get; set; }
        public Guid InstanceId { get; set; }
        public int HostId { get; set; }
        public string HostName { get; set; }
    }

    public class ExtendedWorkload : Workload
    {
        public ExtendedWorkload(string href)
            : base(href)
        {
        }

        public int? ProcessId { get; set; }
        public string Status { get; set; }
    }
}
