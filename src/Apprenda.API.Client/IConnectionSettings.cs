using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient
{
    /// <summary>
    /// All settings that a test requires in order to connect to a Apprenda platform
    /// </summary>
    public interface IConnectionSettings
    {
        /// <summary>
        /// Base url of the platform - apps.apprenda.test
        /// </summary>
        string AppsUrl { get; }

        /// <summary>
        /// User to login as.  Should not be an admin
        /// </summary>
        IUserLogin UserLogin { get; set; }
    }
}
