using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class SubscribedTenant
    {
        public string TenantAlias { get; set; }
        public string TenantName { get; set; }
        public ResourceBase Users { get; set; }
    }
}
