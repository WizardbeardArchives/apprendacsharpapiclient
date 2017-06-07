using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class User : ResourceBase
    {
        public string Description { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Identifier { get; set; }
        public bool IsEnabled { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public ResourceBase Roles { get; set; }
        public ResourceBase Subscriptions { get; set; }

        public string Suffix { get; set; }
    }
}
