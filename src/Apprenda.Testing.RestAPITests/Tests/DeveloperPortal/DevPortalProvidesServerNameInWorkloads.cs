namespace Apprenda.Testing.RestAPITests.Tests.DeveloperPortal
{
    public class DevPortalProvidesServerNameInWorkloads : ApprendaAPITest
    {
        /*
        [Fact]
        public async Task WorkloadsHaveServerNamePopulated()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.Developer);

                //find an app with workloads, with a DB name if possible
                var apps = await client.GetApplications();
                foreach (var app in apps)
                {
                    var versions = await client.GetVersionsForApplication(app.Alias);

                    foreach (var version in versions)
                    {
                        var workloads = (await client.GetDeveloperPortalWorkloads(app.Alias, version.Alias))
                            .OrderByDescending(wl => wl.Component.Type == ComponentType.Database.ToString())
                            .ToList();

                        if (workloads.Any())
                        {
                            var workload = workloads.First();
                            //test for server
                            Assert.False(string.IsNullOrEmpty(workload.Server));
                            return;
                        }
                    }
                }
            }

            Assert.True(false, "No apps with workloads found to test");
        }
        */
    }
}
