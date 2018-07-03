using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.Factories
{
    public interface IApprendaApiClientFactory
    {
        IApprendaApiClient GetV1Client();

        IApprendaApiClient GetV1Client(string token);

        IApprendaApiClient GetV1Client(ITelemetryReportingService reportingService);

        IApprendaApiClient GetV1Client(string token, ITelemetryReportingService reportingService);
    }
}
