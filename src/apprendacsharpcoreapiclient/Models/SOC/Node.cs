using System;
using System.Collections.Generic;

namespace ApprendaAPIClient.Models.SOC
{
    public class Node
    {
        public string Name { get; set; }
        public string CloudName { get; set; }
        public List<NodeRole> NodeRoles { get; set; }
        public ResourceBase Workloads { get; set; }
    }

    public class NodeRole
    {
        public enum NodeTypeEnum
        {
            Windows,
            Linux,
            Database,
            LoadManager,
            Cache,
            Zookeeper,
            Unknown
        }

        public enum DatabaseProviderEnum
        {

            None,
            SqlServer,
            Oracle11G,
            Oracle12C
        }

        public string nodeRole { get; set; }

        public NodeTypeEnum NodeRoleType => (NodeTypeEnum) Enum.Parse(typeof(NodeTypeEnum), nodeRole);

        public DatabaseProviderEnum? DatabaseProvider { get; set; }
        public string Architecture { get; set; }
        public int? TotalMemory { get; set; }
        public long? TotalStorage { get; set; }
        public int? ProcessorCount { get; set; }
        public int? ClockSpeed { get; set; }

        public long? AllocatedStorage { get; set; }
        public long? AllocatedCpu { get; set; }
        public long? AllocatedMemory { get; set; }
        public bool? IsContainerRunning { get; set; }
        public NodeRoleState RoleState { get; set; }
        public string ApprendaPlatformVersion { get; set; }
        public bool? IsTransitioning { get; set; }
        public string OsVersion { get; set; }
    }

    public class NodeRoleState : ResourceBase
    {
        public string State { get; set; }
        public string TransitionReason { get; set; }
    }
}
