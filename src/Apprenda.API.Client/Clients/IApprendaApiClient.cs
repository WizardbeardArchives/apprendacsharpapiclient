using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Clients
{
    /// <summary>
    /// Represents a client which can talk to the apprenda platform for the duration of a test
    /// Returns items from the Apprenda API defined by pregenned swagger, definitions are to be found there
    /// </summary>
    public interface IApprendaApiClient : IApprendaAccountPortalApiClient, IApprendaDeveloperPortalApiClient, IApprendaSOCPortalApiClient, IApprendaKubernetesClusterClient
    {
        /// <summary>
        /// Logs into the platform with the given credentials
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Session token for the login</returns>
        Task<string> Login(string userName, string password);

        Task Logout(string sessionToken);

        Task<IEnumerable<string>> GetTenants();
        
    }
}
