using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Models.SOC;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests
{
    public class HealthReportAPITest : ApprendaAPITest
    {
        [InlineData(2)]
        [Theory(Skip = "Long running, not needed for devs now")]
        public async Task CheckHealthReportsStayValidForSetNumberOfMinutes(int numMinutes, int numSecondsBetweenChecks = 20)
        {
            IEnumerable<string> allHostNames;
            //get our host names, we'll be running reports on all of them!
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                var hosts = await client.GetAllHosts();

                allHostNames = hosts.Select(h => h.Name);
            }


            var hostTasks = allHostNames.Select(hn => CycleHealthReportChecks(numMinutes, numSecondsBetweenChecks, hn));

            await Task.WhenAll(hostTasks.ToArray());
        }

        private async Task CycleHealthReportChecks(int numMinutes, int numSecondsBetweenChecks, string hostName)
        {
            var endAt = DateTime.UtcNow.AddMinutes(numMinutes);
            while (DateTime.UtcNow < endAt)
            {
                await LastHealthReportIsHealthy(hostName);
                await Task.Delay(TimeSpan.FromSeconds(numSecondsBetweenChecks));
            }
        }


        [InlineData("")]
        [Theory]
        public async Task LastHealthReportIsHealthy(string hostName)
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.SOC);

                var hosts = await client.GetAllHosts();

                var host = string.IsNullOrWhiteSpace(hostName)
                    ? hosts.FirstOrDefault()
                    : hosts.FirstOrDefault(h => h.Name == hostName);

                Assert.NotNull(host);
                Assert.False(string.IsNullOrWhiteSpace(host.Name));

                //ACT
                var reports = await client.GetHealthReports(host.Name);

                //ASSERT
                Assert.NotNull(reports);

                var lastReport = reports.LastOrDefault();
                Assert.NotNull(lastReport);
                Assert.Equal(lastReport.Outcome, HealthOutcome.Healthy);
                Assert.Equal(lastReport.Result, HealthCheckResultType.Normal);

            }
        }

        public HealthReportAPITest(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
