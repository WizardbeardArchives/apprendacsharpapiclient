using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal.Subscriptions
{
    public class Subscription : ResourceBase
    {

        public Guid Id { get; set; }
        public ResourceBase Application { get; set; }
        public ResourceBase Version { get; set; }
        public bool Utilized { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Locator { get; set; }
        public ResourceBase Plan { get; set; }
        public SubscriptionStatus Status { get; set; }
    }

    [Serializable]
    public enum SubscriptionStatus
    {
        Active = 1,
        Expired = 2,
        Cancelled = 3,
        Suspended = 4,
        Dead = 5,
        Swapped = 6,
    }
}
