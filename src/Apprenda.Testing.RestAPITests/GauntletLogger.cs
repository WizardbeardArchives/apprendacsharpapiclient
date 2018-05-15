using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Services;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests
{
    public class GauntletLogger : ITelemetryReportingService
    {
        private readonly ITestOutputHelper _logger;

        public GauntletLogger(ITestOutputHelper logger)
        {
            _logger = logger;
        }


        public Task ReportInfo(string message, IEnumerable<string> tags)
        {
            _logger.WriteLine(message);

            return Task.FromResult(true);
        }
    }
}
