using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models
{
    public class ResourceBase
    {
        public ResourceBase()
        {

        }

        public ResourceBase(string href)
        {
            Href = href;
        }
        public string Href { get; set; }
    }
}
