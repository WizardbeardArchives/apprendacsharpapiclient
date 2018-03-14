using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ApprendaAPIClient.Services
{
    /// <summary>
    /// Reports timestamped logs to a data store
    /// </summary>
    public interface ITelemetryReportingService
    {
        /// <summary>
        /// Report some data
        /// </summary>
        /// <param name="message">Main part of the message</param>
        /// <param name="tags">Tags to use for reporting</param>
        /// <returns></returns>
        Task ReportInfo(string message, IEnumerable<string> tags);
    }
}
