using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient
{
    public class ConnectionSettings : IConnectionSettings
    {
        public string AppsUrl { get; set; }
        public IUserLogin UserLogin { get; set; }
    }
}
