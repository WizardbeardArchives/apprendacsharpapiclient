using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class ExternalUserStoreGroups : ApprendaAPITest
    {
        [Fact]
        public async Task ExternalUserStoreGroupsRetrieval()
        {
            using (var session = await StartSession())
            {
                var settings = session.ConnectionSettings;
                if (settings.EnvironmentFeaturesAvailable != null && settings.EnvironmentFeaturesAvailable.IsExternalUserStore)
                {
                    var client = await session.GetClient(ApiPortals.SOC);

                    var allGroups = await client.GetExternalUserStoreGroups();

                    var foundGroups = false;
                    foreach (var group in allGroups)
                    {
                        foundGroups = true;
                        var getIndivid = await client.GetExternalUserStoreGroup(group.Id);

                        Assert.NotNull(getIndivid);

                        Assert.Equal(group.Description, getIndivid.Description);
                        Assert.Equal(group.Id, getIndivid.Id);
                        Assert.Equal(group.DisplayName, getIndivid.DisplayName);
                        Assert.Equal(group.Href, getIndivid.Href);
                        Assert.Contains(getIndivid.Id, getIndivid.Href);
                    }

                    Assert.True(foundGroups);
                }
            }
        }

        public ExternalUserStoreGroups(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
