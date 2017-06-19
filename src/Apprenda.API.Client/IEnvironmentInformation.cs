using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient
{
    /// <summary>
    /// Information about the environment the test is running on
    /// </summary>
    public interface IEnvironmentInformation
    {
        bool IsEUS { get; }
        /// <summary>
        /// Name of the group to use for tests
        /// </summary>
        string EUSGroupName { get; }

        string EUSGroupId { get; }
    }
}
