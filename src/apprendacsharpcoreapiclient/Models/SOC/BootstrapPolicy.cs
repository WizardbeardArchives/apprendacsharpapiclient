using System;
using System.Collections.Generic;

namespace ApprendaAPIClient.Models.SOC
{
    public class BootstrapPolicy : ResourceBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool AppliedToWindows { get; set; }
        public bool AppliedToLinux { get; set; }
        public bool IsAlwaysApplied { get; set; }
        public bool AppliedToSandboxStage { get; set; }
        public bool AppliedToPublishedStage { get; set; }
        public string CustomPropertyName { get; set; }
        public PublicApprendaObjectType? ComponentType { get; set; }
        public ComparisonType? Comparison { get; set; }
        public List<string> Values { get; set; }
        public bool AppliedToKubernetes { get; set; }
        public bool AppliedPerComponent { get; set; }
        public bool AppliedPerInstance { get; set; }
    }

    public enum ComparisonType : byte
    {
        ContainsAll,
        DoesNotContainAll,
        ContainsAny,
        IsEmpty,
        IsNotEmpty,
        DoesNotContainAny,
    }

    public enum PublicApprendaObjectType
    {
        ComputeServers,
        ResourcePolicies,
        Applications,
        WindowsServices,
        UserInterfaces,
        Databases,
        StorageQuotas,
        LinuxServices,
        JavaWebApplications,
        BootstrapPolicies,
        DatabaseServers,
        ApplicationComponents, // Maps to Developer minus Application
        Pods,
        All
    }
}
