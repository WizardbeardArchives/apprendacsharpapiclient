using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public class UserGroup : ResourceBase
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
    }
}
