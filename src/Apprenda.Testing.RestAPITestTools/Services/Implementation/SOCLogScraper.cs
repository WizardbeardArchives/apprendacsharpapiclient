using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Clients;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Apprenda.Testing.RestAPITestTools.Services.Implementation
{
    public class SOCLogScraper : ISOCLogScraper
    {
        private readonly IApprendaSOCPortalApiClient _client;

        public SOCLogScraper(IApprendaSOCPortalApiClient client)
        {
            _client = client;
        }

        public async Task AssertStringIsNotInLogs(string src)
        {
            var logs = await _client.GetExportLogs();

            if (logs != null)
            {
                if (logs.Contains(src))
                {
                    throw new AssertActualExpectedException("", src, "Transaction error detected in the logs");
                }
            }
        }

        public async Task AssertTableIsNotDeadlocked(string tableName)
        {
            var logs = await _client.GetExportLogs();

            if (logs != null)
            {
                if (logs.Contains(
                    " was deadlocked on lock resources with another process and has been chosen as the deadlock victim. Rerun the transaction.")
                )
                {
                    if (logs.ToLower().Contains(tableName.ToLower()))
                    {
                        throw new Exception("Table " + tableName + " was deadlocked");
                    }
                }
            }
        }
    }
}
