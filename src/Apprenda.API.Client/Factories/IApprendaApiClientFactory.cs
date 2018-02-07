using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.Factories
{
    public interface IApprendaApiClientFactory
    {
        IApprendaApiClient GetV1Client();

        IApprendaApiClient GetV1Client(ILogger reportingService);
    }
}
