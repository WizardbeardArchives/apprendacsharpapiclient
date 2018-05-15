using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprendaAPIClient.Services;

namespace Apprenda.Testing.RestAPITestTools.Services.Implementation
{
    public class ConsoleTelemetryService : ITelemetryReportingService
    {
        public Task ReportInfo(string message, IEnumerable<string> tags)
        {
            Console.WriteLine(message + "::" + string.Join(", " ,tags));

            return Task.FromResult(false);
        }
    }
}
