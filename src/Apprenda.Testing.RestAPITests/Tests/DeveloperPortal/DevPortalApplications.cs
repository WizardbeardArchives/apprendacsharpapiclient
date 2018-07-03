using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Models.DeveloperPortal;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests
{
    /// <summary>
    /// Because most of our tests do this, this is likely not needed, however it's good to explicitly test it was well
    /// </summary>
    public class DevPortalApplications : ApprendaAPITest
    {
        public DevPortalApplications(ITestOutputHelper helper) : base(helper)
        {
        }

        [InlineData(10)]
        [Theory]
        public async Task GetApps_Timed(int numReps)
        {
            var times = new List<TimeSpan>();
            using (var session = await StartSession())
            {
                var client = await session.GetClient();

                for (var i = 0; i < numReps; i++)
                {
                    var start = DateTime.UtcNow;
                    var apps = await client.GetApplications();
                    var end = DateTime.UtcNow;

                    times.Add(end - start);
                    Assert.NotNull(apps);
                }
            }

            var avg = times.Average(ts => ts.Ticks);
            Console.WriteLine(avg);

        }

        [InlineData(AvailableSmokeTestApplications.HelloWorld)]
        [Theory]
        public async Task ApplicationIsCreatedOnPlatform(AvailableSmokeTestApplications smokeTestAppToUse)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var randomVal = new Random(DateTime.Now.Millisecond).Next(10000);
                var alias = smokeTestAppToUse.ToString() + randomVal;
                await DeleteAppIfExists(alias);

                var href = session.ConnectionSettings.AppsUrl + $"/developer/api/v1/apps/{alias}";
                var app = new Application(href)
                {
                    Alias = alias,
                    Description = $"Created by Smoke Tests {randomVal}",
                    Name = $"Created by Smoke Tests {randomVal}",
                    Href = href
                };

                var client = await session.GetClient(ApiPortals.Developer);
                var res = await client.PostApp(app);

                Assert.True(res);

                //check it exists!
                var getRes = await client.GetApplication(app.Alias);

                Assert.NotNull(getRes);
                Assert.Equal(app.Alias.ToLower(), getRes.Alias.ToLower());
                Assert.Equal(app.Description, getRes.Description);
                Assert.Equal(app.Name, getRes.Name);
                Assert.Equal(app.Href.ToLower(), getRes.Href.ToLower());
                Assert.NotNull(getRes.CurrentVersion);

                //check adding the archive
                var archive = await GetArchiveForSmokeTestApplication(smokeTestAppToUse.ToString());
                Assert.NotNull(archive);

                var rc = await client.PatchVersion(getRes.Alias, getRes.CurrentVersion.Alias, true,
                    archive.ArchiveContents);

                Assert.True(ReportCardStatus.Succeeded == rc.Status || ReportCardStatus.Started == rc.Status);

                await DeleteAppIfExists(alias);
            }
        }

        /// <summary>
        /// Tests promotion.  For now this is just useful for applications that don't require entitlement defs
        /// </summary>
        /// <param name="smokeTestAppToUse"></param>
        /// <returns></returns>
        [InlineData(AvailableSmokeTestApplications.TimeCard)]
        [Theory]
        public async Task ApplicationIsCreatedOnPlatformAndPromotes(AvailableSmokeTestApplications smokeTestAppToUse)
        {
            using (var session = await StartSession())
            {
                var randomVal = new Random(DateTime.Now.Millisecond).Next(10000);
                var alias = smokeTestAppToUse.ToString() + randomVal;
                await DeleteAppIfExists(alias);

                var href = session.ConnectionSettings.AppsUrl + $"/developer/api/v1/apps/{alias}";
                var app = new Application(href)
                {
                    Alias = alias,
                    Description = $"Created by Smoke Tests {randomVal}",
                    Name = $"Created by Smoke Tests {randomVal}",
                    Href = href
                };

                var client = await session.GetClient(ApiPortals.Developer);
                var res = await client.PostApp(app);

                Assert.True(res);

                //check it exists!
                var getRes = await client.GetApplication(app.Alias);

                Assert.NotNull(getRes);
                Assert.Equal(app.Alias.ToLower(), getRes.Alias.ToLower());
                Assert.Equal(app.Description, getRes.Description);
                Assert.Equal(app.Name, getRes.Name);
                Assert.Equal(app.Href.ToLower(), getRes.Href.ToLower());
                Assert.NotNull(getRes.CurrentVersion);

                //check adding the archive
                var archive = await GetArchiveForSmokeTestApplication(smokeTestAppToUse.ToString());
                Assert.NotNull(archive);

                var rc = await client.PatchVersion(getRes.Alias, getRes.CurrentVersion.Alias, true,
                    archive.ArchiveContents);

                Assert.Equal(rc.Status, ReportCardStatus.Succeeded);

                var promoRes = await client.PromoteVersion(getRes.Alias, getRes.CurrentVersion.Alias,
                    ApplicationVersionStage.Sandbox);

                Assert.True(promoRes);

                await DeleteAppIfExists(alias);
            }
        }

        [Fact]
        public async Task ApplicationsExistOnPlatformAndHaveVersion()
        {
            using (var session = await StartAdminSession())
            {
                var client = await session.GetClient(ApiPortals.Developer);

                var apps = (await client.GetApplications()).ToList();

                Assert.True(apps.Any());
                var firstApplication = apps.First();

                Assert.False(string.IsNullOrWhiteSpace(firstApplication.Alias));

                var reget = await client.GetApplication(firstApplication.Alias);

                Assert.NotNull(reget);

                var versions = (await client.GetVersionsForApplication(firstApplication.Alias)).ToList();

                Assert.NotNull(versions);
                Assert.True(versions.Any());

                var singleVersion = await client.GetVersion(firstApplication.Alias, versions.First().Alias);

                Assert.NotNull(singleVersion);
                Assert.Equal(versions.First().Alias, singleVersion.Alias);
            }
        }
    }
}
