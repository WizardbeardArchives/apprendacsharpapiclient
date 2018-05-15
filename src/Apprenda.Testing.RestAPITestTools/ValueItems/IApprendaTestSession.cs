using System;
using System.Threading.Tasks;
using ApprendaAPIClient;
using ApprendaAPIClient.Clients;

namespace Apprenda.Testing.RestAPITestTools.ValueItems
{
    /// <summary>
    /// Represents connection info and other platform tie ins for a single test
    /// </summary>
    public interface IApprendaTestSession : IDisposable
    {
        Task<IApprendaApiClient> GetClient(ApiPortals portalsToUse);
        Task<IApprendaApiClient> GetClient();

        ISmokeTestSettings ConnectionSettings { get; }

        TestIsolationLevel TestIsolationLevel { get; }

        string SessionToken { get; }
    }
}
