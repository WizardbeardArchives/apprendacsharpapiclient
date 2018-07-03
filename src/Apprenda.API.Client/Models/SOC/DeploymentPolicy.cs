using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.SOC
{
    public class DeploymentPolicy : ResourceBase
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public bool appliesToSandbox { get; set; }
        public bool appliesToPublished { get; set; }
        public string objectType { get; set; }
        public string customPropertyName { get; set; }
        public string customPropertyDisplayName { get; set; }
        public string policyApplicability { get; set; }
        public string policyCondition { get; set; }
        public int priority { get; set; }
        public string href { get; set; }
    }
}
