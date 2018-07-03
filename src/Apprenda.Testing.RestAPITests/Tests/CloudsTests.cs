using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests
{
    public class CloudsTests : ApprendaAPITest
    {
        [Fact]
        public async Task GetCloudsReturnsAllAndById()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                 var clouds = await client.GetClouds();

                var cloud = clouds.FirstOrDefault();
                Assert.NotNull(cloud);


                var directQuery = await client.GetCloud(cloud.Id);

                Assert.Equal(directQuery.Id, cloud.Id);
                Assert.False(string.IsNullOrWhiteSpace(directQuery.Href));
            }
        }

        public CloudsTests(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
