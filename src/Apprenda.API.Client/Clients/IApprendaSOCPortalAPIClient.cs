using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.SOC;
using IO.Swagger.Model;
using Cloud = ApprendaAPIClient.Models.SOC.Cloud;
using CustomProperty = ApprendaAPIClient.Models.SOC.CustomProperty;

namespace ApprendaAPIClient.Clients
{
    public interface IApprendaSOCPortalApiClient
    {
        Task<IEnumerable<Host>> GetAllHosts();

        Task<IEnumerable<Cloud>> GetClouds();

        Task<Cloud> GetCloud(int id);

        Task<IEnumerable<HealthReport>> GetHealthReports(string hostName);

        Task<IEnumerable<CustomProperty>> GetAllCustomProperties();
        Task<CustomProperty> GetCustomProperty(int id);

        /// <summary>
        /// POST to the custom property endpoint
        /// </summary>
        /// <param name="customProperty"></param>
        /// <returns></returns>
        Task<CustomProperty> CreateCustomProperty(CustomProperty customProperty);

        Task<bool> UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate);
        Task<bool> DeleteCustomProperty(int id);

        Task<IEnumerable<RegistrySetting>> GetRegistrySettings();
        Task<RegistrySetting> GetRegistrySetting(string name);
        Task<RegistrySetting> CreateRegistrySetting(RegistrySetting setting);

        Task<bool> UpdateRegistrySetting(RegistrySetting setting);
        Task<bool> DeleteRegistrySetting(string name);

        // ReSharper disable once InconsistentNaming
        Task<IEnumerable<Group>> GetExternalUserStoreGroups();

        Task<Group> GetExternalUserStoreGroup(string groupId);
    }
}
