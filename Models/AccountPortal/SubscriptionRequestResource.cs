using System.Collections.Generic;
using ApprendaAPIClient.Models.AccountPortal;

namespace RESTApiTests.Account.Resources
{
    internal class SubscriptionRequestResource
    {
        public List<PlanRequestResource> PlanRequests { get; set; }
    }
}
