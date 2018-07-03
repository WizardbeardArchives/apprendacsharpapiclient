using System;
using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.DeveloperPortal
{
    public class DeveloperPortalUsersAndGroups : ApprendaAPITest
    {
        [Fact]
        public async Task GetAllGroupsAndGetByIds()
        {
            using (var session = await StartAdminSession())
            {
                var client = await session.GetClient(ApiPortals.Developer);

                var allApps = await client.GetApplications();

                string appAlias = null;
                string verAlias = null;
                foreach (var app in allApps)
                {
                    try
                    {
                        var groups = await client.GetGroupsAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias);

                        if (groups.Any())
                        {
                            appAlias = app.Alias;
                            verAlias = app.CurrentVersion.Alias;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }


                if (appAlias != null)
                {
                    var groups = await client.GetGroupsAuthZSubscribedTo(appAlias, verAlias);
                    foreach (var group in groups)
                    {
                        var individ = await client.GetGroupAuthZSubscribedTo(appAlias, verAlias, group.Id);

                        Assert.NotNull(individ);
                        Assert.Equal(group.Name, individ.Name);
                        Assert.Equal(group.Description, individ.Description);
                        Assert.Equal(group.Id, individ.Id);
                        Assert.Equal(group.Href, individ.Href);
                    }
                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.TimeCard)]
        [Theory]
        public async Task QueryingForUsersWithAppInDefintionGivesError(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartAdminSession())
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication + "deferr";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    var app = await client.GetApplication(createApp.AppAlias);

                    await PromoteAppToSandbox(session, app.Alias);
                    Assert.NotNull(app);
                    Assert.Equal("definition", app.CurrentVersion.Stage.ToLower());

                    var threw = false;
                    try
                    {
                        var users = await client.GetUsersAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias);
                        var first = users.FirstOrDefault();
                    }
                    catch (Exception e)
                    {
                        threw = true;
                        Assert.False(string.IsNullOrWhiteSpace(e.Message));
                    }

                    Assert.True(threw);
                }
            }
        }

        [Fact]
        public async Task GetAllUsersAndGetByIds()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient(ApiPortals.Developer);

                var allApps = await client.GetApplications();

                string appAlias = null;
                string verAlias = null;
                foreach (var app in allApps)
                {
                    try
                    {
                        var users = await client.GetUsersAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias);

                        if (users.Any())
                        {
                            appAlias = app.Alias;
                            verAlias = app.CurrentVersion.Alias;
                            break;
                        }
                    }
                    catch(Exception) { }
                }


                if (appAlias != null)
                {
                    var foundUsers = await client.GetUsersAuthZSubscribedTo(appAlias, verAlias);
                    foreach (var user in foundUsers)
                    {
                        var individ = await client.GetUserAuthZSubscribedTo(appAlias, verAlias, user.Identifier);

                        Assert.NotNull(individ);
                        Assert.Equal(user.FirstName, individ.FirstName);
                        Assert.Equal(user.LastName, individ.LastName);
                        Assert.Equal(user.Identifier, individ.Identifier);
                        Assert.Equal(user.Href, individ.Href);
                    }
                }
            }
        }

        public DeveloperPortalUsersAndGroups(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
