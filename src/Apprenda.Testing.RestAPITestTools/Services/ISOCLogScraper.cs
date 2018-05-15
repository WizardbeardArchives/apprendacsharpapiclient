using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apprenda.Testing.RestAPITestTools.Services
{
    /// <summary>
    /// Used to interact with logs as an additional assertion
    /// </summary>
    public interface ISOCLogScraper
    {
        Task AssertStringIsNotInLogs(string src);

        Task AssertTableIsNotDeadlocked(string tableName);
    }
}
