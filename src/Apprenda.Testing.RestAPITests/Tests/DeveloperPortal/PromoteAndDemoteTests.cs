using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ExtensionMethods;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Models.DeveloperPortal;
using Xunit;
using Xunit.Abstractions;
namespace Apprenda.Testing.RestAPITests.Tests.DeveloperPortal
{
    public class PromoteAndDemoteTests : ApprendaAPITest
    {


        public PromoteAndDemoteTests(ITestOutputHelper helper) : base(helper)
        {
        }

        /// <summary>
        /// Creates an app, then promotes and demotes it multiple times
        /// </summary>
        /// <param name="smokeTestAppToUse"></param>
        /// <param name="numOfTimes"></param>
        /// <returns></returns>
        [InlineData(AvailableSmokeTestApplications.NoAuth, 10)]
        [Theory]
        public async Task PromoteAndDemoteApplication(AvailableSmokeTestApplications smokeTestAppToUse, int numOfTimes)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var randomVal = new Random(DateTime.Now.Millisecond).Next(10000);
                var alias = smokeTestAppToUse.ToString() + randomVal;
                await DeleteAppIfExists(alias);

                using (var app = await CreateAppIfDoesNotExist(session, smokeTestAppToUse.ToString(), alias))
                {
                    for (var i = 0; i < numOfTimes; i++)
                    {
                        await PromoteAppToSandbox(session, app.AppAlias);

                        await DemoteAppFromSandbox(session, app.AppAlias);
                    }
                }
            }

        }

        [InlineData(AvailableSmokeTestApplications.NoAuth)]
        [Theory]
        public async Task DoTasksWhilePromotingAnApplication_SandboxOnly(AvailableSmokeTestApplications smokeTestAppToUse)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var randomVal = new Random(DateTime.Now.Millisecond).Next(10000);
                var alias = smokeTestAppToUse.ToString() + randomVal;
                await DeleteAppIfExists(alias);

                var client = await session.GetClient();
                using (var app = await CreateAppIfDoesNotExist(session, smokeTestAppToUse.ToString(), alias))
                {
                    var getRes = await client.GetApplication(app.AppAlias);

                    //promote it
                    Assert.NotNull(getRes.CurrentVersion);
                    await client.PromoteVersion(getRes.Alias, getRes.CurrentVersion.Alias,
                        ApplicationVersionStage.Sandbox);

                    var timeTaken = new List<TimeSpan>();

                    getRes = await client.GetApplication(app.AppAlias);
                    while (getRes.IsCurrentlyPromoting())
                    {
                        await BreakStuff(client, getRes, timeTaken);
                        getRes = await client.GetApplication(app.AppAlias);
                    }
                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.NoAuth)]
        [Theory]
        public async Task DoTasksWhilePromotingAnApplication(AvailableSmokeTestApplications smokeTestAppToUse)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var randomVal = new Random(DateTime.Now.Millisecond).Next(10000);
                var alias = smokeTestAppToUse.ToString() + randomVal;
                await DeleteAppIfExists(alias);

                var client = await session.GetClient();
                using (var app = await CreateAppIfDoesNotExist(session, smokeTestAppToUse.ToString(), alias))
                {
                    var getRes = await client.GetApplication(app.AppAlias);

                    //promote it
                    Assert.NotNull(getRes.CurrentVersion);
                    await client.PromoteVersion(getRes.Alias, getRes.CurrentVersion.Alias,
                        ApplicationVersionStage.Sandbox);

                    var timeTaken = new List<TimeSpan>();

                    getRes = await client.GetApplication(app.AppAlias);
                    while (getRes.IsCurrentlyPromoting())
                    {
                        await BreakStuff(client, getRes, timeTaken);
                        getRes = await client.GetApplication(app.AppAlias);
                    }

                    
                    //go to production
                    timeTaken.Clear();

                    await client.PromoteVersion(getRes.Alias, getRes.CurrentVersion.Alias,
                        ApplicationVersionStage.Published);

                    getRes = await client.GetApplication(app.AppAlias);
                    while (getRes.IsCurrentlyPromoting())
                    {
                        await BreakStuff(client, getRes, timeTaken);
                        getRes = await client.GetApplication(app.AppAlias);
                    }
                    
                }
            }
        }
        private static async Task BreakStuff(IApprendaApiClient client, EnrichedApplication getRes, ICollection<TimeSpan> timeTaken)
        {
            var start = DateTime.UtcNow;

            var versions = (await client.GetVersionsForApplication(getRes.Alias)).ToList();
            Assert.NotNull(versions);

            //get the compoenents and other stuff
            //this may 404
            try
            {
                var comps = (await client.GetComponents(getRes.Alias, getRes.CurrentVersion?.Alias)).ToList();
                Assert.NotNull(comps);
            }
            catch (Exception e)
            {
                //validate is 404
                var i = 5;
            }

            var time = DateTime.UtcNow - start;
            timeTaken.Add(time);


        }
    }
}
