using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApprendaAPIClient.IntegrationTesting
{
    public class KubernetesEndpointTests : BaseTest
    {
        [Fact]
        public async Task BasicRetrieval()
        {
            var client = GetClient();

            var token = await client.Login();
            Assert.NotNull(token);

            var allItems = await client.GetAllKubernetesClusters();

            Assert.NotNull(allItems);
        }
    }
}
