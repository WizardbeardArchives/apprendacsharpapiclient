using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class SubscriptionRequest : ResourceBase
    {
        public string PlanName { get; set; }
        public int NumberOfSubscriptions { get; set; }
        public string TenantAlias { get; set; }
    }
}
