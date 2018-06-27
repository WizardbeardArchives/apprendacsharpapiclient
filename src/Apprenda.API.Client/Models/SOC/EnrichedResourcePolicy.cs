using System;
using System.Collections.Generic;

namespace ApprendaAPIClient.Models.SOC
{
    public class ResourcePolicy : ResourceBase
    {
        public ResourcePolicy(string href)
            : base(href)
        {
        }

        public ResourcePolicy() { }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public long? MemoryLimitInMegabytes { get; set; }

        public long? CpuLimitInMegahertz { get; set; }

        public float? CpuLimitInFractionOfCore { get; set; }

        public int CpuCores { get; set; }

        public decimal? UnitCost { get; set; }

        public string UnitCostCurrency { get; set; }

        public string UnitLabel { get; set; }
    }

    [Flags]
    public enum ComputePolicyType
    {
        Presentation = 1,
        Persistence = 2,
        Service = 4,
        LinuxService = 8,
        War = 16,
        Kubernetes = 32,
        Any = Kubernetes | War | LinuxService | Service | Persistence | Presentation,
    }

    public class EnrichedResourcePolicy : ResourcePolicy
    {
        public EnrichedResourcePolicy(string href)
            : base(href)
        {
        }

        public EnrichedResourcePolicy()
        { }

        public ComputePolicyType Type { get; set; }

        public bool IsActive { get; set; }

        public bool AllowDeployment { get; set; }
    }

    public class EnrichedResourcePolicies
    {
        public List<EnrichedResourcePolicy> resourcePolicies { get; set; }
        
    }
}
