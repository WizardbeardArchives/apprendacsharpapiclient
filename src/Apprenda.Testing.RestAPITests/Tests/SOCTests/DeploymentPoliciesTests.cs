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
    public class DeploymentPoliciesTests : ApprendaAPITest
    {
        public DeploymentPoliciesTests(ITestOutputHelper helper) : base(helper)
        {
        }

        [Fact]
        public async Task RetrieveAllDeploymentPolicies()
        {
            using (var session = await StartSession())
            {
             var client = await session.GetClient(ApiPortals.SOC);

                var deps = (await client.GetDeploymentPolicies()).ToList();

                Assert.NotNull(deps);
                Assert.True(deps.Any());
                
                foreach (var dep in deps)
                {
                    var byId = await client.GetDeploymentPolicy(dep.id.Value);

                    Assert.NotNull(byId);
                    Assert.Equal(dep.objectType, byId.objectType);
                }
            }
        }

        [Fact]
        public async Task CreateDeploymentPolicy()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                DeploymentPolicy newPolicy = new DeploymentPolicy()
                {                    
                    name="TestPolicy",
                    description="TestPolicyDescription",
                    isActive = false,
                    appliesToSandbox = true,
                    appliesToPublished = true,
                    objectType =  "Applications",
                    customPropertyName = "DevelopmentTeamAlias",
                    customPropertyDisplayName = "Development Team Alias",
                    policyApplicability="Must",
                    policyCondition = "ContainsAny",
                    priority=1              
                };

                var response =  client.CreateDeploymentPolicy(newPolicy).Result;
                       
                Assert.NotNull(response);
                Assert.Equal("TestPolicy", response.name);

                var createdPolicy = client.GetDeploymentPolicy(response.id.Value).Result;
                Assert.Equal("TestPolicy", createdPolicy.name);

                CleanUpPolicies(response.id.Value);
            }
        }

        [Fact]
        public async Task UpdateDeploymentPolicy()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                DeploymentPolicy newPolicy = new DeploymentPolicy()
                {
                    name = "TestPolicy",
                    description = "TestPolicyDescription",
                    isActive = false,
                    appliesToSandbox = true,
                    appliesToPublished = true,
                    objectType = "Applications",
                    customPropertyName = "DevelopmentTeamAlias",
                    customPropertyDisplayName = "Development Team Alias",
                    policyApplicability = "Must",
                    policyCondition = "ContainsAny",
                    priority = 1
                };

                var newPolicyResponse = client.CreateDeploymentPolicy(newPolicy).Result;

                Assert.NotNull(newPolicyResponse);
                Assert.Equal("TestPolicy", newPolicyResponse.name);

                newPolicyResponse.name = "UpdatedTestPolicy";

                await client.UpdateDeploymentPolicy(newPolicyResponse.id.Value, newPolicyResponse);

                var updatedPolicy = client.GetDeploymentPolicy(newPolicyResponse.id.Value).Result;
                Assert.Equal("UpdatedTestPolicy", updatedPolicy.name);
                CleanUpPolicies(updatedPolicy.id.Value);
            }
            
        }

        [Fact]
        public async Task DeleteDeploymentPolicy()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                DeploymentPolicy newPolicy = new DeploymentPolicy()
                {
                    name = "TestPolicy",
                    description = "TestPolicyDescription",
                    isActive = false,
                    appliesToSandbox = true,
                    appliesToPublished = true,
                    objectType = "Applications",
                    customPropertyName = "DevelopmentTeamAlias",
                    customPropertyDisplayName = "Development Team Alias",
                    policyApplicability = "Must",
                    policyCondition = "ContainsAny",
                    priority = 1
                };

                var response = client.CreateDeploymentPolicy(newPolicy).Result;

                Assert.NotNull(response);
                Assert.Equal("TestPolicy", response.name);

                var policyDeletion = client.DeleteDeploymentPolicy(response.id.Value).Result;
                if(policyDeletion)
                {
                    try
                    {
                        var task = client.GetDeploymentPolicy(response.id.Value);
                        task.Wait();
                    }
                    catch(System.AggregateException ex)
                    {
                        System.Net.Http.HttpRequestException innerEx = (System.Net.Http.HttpRequestException)ex.InnerException;
                        Assert.IsType<System.Net.Http.HttpRequestException>(innerEx);
                        Assert.Contains("404 (Not Found)", innerEx.Message);
                    }
                }   
                
            }

        }

        private void CleanUpPolicies(int id)
        {
            using (var session = StartSession().Result)
            {
                var client = session.GetClient(ApiPortals.SOC).Result;
                var result = client.DeleteDeploymentPolicy(id).Result;
                
            }
        }


    }
}
