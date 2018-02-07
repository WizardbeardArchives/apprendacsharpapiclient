using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Factories;

namespace ApprendaAPIClient.IntegrationTesting
{
    public abstract class BaseTest
    {
        protected IApprendaApiClient GetClient()
        {
            var logger = new Logger();
            var settings = new JsonFileSettingsFactory(logger);

            var factory = new ApprendaApiClientFactory(settings);

            var client = factory.GetV1Client(logger);

            return client;
        }
    }
}
