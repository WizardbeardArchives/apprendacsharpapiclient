using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Models.DeveloperPortal;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.DeveloperPortal
{
    public class DeveloperPortalPlanRetrieval : ApprendaAPITest
    {
        /// <summary>
        /// Tests that we can get plans, and get them by ID after.  Note this will also pass if no plans exist
        /// </summary>
        /// <returns></returns>
        [InlineData(AvailableSmokeTestApplications.TaskrPlans)]
        [Theory]
        public async Task RetrievePlans(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                IApprendaDeveloperPortalApiClient client = await session.GetClient();
                var alias = smokeTestApplication.ToString();
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToSandbox(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await client.GetPlans(app.Alias, app.CurrentVersion.Alias);
                    foreach (var foundPlan in plans.Where(p => p != null))
                    {
                        var byId = await client.GetPlan(app.Alias, app.CurrentVersion.Alias, foundPlan.Id);

                        Assert.NotNull(byId);
                        Assert.Equal(foundPlan.Name, byId.Name);
                        Assert.NotNull(foundPlan.Href);
                        Assert.Equal(foundPlan.EntitlementDefintionType, byId.EntitlementDefintionType);
                        Assert.Equal(foundPlan.EntitlementName, byId.EntitlementName);
                        Assert.Equal(foundPlan.Href, byId.Href);
                        Assert.Contains(foundPlan.Id.ToString(), byId.Href);
                    }

                }
            }
        }


        [InlineData(AvailableSmokeTestApplications.EnvyMTWithPlansDefined)]
        [Theory]
        public async Task BothAccountAndUserPlansRetreive(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession())
            {
                IApprendaDeveloperPortalApiClient client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 10) + "plans";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToSandbox(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = (await client.GetPlans(app.Alias, app.CurrentVersion.Alias)).ToList();

                    Assert.True(plans.Any(p => p.EntitlementDefintionType == EntitlementDefintionType.AccountWide));
                }
            }
        }

        public DeveloperPortalPlanRetrieval(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
