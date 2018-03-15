using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Clients.ApprendaApiClient;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.Factories
{
    public class ApprendaApiSynchronousClientFactory : IApprendaApiSynchronousClientFactory
    {
        private readonly string _appUrl;
        private readonly string _userName;
        private readonly string _password;

        /// <summary>
        /// Make a factory to retrieve a client, using the supplied credentials
        /// </summary>
        /// <param name="appUrl"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public ApprendaApiSynchronousClientFactory(string appUrl, string userName, string password)
        {
            _appUrl = appUrl;
            _userName = userName;
            _password = password;
        }

        /// <summary>
        /// Get a client, using the supplied logger to report on internal details
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public IApprendaSynchronousClient GetClient(ILoggingService logger = null)
        {
            var innerFactory = new ApprendaApiClientFactory(_appUrl, _userName, _password);

            ITelemetryReportingService loggingAdapter = null;
            if (logger != null)
            {
                loggingAdapter = new SynchronousLoggingServiceAdapter(logger);
            }

            var innerClient = innerFactory.GetV1Client(loggingAdapter);

            return new ApprendaSynchronousClientAdapter(innerClient);
        }
    }

    /// <summary>
    /// Helper class to let a synch method from powershell imitate a task based logger.  Used by the factory, so included here.
    /// </summary>
    public class SynchronousLoggingServiceAdapter : ITelemetryReportingService
    {
        private readonly ILoggingService _logger;

        public SynchronousLoggingServiceAdapter(ILoggingService logger)
        {
            _logger = logger;
        }


        public Task ReportInfo(string message, IEnumerable<string> tags)
        {
            _logger.ReportInfo(message, tags);

            return Task.FromResult(true);
        }
    }
}
