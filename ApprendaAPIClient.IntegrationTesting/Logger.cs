using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.IntegrationTesting
{
    internal class Logger : ILogger
    {
        public Task ReportInfo(string message, IEnumerable<string> tags)
        {
            Console.WriteLine(message);

            return Task.FromResult(true);
        }
    }
}
