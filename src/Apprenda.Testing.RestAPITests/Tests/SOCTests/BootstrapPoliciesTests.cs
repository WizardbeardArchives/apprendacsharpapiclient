using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Clients;
using Xunit;
using ApprendaAPIClient.Models.SOC;
namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class BootstrapPoliciesTests : ApprendaAPITest
    {
        [Fact]
        public async Task RetrieveAllBootstrapPolicies()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                var bsps = (await client.GetBootstrapPolicies()).ToList();

                Assert.NotNull(bsps);
                Assert.True(bsps.Any());
                if (bsps.Any(bs => bs.AppliedToKubernetes))
                {
                    Assert.True(bsps.Any(bs => bs.ComponentType == PublicApprendaObjectType.Pods));
                }

                foreach (var bsp in bsps)
                {
                    var byId = await client.GetBootstrapPolicy(bsp.Id);

                    Assert.NotNull(byId);
                    Assert.Equal(bsp.ComponentType, byId.ComponentType);
                    AssertBootstrapPoliciesAreEqual(bsp, byId);
                }
            }
        }

        [Fact(Skip = "still discovering business rules")]
        public async Task UserInterfaceBootstrapPolicyCRUD()
        {
            const string bspName = "testUICRUD";
            using (var session = await StartSession())
            {
                var client = await session.GetClient();

                DeleteIfExists(bspName, client);

                //CREATE
                var bsp = new BootstrapPolicy
                {
                    AppliedPerComponent = true,
                    AppliedToWindows = true,
                    AppliedToSandboxStage = true,
                    IsAlwaysApplied = true,
                    ComponentType = PublicApprendaObjectType.UserInterfaces,
                    Description = "done for testing",
                    Name = bspName,
                    IsActive = true
                };

                var res = await client.CreateBootstrapPolicy(bsp);

                Assert.NotNull(res);
                Assert.NotNull(res.Id);
                Assert.Equal(bspName, res.Name);

                //RETRIEVE
                var firstGet = await client.GetBootstrapPolicy(res.Id);

                AssertBootstrapPoliciesAreEqual(firstGet, bsp);

                //UPDATE
                var updated = new BootstrapPolicy
                {
                    Id = firstGet.Id,
                    AppliedPerComponent = false,
                    AppliedToLinux = true,
                    AppliedToPublishedStage = true,
                    IsAlwaysApplied = true,
                    ComponentType = PublicApprendaObjectType.UserInterfaces,
                    Description = "done for testing",
                    Name = bspName + "_updated",
                    IsActive = false
                };

                await client.UpdateBootstrapPolicy(firstGet.Id, updated);

                //RETRIEVE AGAIN
                var secondGet = await client.GetBootstrapPolicy(updated.Id);
                AssertBootstrapPoliciesAreEqual(secondGet, updated);
                
                //DELETE
                var del = await client.DeleteBootstrapPolicy(secondGet.Id);
                Assert.True(del);

                //FAIL RETRIEVE
                var failed = false;
                try
                {
                    var failRes = await client.GetBootstrapPolicy(secondGet.Id);
                    Assert.Null(failRes);
                }
                catch (Exception e)
                {
                    failed = true;
                    //TODO assert e is a 404
                }

                Assert.True(failed);
            }
        }

        /// <summary>
        /// Compares all fields except ID, throws error if they don't match
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private static void AssertBootstrapPoliciesAreEqual(BootstrapPolicy first, BootstrapPolicy second)
        {
            Assert.Equal(first.Name, second.Name);
            Assert.Equal(first.AppliedToKubernetes, second.AppliedToKubernetes);
            Assert.Equal(first.AppliedPerComponent, second.AppliedPerComponent);
            Assert.Equal(first.AppliedPerInstance, second.AppliedPerInstance);
            Assert.Equal(first.AppliedToLinux, second.AppliedToLinux);
            Assert.Equal(first.AppliedToSandboxStage, second.AppliedToSandboxStage);
            Assert.Equal(first.AppliedToPublishedStage, second.AppliedToPublishedStage);
            Assert.Equal(first.AppliedToWindows, second.AppliedToWindows);
            Assert.Equal(first.Comparison, second.Comparison);
            Assert.Equal(first.CustomPropertyName, second.CustomPropertyName);
            Assert.Equal(first.ComponentType, second.ComponentType);
            Assert.Equal(first.IsActive, second.IsActive);
        }

        private static async void DeleteIfExists(string bspName, IApprendaSOCPortalApiClient client)
        {
            try
            {
                var bsps = await client.GetBootstrapPolicies();

                var existing = bsps.FirstOrDefault(bsp => string.Equals(bsp.Name, bspName, StringComparison.CurrentCultureIgnoreCase));
                if (existing != null)
                {
                    await client.DeleteBootstrapPolicy(existing.Id);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
