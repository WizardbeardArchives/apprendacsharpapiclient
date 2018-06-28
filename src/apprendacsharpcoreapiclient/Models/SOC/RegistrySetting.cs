using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.SOC
{
    public class RegistrySetting : ResourceBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
