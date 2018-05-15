using ApprendaAPIClient;

namespace Apprenda.Testing.RestAPITestTools.Repositories.Implementation
{
    /// <summary>
    /// Simple repository that simply redirects any call for a user to connection settings.  Means only one login
    /// </summary>
    internal class SingleUserLoginRepository : IUserLoginRepository
    {
        private readonly ISmokeTestSettingsRepository _connectionSettingsFactory;
     
        public SingleUserLoginRepository(ISmokeTestSettingsRepository connectionSettingsFactory)
        {
            _connectionSettingsFactory = connectionSettingsFactory;
        }

        public IUserLogin GetNextAvailableUserLogin()
        {
            var settings = _connectionSettingsFactory.GetConnectionSettings();

            return settings.UserLogin;
        }

        public IUserLogin GetAdminUserLogin()
        {
            var settings = _connectionSettingsFactory.GetSmokeTestSettings().Result;
            return settings.AdminUserLogin;
        }
    }
}
