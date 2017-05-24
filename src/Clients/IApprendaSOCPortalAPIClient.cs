using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.SOC;
using Cloud = ApprendaAPIClient.Models.SOC.Cloud;
using CustomProperty = ApprendaAPIClient.Models.SOC.CustomProperty;

namespace ApprendaAPIClient.Clients
{
    public interface IApprendaSOCPortalAPIClient
    {
        Task<IEnumerable<Host>> GetAllHosts();

        Task<UnpagedResourceBase<Cloud>> GetClouds();

        Task<Cloud> GetCloud(int id);

        Task<PagedResourceBase<HealthReport>> GetHealthReports(string hostName);

        Task<PagedResourceBase<CustomProperty>> GetAllCustomProperties();
        Task<CustomProperty> GetCustomProperty(int id);
        /// <summary>
        /// POST to the custom property endpoint
        /// </summary>
        /// <param name="customProperty"></param>
        /// <returns></returns>
        Task<CustomProperty> CreateCustomProperty(CustomProperty customProperty);

        Task<bool> UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate);
        Task<bool> DeleteCustomProperty(int id);
    }
}
