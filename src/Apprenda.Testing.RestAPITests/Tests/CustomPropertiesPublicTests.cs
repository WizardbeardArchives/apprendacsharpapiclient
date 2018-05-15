using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Models.SOC;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests
{
    public class CustomPropertiesPublicTests : ApprendaAPITest
    {
        [Fact]
        public async Task GetSingleThatDoesNotExist()
        {
            // Verifies proper behavior of APPRENDA-22264
            using (var session = await StartSession())
            {
                const int id = 999999;
                var client = await session.GetClient(ApiPortals.SOC);

                var caught = false;
                try
                {
                    var res = await client.GetCustomProperty(id);
                }
                catch (HttpRequestException e)
                {
                    caught = true;
                    Assert.Contains("404", e.Message);
                }

                Assert.True(caught);
            }
        }

        [Fact]
        public async Task GetManyAndThenById()
        {
            using (var session = await StartSession())
            {
                //Assemble
                var client = await session.GetClient(ApiPortals.SOC);

                //ACT
                var res = await client.GetAllCustomProperties();

                //ASSERT
                var first = res.First();

                var id = first.Id;

                var singleRes = await client.GetCustomProperty(id);

                Assert.NotNull(singleRes);
                Assert.NotNull(singleRes.ValueOptions.PossibleValues);
            }
        }

        
        [Fact]
        public async Task TestEndToEnd()
        {
            // This test is also consumed by the ExportAuditLogTests to ensure there are audit log entries to export.
            using (var session = await StartSession())
            {
                var created = await CreateAndGetCustomProperty(session);
                var id = created.Id;
                await SearchCustomProperties(session, id);
                await UpdateCustomProperty(session, id);
                await DeleteCustomProperty(session, id);
            }
        }

        // ReSharper disable once UnusedParameter.Local
        private static async Task SearchCustomProperties(IApprendaTestSession session, int id)
        {
            var client = await session.GetClient(ApiPortals.SOC);
            var res = await client.GetAllCustomProperties();

            //ASSERT
            Assert.NotNull(res);
            Assert.True(res.Any(x => x.Id == id));
        }

        private static async Task UpdateCustomProperty(IApprendaTestSession session, int id)
        {
            var individClient = await session.GetClient(ApiPortals.SOC);

            var got = await individClient.GetCustomProperty(id);

            var updatable = new CustomPropertyUpdate(got);
            updatable.ValueOptions.DefaultValues.Remove("three");
            updatable.ValueOptions.PossibleValues.Remove("three");
            updatable.ValueOptions.PossibleValues.Add("five");
            updatable.DeletedValueReplacements = new Dictionary<string, string>
            {
                { "three", "five" }
            };

            updatable.Applicability.Applications = null;
            updatable.DeveloperOptions = null;

            var putresult = await individClient.UpdateCustomProperty(updatable);
            Assert.True(putresult);

            var cprop = await individClient.GetCustomProperty(id);
            Assert.Null(cprop.Applicability.Applications);
            Assert.False(cprop.DeveloperOptions.IsVisible);
            Assert.False(cprop.DeveloperOptions.VisibilityOptions.IsEditableByDeveloper);
            Assert.False(cprop.DeveloperOptions.VisibilityOptions.IsRequiredForDeployment);
            Assert.Contains("five", cprop.ValueOptions.PossibleValues);
            Assert.False(cprop.ValueOptions.DefaultValues.Contains("three"));
            Assert.False(cprop.ValueOptions.PossibleValues.Contains("three"));
        }

        private static async Task DeleteCustomProperty(IApprendaTestSession session, int id)
        {
            var individClient = await session.GetClient(ApiPortals.SOC);

            var deletion = await individClient.DeleteCustomProperty(id);
            Assert.True(deletion);
        }


        internal static async Task<CustomProperty> CreateAndGetCustomProperty(IApprendaTestSession session)
        {
            // Assemble
            var client = await session.GetClient(ApiPortals.SOC);
               
            var suffix = new Random().Next(10000);

            var customProperty = new CustomProperty
            {
                Name = $"test{suffix}",
                DisplayName = $"Testing {suffix}",
                Applicability = new CustomPropertyApplicabilityOptionCollection
                {
                    Applications = new CustomPropertyApplicationOptions
                    {
                        AllowMultipleValues = true,
                        IsApplied = true,
                        IsComponentLevel = false,
                        ApplicationComponentLevelOptions = new CustomPropertyApplicationComponentOptions
                        {
                            Databases = true,
                            JavaWebApplications = true,
                            LinuxServices = true,
                            UserInterfaces = true,
                            WindowsServices = true
                        }
                    },
                    ComputeServers = new CustomPropertyApplicabilityOption
                    {
                        IsApplied = true,
                        AllowMultipleValues = true,
                    },
                    DatabaseServers = new CustomPropertyApplicabilityOption
                    {
                        IsApplied = true,
                        AllowMultipleValues = true,
                    },
                    ResourcePolicies = new CustomPropertyApplicabilityOption
                    {
                        IsApplied = true,
                        AllowMultipleValues = true
                    },
                    StorageQuotas = new CustomPropertyApplicabilityOption
                    {
                        IsApplied = true,
                        AllowMultipleValues = true
                    }
                },
                DeveloperOptions = new CustomPropertyDeveloperOptions
                {
                    IsVisible = true,
                    VisibilityOptions = new VisibilityOptions
                    {
                        IsEditableByDeveloper = true,
                        IsRequiredForDeployment = true
                    }
                },
                ValueOptions = new CustomPropertyValueOptions
                {
                    AllowCustomValues = true,
                    PossibleValues = new List<string> { "one", "two", "three" },
                    DefaultValues = new List<string> { "two", "three" }
                }
            };

            // Act
            var responseProperty = await client.CreateCustomProperty(customProperty);

            // Assert
            Assert.Equal(customProperty.Name, responseProperty.Name);
            Assert.NotEqual(0, responseProperty.Id);
            return responseProperty;
        }

        public CustomPropertiesPublicTests(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
