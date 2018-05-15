using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Models.DeveloperPortal;
using ApprendaAPIClient.Models.DeveloperPortal.Subscriptions;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests.MultiplePortalTests
{
    public class UsersRolesAndSubscriptionsForNewApplication : ApprendaAPITest
    {
        [InlineData(AvailableSmokeTestApplications.TaskrPlans)]
        [Theory]
        public async Task SubscribeUserMultiTenantInSandbox(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString();
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToSandbox(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.First(p => p.EntitlementDefintionType == EntitlementDefintionType.UserBased);

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    var subscriptionRequest = new SubscriptionRequest
                    {
                        NumberOfSubscriptions = 2,
                        PlanName = plan.Name,
                        EntitlementDefintionType = plan.EntitlementDefintionType,
                        EntitlementName = plan.EntitlementName
                    };

                    await client.CreateMultiTenantSubscription(app.Alias,
                        app.CurrentVersion.Alias, tenant, subscriptionRequest);

                    //retrieve the subscriptions and plans, ensure they exist!
                    var gotten = await client.GetSubscriptions(app.Alias, app.CurrentVersion.Alias, tenant);

                    Assert.NotNull(gotten);

                    foreach (var got in gotten)
                    {
                        var byLoc = await client.GetSubscription(app.Alias, app.CurrentVersion.Alias, tenant,
                            got.Locator);

                        Assert.Equal(got.Description, byLoc.Description);
                        Assert.Equal(got.Locator, byLoc.Locator);

                        var delRes =
                            await client.DeleteSubscription(app.Alias, app.CurrentVersion.Alias, tenant, got.Locator);

                        Assert.True(delRes);


                        byLoc = await client.GetSubscription(app.Alias, app.CurrentVersion.Alias, tenant,
                            got.Locator);

                        Assert.Equal(SubscriptionStatus.Cancelled, byLoc.Status);

                    }
                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.TaskrPlans)]
        [Theory(Skip = "Currently failing in most cases")]
        public async Task SubscribeUserMultiTenantInPublished(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString();
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToPublished(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.First(p => p.EntitlementDefintionType == EntitlementDefintionType.UserBased);

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    var subscriptionRequest = new SubscriptionRequest
                    {
                        NumberOfSubscriptions = 2,
                        PlanName = plan.Name,
                        EntitlementDefintionType = plan.EntitlementDefintionType,
                        EntitlementName = plan.EntitlementName
                    };

                    await client.CreateMultiTenantSubscription(app.Alias,
                        app.CurrentVersion.Alias, tenant, subscriptionRequest);

                    //retrieve the subscriptions and plans, ensure they exist!
                    var gotten = (await client.GetSubscriptions(app.Alias, app.CurrentVersion.Alias, tenant)).ToList();

                    Assert.NotNull(gotten);

                    Assert.False(gotten.Any(s => s.Status == SubscriptionStatus.Dead));
                    Assert.False(gotten.Any(s => s.Status == SubscriptionStatus.Swapped));
                    foreach (var got in gotten)
                    {
                        var byLoc = await client.GetSubscription(app.Alias, app.CurrentVersion.Alias, tenant,
                            got.Locator);

                        Assert.Equal(got.Description, byLoc.Description);
                        Assert.Equal(got.Locator, byLoc.Locator);

                        var delRes =
                            await client.DeleteSubscription(app.Alias, app.CurrentVersion.Alias, tenant, got.Locator);

                        Assert.True(delRes);


                        byLoc = await client.GetSubscription(app.Alias, app.CurrentVersion.Alias, tenant,
                            got.Locator);

                        Assert.True(byLoc.Status == SubscriptionStatus.Cancelled);

                    }
                }
            }
        }
        [InlineData(AvailableSmokeTestApplications.EnvyMTWithPlansDefined)]
        [Theory]
        public async Task SubscribingToAccountInSandboxFails(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 10) + "mtsubs";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToSandbox(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.First(p => p.EntitlementDefintionType == EntitlementDefintionType.AccountWide);

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    var subscriptionRequest = new SubscriptionRequest
                    {
                        NumberOfSubscriptions = 2,
                        PlanName = plan.Name,
                        EntitlementDefintionType = plan.EntitlementDefintionType,
                        EntitlementName = plan.EntitlementName
                    };

                    var thrown = false;
                    try
                    {
                        await client.CreateMultiTenantSubscription(app.Alias,
                            app.CurrentVersion.Alias, tenant, subscriptionRequest);
                    }
                    catch (Exception e)
                    {
                        Assert.Contains("Multiple subscriptions are not valid for Account subscription types", e.Message);
                        thrown = true;
                    }

                    Assert.True(thrown);
                  
                }
            }
        }


        [InlineData(AvailableSmokeTestApplications.TaskrPlansAuthorization)]
        [Theory]
        public async Task SubscribeUserAuthZFailsOnSandbox(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 8) + "usubsandbox";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToSandbox(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.First();

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    var userId = session.ConnectionSettings.UserLogin.UserName;

                    var threw = false;
                    try
                    {
                        await client.CreateAuthZUserSubscription(app.Alias, app.CurrentVersion.Alias,
                            new List<string> { userId }, plan.Name);
                    }
                    catch (Exception e)
                    {
                        Assert.Contains("published", e.Message);
                        threw = true;
                    }

                    Assert.True(threw);

                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.TaskrPlansAuthorization)]
        [Theory]
        public async Task SubscribeUserAuthZ(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession(TestIsolationLevel.CompletelyIsolated))
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 10) + "usubs";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToPublished(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.First();

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    var userId = session.ConnectionSettings.UserLogin.UserName;

                    await client.CreateAuthZUserSubscription(app.Alias, app.CurrentVersion.Alias,
                        new List<string> { userId }, plan.Name);

                    //retrieve to check
                    var getUser = await client.GetUserAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias, userId);

                    Assert.NotNull(getUser);
                    Assert.Equal(userId, getUser.Identifier);

                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.TaskrPlansAuthorization)]
        [Theory]
        public async Task SubscribeUserAuthZAndCannotDeleteSelf(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession(TestIsolationLevel.IsolatedApplication))
            {
                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 10) + "self";
                using (var createApp = await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToPublished(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.First();

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    var userId = session.ConnectionSettings.UserLogin.UserName;

                    try
                    {
                        await client.CreateAuthZUserSubscription(app.Alias, app.CurrentVersion.Alias,
                            new List<string> {userId}, plan.Name);


                        //retrieve to check
                        var getUser =
                            await client.GetUserAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias, userId);

                        Assert.NotNull(getUser);

                        //attempt to delete the user
                        var del = await client.RemoveAuthZUserFromApplication(app.Alias, app.CurrentVersion.Alias,
                            new List<string> {userId});

                        Assert.False(del);
                    }
                    catch (Exception e)
                    {
                        Assert.True(e.Message.Contains("user could not be added"));
                        //means we couldn't add, what to do?
                    }


                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.TaskrPlansAuthorization)]
        [Theory]
        public async Task SubscribeGroupAuthZ(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession(TestIsolationLevel.IsolatedApplication))
            {
                var settings = session.ConnectionSettings;
                if (settings.EnvironmentFeaturesAvailable != null && settings.EnvironmentFeaturesAvailable.IsExternalUserStore)
                {
                    var groupId = settings.EnvironmentInformation.EUSGroupId;

                    var client = await session.GetClient();
                    var alias = smokeTestApplication.ToString().Substring(0, 10) + "gsubs";
                    using (var createApp =
                        await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                    {
                        await PromoteAppToPublished(session, alias);
                        var app = await client.GetApplication(createApp.AppAlias);

                        Assert.NotNull(app);
                        var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                        var plan = plans.First();

                        //get the tenant
                        var tenants = await client.GetTenants();
                        Assert.NotNull(tenants);

                        var tenant = tenants.FirstOrDefault();
                        Assert.NotNull(tenant);

                        //make sure we're not already subscribed
                        try
                        {
                            var group = await client.GetGroupAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias, groupId);
                            Assert.Null(group);
                        }
                        catch (Exception e)
                        {
                            Assert.False(string.IsNullOrWhiteSpace(e.Message));
                        }


                        await client.CreateAuthZGroupSubscription(app.Alias, app.CurrentVersion.Alias,
                            new List<string> { groupId }, plan.Name);

                        //retrieve to check
                        var getGroups = await client.GetGroupsAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias);

                        Assert.NotNull(getGroups);
                        Assert.True(getGroups.Any());

                        var getGroup = await client.GetGroupAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias, groupId);

                        Assert.NotNull(getGroup);
                        Assert.Equal(groupId, getGroup.Id);

                        //remove the group
                        var del = await client.RemoveAuthZGroupFromApplication(app.Alias, app.CurrentVersion.Alias,
                            new List<string> { groupId }, plan.Name);

                        Assert.True(del);

                        //make sure we're gone
                        var threw = false;
                        try
                        {
                            var group = await client.GetGroupAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias, groupId);
                            Assert.Null(group);
                        }
                        catch (Exception)
                        {
                            threw = true;

                        }

                        Assert.True(threw);
                    }
                }
            }
        }

        [InlineData(AvailableSmokeTestApplications.TimeCard)]
        [Theory]
        public async Task NonAuthZAppsThrowErrorOnGetGroups(AvailableSmokeTestApplications smokeTestApplication)
        {
            using (var session = await StartSession())
            {
                var groupId = "lalalala";

                var client = await session.GetClient();
                var alias = smokeTestApplication.ToString().Substring(0, 6) + "noauthz";
                using (var createApp =
                    await CreateAppIfDoesNotExist(session, smokeTestApplication.ToString(), alias))
                {
                    await PromoteAppToPublished(session, alias);
                    var app = await client.GetApplication(createApp.AppAlias);

                    Assert.NotNull(app);
                    var plans = await ((IApprendaDeveloperPortalApiClient)client).GetPlans(app.Alias, app.CurrentVersion.Alias);

                    var plan = plans.FirstOrDefault();

                    //get the tenant
                    var tenants = await client.GetTenants();
                    Assert.NotNull(tenants);

                    var tenant = tenants.FirstOrDefault();
                    Assert.NotNull(tenant);

                    //make sure we're not already subscribed
                    try
                    {
                        var group = await client.GetGroupAuthZSubscribedTo(app.Alias, app.CurrentVersion.Alias, groupId);
                        Assert.Null(group);
                    }
                    catch (Exception e)
                    {
                        Assert.False(string.IsNullOrWhiteSpace(e.Message));
                    }

                    var threw = false;
                    try
                    {
                        await client.CreateAuthZGroupSubscription(app.Alias, app.CurrentVersion.Alias,
                            new List<string> {groupId}, plan?.Name ?? "noPlan");
                    }
                    catch (Exception e)
                    {
                        Assert.Contains("authorization enabled", e.Message);
                        threw = true;
                    }

                    Assert.True(threw);
                }
            }
        }

        public UsersRolesAndSubscriptionsForNewApplication(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
