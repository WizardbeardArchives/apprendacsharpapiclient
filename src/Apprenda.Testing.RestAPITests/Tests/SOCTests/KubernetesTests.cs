using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class KubernetesTests : ApprendaAPITest
    {
        public KubernetesTests(ITestOutputHelper helper) : base(helper)
        {
        }

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
