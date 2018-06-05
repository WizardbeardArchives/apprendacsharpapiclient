using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Models.SOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class ResourcePoliciesTests : ApprendaAPITest
    {
        public ResourcePoliciesTests(ITestOutputHelper helper) : base(helper)
        {
        }

        [Fact]
        public async Task RetrieveAllResourcePolicies()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);
               // var test = (await client.GetResourcePolicies());
                var resourcePolicies = (await client.GetResourcePolicies()).resourcePolicies;                

                Assert.NotNull(resourcePolicies);
                Assert.True(resourcePolicies.Any());

                foreach (var policy in resourcePolicies)
                {
                    var byId = await client.GetResourcePolicy(policy.Id);

                    Assert.NotNull(byId);
                    Assert.Equal(policy.Name, byId.Name);
                }
            }
        }

        [Fact]
        public async Task CreateResourcePolicy()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                var newPolicy = new EnrichedResourcePolicy()
                {
                    AllowDeployment = true,
                    IsActive = true,
                    CpuCores = 1,
                    CpuLimitInMegahertz = 500,
                    MemoryLimitInMegabytes = 500,
                    Name = "TestPolicy",
                    Type = ComputePolicyType.Presentation
                };

                bool policyCreated = client.CreateResourcePolicy(newPolicy).Result;
                if(policyCreated)
                {
                    var resourcePolicies = (await client.GetResourcePolicies()).resourcePolicies;
                    var createdPolicy = resourcePolicies.First(t => t.Name == newPolicy.Name && t.MemoryLimitInMegabytes == newPolicy.MemoryLimitInMegabytes && t.CpuLimitInMegahertz == newPolicy.CpuLimitInMegahertz);

                    Assert.NotNull(createdPolicy);
                }
                else
                {
                    throw (new Exception("There was an error creating your resource policy"));
                }
            }

        }

        [Fact]
        public async Task UpdateResourcePolicy()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                var newPolicy = new EnrichedResourcePolicy()
                {
                    AllowDeployment = true,
                    IsActive = true,
                    CpuCores = 1,
                    CpuLimitInMegahertz = 500,
                    MemoryLimitInMegabytes = 500,
                    Name = "TestPolicy",
                    Type = ComputePolicyType.Presentation
                };

                bool policyCreated = await client.CreateResourcePolicy(newPolicy);
                if (policyCreated)
                {
                    var resourcePolicies = (await client.GetResourcePolicies()).resourcePolicies;
                    var createdPolicy = resourcePolicies.First(t => t.Name == newPolicy.Name && t.MemoryLimitInMegabytes == newPolicy.MemoryLimitInMegabytes && t.CpuLimitInMegahertz == newPolicy.CpuLimitInMegahertz);

                    createdPolicy.Description = "Updated via test";
                    await client.UpdateResourcePolicy(createdPolicy);

                    var updatedPolicy = await client.GetResourcePolicy(createdPolicy.Id);
                    Assert.Equal(createdPolicy.Description, updatedPolicy.Description);
                }
                else
                {
                    throw (new Exception("There was an error creating your resource policy"));
                }

            }
        }

        
    }
}
