using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Factories;
using ApprendaAPIClient.Services;
using Newtonsoft.Json;

namespace ApprendaAPIClient.IntegrationTesting
{
    class JsonFileSettingsFactory : IConnectionSettingsFactory
    {
        private readonly string _fileLocation;
        private readonly bool _saveIfNotPresent;
        private readonly ILogger _logger;

        public JsonFileSettingsFactory(ILogger logger, string fileLocation = "connectionSettings.json", bool saveHardCodedIfNotPresent = true)
        {
            _logger = logger;
            _fileLocation = fileLocation;
            _saveIfNotPresent = saveHardCodedIfNotPresent;
        }

        public IConnectionSettings GetConnectionSettings()
        {
            return GetSmokeTestSettings().Result;
        }

        public async Task<IConnectionSettings> GetSmokeTestSettings()
        {
            try
            {
                //does the file exist?
                if (File.Exists(_fileLocation))
                {
                    await _logger.ReportInfo($"Loading settings from {_fileLocation}", new[] { "settings" });
                    var task = Task.Run(() => File.ReadAllText(_fileLocation));

                    var contents = await task;

                    var deser = JsonConvert.DeserializeObject<ConnectionSettingsStorage>(contents);

                    if (deser == null)
                    {
                        throw new SerializationException("Could not deserialize from " + _fileLocation);
                    }

                    return deser.ToValueObject();
                }
            }
            catch (Exception e)
            {
                await _logger.ReportInfo("Error in retrieving settings " + e.Message, new List<string>());
            }

            await _logger.ReportInfo("Cannot load settings, retrieving from backup", new[] { "settings" });
            var settings = new ConnectionSettings
            {
                AppsUrl = "https://apprenda.paas.eclair.proto.local",
                UserLogin = new UserLogin
                {
                    UserName = "admin@apprenda.com",
                    Password = "Apprenda--2017*!"
                }
            };

            var formatted = new ConnectionSettingsStorage(settings);
            if (_saveIfNotPresent)
            {
                await _logger.ReportInfo("Saving connection settings to " + _fileLocation, new[] { "save", "settings" });
                await SaveSettings(formatted);
            }

            return formatted.ToValueObject();
        }

        private Task SaveSettings(ConnectionSettingsStorage settings)
        {
            var write = JsonConvert.SerializeObject(settings);

            var writeTask = Task.Run(() => File.WriteAllText(_fileLocation, write));

            return writeTask;
        }

        public class ConnectionSettingsStorage
        {
            public string AppsUrl { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            public IConnectionSettings ToValueObject()
            {
                return new ConnectionSettings
                {
                    AppsUrl = AppsUrl,
                    UserLogin = new UserLogin
                    {
                        UserName = Username,
                        Password = Password
                    }
                };
            }

            public ConnectionSettingsStorage(IConnectionSettings source)
            {
                AppsUrl = source.AppsUrl;
                Username = source.UserLogin.UserName;
                Password = source.UserLogin.Password;
            }

            public ConnectionSettingsStorage() { }
        }
    }
}
