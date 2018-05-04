using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal.Subscriptions
{
    public class AddUserAuthZSubscritpionRequest
    {
        public List<string> UserIdentifiers { get; set; }
        public string PlanName { get; set; }
    }
}
