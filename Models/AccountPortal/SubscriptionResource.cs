using System;
using RESTApiTests.Account.Resources;

namespace ApprendaAPIClient.Models.AccountPortal
{
    public class SubscriptionResource
    {
        public string Id { get; set; }

        public ResourceBase AppVersion { get; set; }

        public string Group { get; set; }

        public UserResource AssignedTo { get; set; }

        public bool? AutoRenew { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Description { get; set; }

        public DateTime? LastRenewalDate { get; set; }

        public string Locator { get; set; }

        public string Label { get; set; }

        public DateTime? NextRenewalDate { get; set; }

        public string ProviderId { get; set; }

        public string EditionName { get; set; }

        public ResourceBase Plan { get; set; }

        public string Status { get; set; }

        public DateTime? TerminationDate { get; set; }

        public string Href { get; set; }
    }
}
