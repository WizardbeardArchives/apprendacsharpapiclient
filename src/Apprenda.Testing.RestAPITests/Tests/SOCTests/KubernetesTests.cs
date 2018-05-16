using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class KubernetesTests : ApprendaAPITest
    {

        [Fact]
        public async Task GetKubernetesClusters()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                var clusters = await client.GetAllKubernetesClusters();

                foreach (var cluster in clusters)
                {
                    var byName = await client.GetKubernetesCluser(cluster.Name);

                    Assert.NotNull(byName);

                    var validation = await client.ValidateKubernetesCluster(cluster.Name);

                    Assert.NotNull(validation);
                }
            }
        }
    }
}
