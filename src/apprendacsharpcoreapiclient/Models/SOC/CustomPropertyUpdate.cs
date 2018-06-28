using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.SOC
{
    public class CustomPropertyUpdate : CustomProperty
    {
        public CustomPropertyUpdate() { }

        public CustomPropertyUpdate(CustomProperty source)
        {
            Name = source.Name;
            Applicability = source.Applicability;
            Description = source.Description;
            DeveloperOptions = source.DeveloperOptions;
            DisplayName = source.DisplayName;
            Href = source.Href;
            Id = source.Id;
            ValueOptions = source.ValueOptions;

            DeletedValueReplacements = new Dictionary<string, string>();
            
        }
        public Dictionary<string, string> DeletedValueReplacements { get; set; }
    }
}
