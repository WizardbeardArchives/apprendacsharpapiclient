using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Exceptions
{
    /// <summary>
    /// Fired when the client is given a 404 error
    /// </summary>
    public class EndpointNotFoundException : Exception
    {
        public EndpointNotFoundException(string location) : base($"The call to {location} returned 404 - Not Found")
        {
            
        }
    }
}
