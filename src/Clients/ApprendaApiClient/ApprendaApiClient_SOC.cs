using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.SOC;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        public Task<PagedResourceBase<HealthReport>> GetHealthReports(string hostName)
        {
            return GetResultAsync<PagedResourceBase<HealthReport>>($"hosts/{hostName}/healthreports", SOC);
        }

        public Task<PagedResourceBase<CustomProperty>> GetAllCustomProperties()
        {
            return GetResultAsync<PagedResourceBase<CustomProperty>>("customproperties", SOC);
        }

        public Task<CustomProperty> GetCustomProperty(int id)
        {
            return GetResultAsync<CustomProperty>($"customproperties/{id}", SOC);
        }

        public Task<CustomProperty> CreateCustomProperty(CustomProperty customProperty)
        {
            return PostAsync<CustomProperty>("customproperties", customProperty, SOC);
        }

        public Task<bool> UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate)
        {
            return PutVoid($"customproperties/{customPropertyUpdate.Id}", customPropertyUpdate, SOC);
        }

        public Task<bool> DeleteCustomProperty(int id)
        {
            return DeleteAsync($"customproperties/{id}", SOC);
        }

        public Task<IEnumerable<RegistrySetting>> GetRegistrySettings()
        {
            return Task.Run(() => EnumeratePagedResults<RegistrySetting>("/registry", SOC));
        }

        public Task<RegistrySetting> GetRegistrySetting(string name)
        {
            return GetResultAsync<RegistrySetting>($"/registry/{name}", SOC);
        }

        public Task<RegistrySetting> CreateRegistrySetting(RegistrySetting setting)
        {
            return PostAsync<RegistrySetting>("/registry", setting, SOC);
        }
    }
}
