using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Clients.ApprendaApiClient;
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

        public ApprendaApiClientFactory(string appsUrl, string userName, string password)
        {
            _connectionSettingsFactory = new SimpleConnectionSettingsFactory(appsUrl, userName, password);
        }

        public IApprendaApiClient GetV1Client()
        {
            var connectionSettings = _connectionSettingsFactory.GetConnectionSettings();
            return new ApprendaApiClient(connectionSettings);
        }

        public IApprendaApiClient GetV1Client(IRestSession restSession)
        {
            var connectionSettings = _connectionSettingsFactory.GetConnectionSettings();
            return new ApprendaApiClient(connectionSettings, restSession);
        }

        public IApprendaApiClient GetV1Client(ITelemetryReportingService reportingService)
        {
            var connectionSettings = _connectionSettingsFactory.GetConnectionSettings();
            return new ApprendaTattletaleApiClient(connectionSettings, reportingService);
        }

        public IApprendaApiClient GetV1Client(ITelemetryReportingService reportingService, IRestSession restSession)
        {
            var connectionSettings = _connectionSettingsFactory.GetConnectionSettings();
            return new ApprendaTattletaleApiClient(connectionSettings, restSession, reportingService);
        }
    }
}
