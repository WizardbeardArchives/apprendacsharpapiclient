using System.Threading.Tasks;
using ApprendaAPIClient.Models.SOC;
using Xunit;

namespace Apprenda.Testing.RestAPITests.Tests.SOCTests
{
    public class RegistrySettings : ApprendaAPITest
    {
        [Fact]
        public async Task GetRegistrySettings()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();

                var allSettings = await client.GetRegistrySettings();

                var hadSome = false;

                foreach (var setting in allSettings)
                {
                    hadSome = true;

                    var getIndivid = await client.GetRegistrySetting(setting.Name);

                    Assert.Equal(setting.Name, getIndivid.Name);
                    Assert.Equal(setting.Value, getIndivid.Value);
                    Assert.Equal(setting.IsEncrypted, getIndivid.IsEncrypted);
                    Assert.Equal(setting.IsReadOnly, getIndivid.IsReadOnly);
                    Assert.Equal(setting.Href, getIndivid.Href);
                }

                Assert.True(hadSome);
            }
        }

        [Fact]
        public async Task BasicRegistrySettingsCRUD()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();

                //create
                var regSetting = new RegistrySetting
                {
                    Name = "testSetting",
                    Value = "testVal",
                    IsEncrypted = false,
                    IsReadOnly = false
                };

                var res = await client.CreateRegistrySetting(regSetting);

                Assert.NotNull(res);

                //retrieve
                var getRes = await client.GetRegistrySetting(regSetting.Name);

                Assert.NotNull(getRes);
                Assert.Equal(res.Value, getRes.Value);
                Assert.Equal(res.IsEncrypted, getRes.IsEncrypted);

                //update
                var updatedSetting = new RegistrySetting
                {
                    Name = "testSetting",
                    Value = "testValUpdated",
                    IsEncrypted = false,
                    IsReadOnly = false
                };
                var updated = await client.UpdateRegistrySetting(updatedSetting);

                Assert.True(updated);

                //check update
                getRes = await client.GetRegistrySetting(updatedSetting.Name);
                Assert.NotNull(getRes);
                Assert.Equal(updatedSetting.Value, getRes.Value);
                Assert.NotEqual(regSetting.Value, getRes.Value);

                //delete
                var delRes = await client.DeleteRegistrySetting(updatedSetting.Name);

                Assert.True(delRes);
            }
        }
    }
}
