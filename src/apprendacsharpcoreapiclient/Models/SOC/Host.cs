using System;

namespace ApprendaAPIClient.Models.SOC
{
    [Flags]
    public enum HostType : byte
    {
        Windows = 1,
        Database = 2,
        Linux = 4,
        NonDatabase = Linux | Windows,
        All = NonDatabase | Database,
        LoadManager = 8,
        Cache = 16,
        Zookeeper = 32,
    }

    public enum NodeState
    {
        Online = 1,
        Offline = 2,
        Removed = 3,
        Down = 4,
        Reserved = 5,
        Maintenance = 6,
        ReservedDown = 7,
    }

    public class Host
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long TotalMemory { get; set; }
        public int ClockSpeed { get; set; }
        public int ProcessorCount { get; set; }
        public int Architecture { get; set; }
        public string CloudName { get; set; }
        public NodeState NodeState { get; set; }
        public HostType HostType { get; set; }
        public bool IsTransitioning { get; set; }
        public bool IsContainerRunning { get; set; }
        public string Version { get; set; }
        public string PlatformVersion { get; set; }
        public bool IsUserInterfaceHost { get; set; }
    }
}
