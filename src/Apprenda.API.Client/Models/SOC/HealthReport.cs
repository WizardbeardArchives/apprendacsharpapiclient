using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.SOC
{
    public enum HealthCheckResultType
    {
        Normal = 1,
        Limited = 2,
        Failed = 3,
        Timeout = 4,
        Exception = 5
    }

    public enum HealthOutcome
    {
        Healthy,
        PreventDeployments,
        Unhealthy,
    }

    public class HealthReport : ResourceBase
    {
        public long Id { get; set; }

        public string Hostname { get; set; }

        public ResourceBase Checks { get; set; }

        public ResourceBase Summary { get; set; }

        public HealthCheckResultType Result { get; set; }

        public HealthOutcome Outcome { get; set; }

        public DateTime StartTime { get; set; }

        public long DurationMs { get; set; }
    }
}
