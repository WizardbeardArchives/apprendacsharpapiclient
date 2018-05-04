using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Factories;

namespace ApprendaAPIClient
{
    public class ConnectionSettings : IConnectionSettings
    {
        public string AppsUrl { get; set; }
        public IUserLogin UserLogin { get; set; }
    }

    public class SimpleConnectionSettingsFactory : IConnectionSettingsFactory
    {
        private readonly IConnectionSettings _settings;

        public SimpleConnectionSettingsFactory(string appsUrl, string username, string password)
        {
            _settings = new ConnectionSettings
            {
                AppsUrl = appsUrl,
                UserLogin = new UserLogin
                {
                    UserName = username,
                    Password = password
                }
            };
        }
        public IConnectionSettings GetConnectionSettings()
        {
            return _settings;
        }
    }
}
