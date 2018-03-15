using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Clients;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.Factories
{
    public interface IApprendaApiSynchronousClientFactory
    {
        IApprendaSynchronousClient GetClient(ILoggingService logger = null);
    }

    public interface ILoggingService
    {
        void ReportInfo(string message, IEnumerable<string> tags);
    }
}
