using System.Collections.Generic;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;

namespace Apprenda.Testing.RestAPITestTools
{
    public class IntegrationFactAttribute : FactAttribute
    {
        public IEnumerable<EnvironmentFeatures> EnvironmentFeatures { get; set; }

        public IntegrationFactAttribute(IEnumerable<EnvironmentFeatures> featuresRequired)
        {
            EnvironmentFeatures = featuresRequired;
        }
    }
}
