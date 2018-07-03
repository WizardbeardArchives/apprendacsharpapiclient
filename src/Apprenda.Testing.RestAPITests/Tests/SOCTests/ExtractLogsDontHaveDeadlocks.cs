using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.Services.Implementation;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Models.DeveloperPortal;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class ExtractLogsDontHaveDeadlocks : ApprendaAPITest
    {
        [InlineData(1)]
        [InlineData(10)]
        [Theory]
        public async Task CheckForDeadlocksOnResourceBundleTable(int numTimes)
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();

                var logScraper = new SOCLogScraper(client);

                var appAlias = string.Empty;
                var versionAlias = string.Empty;
                var comp = await FindCertificateHoldingComponent(client);

                for (var i = 0; i < numTimes; i++)
                {
                    if (comp != null)
                    {
                        await client.GetCertificatesForComponent(appAlias, versionAlias, comp.Alias);
                    }
                    await logScraper.AssertTableIsNotDeadlocked("ResourceBundle");
                }

            }
        }

        private static async Task<Component> FindCertificateHoldingComponent(IApprendaApiClient client)
        {
            Component comp = null;
            string appAlias;
            string versionAlias;
            var apps = await client.GetApplications();
            foreach (var tryApp in apps)
            {
                if (tryApp.CurrentVersion != null)
                {
                    var components = await client.GetComponents(tryApp.Alias, tryApp.CurrentVersion.Alias);

                    foreach (var tryComp in components)
                    {
                        try
                        {
                            var cert = await client.GetCertificatesForComponent(tryApp.Alias,
                                tryApp.CurrentVersion.Alias, tryComp.Alias);

                            if (cert != null)
                            {
                                comp = tryComp;
                                appAlias = tryApp.Alias;
                                versionAlias = tryApp.CurrentVersion.Alias;

                                break;
                            }
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
            }

            return comp;
        }

        public ExtractLogsDontHaveDeadlocks(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
