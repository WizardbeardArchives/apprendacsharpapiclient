using System;
using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Models.DeveloperPortal;
using Xunit;
using Xunit.Abstractions;
using Version = ApprendaAPIClient.Models.DeveloperPortal.Version;

namespace Apprenda.Testing.RestAPITests.Tests.DeveloperPortal
{
    public class EnvironmentalVariablesTests : ApprendaAPITest
    {
        [InlineData(
            "<environmentVariables><environmentvariable name=\"test\" value=\"testVal\"/></environmentVariables>")]
        [InlineData(
            "<environmentVarias><variable name=\"test\" value=\"testVal\"/></environmentVarias>")]
        [InlineData(
            "<environmentVariables><variable name=\"test\" val=\"testVal\"/></environmentVariables>")]
        [Theory]
        public async Task InvalidEnvironmentalVariableXmlIsNotAccepted(string data)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var client = await session.GetClient(ApiPortals.Developer);

                Application firstApp = null;
                Version firstVer = null;
                Component comp = null;
                var apps = await client.GetApplications();
                foreach (var app in apps)
                {
                    var versions = await client.GetVersionsForApplication(app.Alias);

                    firstVer = versions.FirstOrDefault();


                    if (firstVer != null)
                    {
                        var components = await client.GetComponents(app.Alias, firstVer.Alias);
                        comp = components.FirstOrDefault(i => i.Type == "wcfsvc");

                        if (comp != null)
                        {
                            firstApp = app;
                            break;
                        }
                    }

                }

                if (comp != null)
                {
                    var envVariables = await client.GetEnvironmentVariables(firstApp.Alias, firstVer.Alias, comp.Alias);

                    Assert.NotNull(envVariables);
                    Assert.False(string.IsNullOrWhiteSpace(envVariables.Data));

                    var updated = new EnvironmentVariableData
                    {
                        Data = data

                    };

                    var threw = false;
                    try
                    {
                        await client.SetEnvironmentVariable(firstApp.Alias, firstVer.Alias, comp.Alias, updated);
                    }
                    catch (Exception)
                    {
                        threw = true;
                    }

                    Assert.True(threw);
                }
            }
        }

        [InlineData("<environmentVariables><variable name=\"test\" value=\"testVal\"/></environmentVariables>")]
        [InlineData("<environmentVariables><variable name=\"test1\" value=\"testVal1\"/><variable name=\"test2\" value=\"testVal2\"/></environmentVariables>")]
        [InlineData("<environmentVariables><variable name=\"test\" value=\"testVal\"/></environmentVariables>")]
        [Theory]
        public async Task GetAndSetEnvironmentVariablesInXmlForComponent(string data)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var client = await session.GetClient(ApiPortals.Developer);


                Application firstApp = null;
                Version firstVer = null;
                Component comp = null;
                var apps = await client.GetApplications();
                foreach (var app in apps)
                {
                    var versions = await client.GetVersionsForApplication(app.Alias);

                    firstVer = versions.FirstOrDefault();


                    if (firstVer != null)
                    {
                        var components = await client.GetComponents(app.Alias, firstVer.Alias);
                        comp = components.FirstOrDefault(i => i.Type == "wcfsvc");

                        if (comp != null)
                        {
                            firstApp = app;
                            break;
                        }
                    }

                }

                if (comp != null)
                {
                    var envVariables = await client.GetEnvironmentVariables(firstApp.Alias, firstVer.Alias, comp.Alias);

                    Assert.NotNull(envVariables);
                    Assert.False(string.IsNullOrWhiteSpace(envVariables.Data));

                    var updated = new EnvironmentVariableData
                    {
                        Data = data

                    };

                    var posted =
                        await client.SetEnvironmentVariable(firstApp.Alias, firstVer.Alias, comp.Alias, updated);
                    Assert.True(posted);

                    var reget = await client.GetEnvironmentVariables(firstApp.Alias, firstVer.Alias, comp.Alias);

                    Assert.NotNull(reget);

                    var cleanSource = data.Replace(" ", "").Replace("\t", "").Replace(Environment.NewLine, "")
                        .ToLower();
                    var cleanRes = reget.Data.Replace(" ", "").Replace("\t", "").Replace(Environment.NewLine, "")
                        .ToLower();
                    Assert.Equal(cleanSource, cleanRes);

                    //set it back to original value
                    var repost =
                        await client.SetEnvironmentVariable(firstApp.Alias, firstVer.Alias, comp.Alias, envVariables);

                    Assert.True(repost);
                }
            }
        }

        [Fact]
        public async Task GetAndSetEnvironmentVariablesInXmlOverwritesExisting()
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var client = await session.GetClient(ApiPortals.Developer);

                Application firstApp = null;
                Version firstVer = null;
                Component comp = null;
                var apps = await client.GetApplications();
                foreach (var app in apps)
                {
                    var versions = await client.GetVersionsForApplication(app.Alias);

                    firstVer = versions.FirstOrDefault();


                    if (firstVer != null)
                    {
                        var components = await client.GetComponents(app.Alias, firstVer.Alias);
                        comp = components.FirstOrDefault(i => i.Type == "wcfsvc");

                        if (comp != null)
                        {
                            firstApp = app;
                            break;
                        }
                    }

                }

                if (comp != null)
                {
                    var envVariables = await client.GetEnvironmentVariables(firstApp.Alias, firstVer.Alias, comp.Alias);

                    Assert.NotNull(envVariables);
                    Assert.False(string.IsNullOrWhiteSpace(envVariables.Data));

                    var updated = new EnvironmentVariableData
                    {
                        Data =
                            "<environmentVariables><variable name=\"exists\" value=\"existVal\"/></environmentVariables>"

                    };

                    var posted =
                        await client.SetEnvironmentVariable(firstApp.Alias, firstVer.Alias, comp.Alias, updated);
                    Assert.True(posted);

                    var reget = await client.GetEnvironmentVariables(firstApp.Alias, firstVer.Alias, comp.Alias);

                    Assert.NotNull(reget);

                    Assert.Contains("exists", reget.Data);
                    Assert.Contains("existVal", reget.Data);

                    //set again
                    updated = new EnvironmentVariableData
                    {
                        Data = "<environmentVariables><variable name=\"new\" value=\"newVal\"/></environmentVariables>"

                    };

                    posted = await client.SetEnvironmentVariable(firstApp.Alias, firstVer.Alias, comp.Alias, updated);
                    Assert.True(posted);

                    reget = await client.GetEnvironmentVariables(firstApp.Alias, firstVer.Alias, comp.Alias);

                    Assert.NotNull(reget);
                    Assert.DoesNotContain("exists", reget.Data);
                    Assert.DoesNotContain("existVal", reget.Data);
                    Assert.Contains("new", reget.Data);
                    Assert.Contains("newVal", reget.Data);

                    //set it back to original value
                    var repost =
                        await client.SetEnvironmentVariable(firstApp.Alias, firstVer.Alias, comp.Alias, envVariables);

                    Assert.True(repost);
                }
            }
        }

        public EnvironmentalVariablesTests(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
