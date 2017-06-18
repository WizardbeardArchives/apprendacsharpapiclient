using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    [Serializable]
    public enum EntitlementDefintionType
    {
        UserBased,
        AccountWide
    }

    public class Plan : ResourceBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public EntitlementDefintionType EntitlementDefintionType { get; set; }

        public string EntitlementName { get; set; }
    }
}
