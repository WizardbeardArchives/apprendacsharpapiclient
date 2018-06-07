using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;
using Xunit.Abstractions;
using ApprendaAPIClient.Models.SOC.Kubernetes;

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
        [Fact]
        public async Task CreateKubernetesCluster()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);
                var newCluster = new KubernetesCluster()
                {
                    AuthenticationMode = "BasicAuth",
                    GatewayHostnames = "K8SPUBLIC787K01",
                    CloudId = 1,
                    Name = "k8spublic",
                    Url = "https://K8SPUBLIC787K01:6443",
                    Username = "admin",
                    Password = "Ziyzalocdotoy5722"
                };
                var addition = client.AddKubernetesCluster(newCluster).Result;

                var addedCluster = client.GetKubernetesCluser("k8spublic").Result;
                Assert.Equal(newCluster.Name, addedCluster.Name);

            }
        }
    }
}
