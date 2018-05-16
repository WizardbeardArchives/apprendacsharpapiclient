using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class NodeTests : ApprendaAPITest
    {
        [InlineData(AvailableSmokeTestApplications.HelloWorld)]
        [Theory]
        public async Task NodeRetrieval(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 10) + "mtsubs";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);

                    var nodes = (await client.GetNodes()).ToList();

                    Assert.True(nodes.Any());

                    foreach (var node in nodes)
                    {
                        var byName = await client.GetNode(node.Name);

                        Assert.Equal(node.Name, byName.Name);
                        Assert.Equal(node.CloudName, byName.CloudName);
                        Assert.Equal(node.Workloads.Href, byName.Workloads.Href);

                        //match our roles
                        foreach (var role in node.NodeRoles)
                        {
                            var matching = byName.NodeRoles.FirstOrDefault(nr => nr.NodeRoleType == role.NodeRoleType);

                            Assert.NotNull(matching);
                            Assert.Equal(role.ClockSpeed, matching.ClockSpeed);
                        }
                    }
                }
            }
        }
    }
}
