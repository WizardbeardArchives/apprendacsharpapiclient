using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.Factories
{
    public class ApprendaApiClientFactory : IApprendaApiClientFactory
    {
        private readonly IConnectionSettingsFactory _connectionSettingsFactory;

        public ApprendaApiClientFactory(IConnectionSettingsFactory connectionSettingsFactory)
        {
            _connectionSettingsFactory = connectionSettingsFactory;
        }

        public IApprendaApiClient GetV1Client()
        {
            var connectionSettings = _connectionSettingsFactory.GetConnectionSettings();
            return new ApprendaApiClient(connectionSettings);
        }

        public IApprendaApiClient GetV1Client(ITelemetryReportingService reportingService)
        {
            var connectionSettings = _connectionSettingsFactory.GetConnectionSettings();
            return new ApprendaTattletaleApiClient(connectionSettings, reportingService);
        }
    }
}
