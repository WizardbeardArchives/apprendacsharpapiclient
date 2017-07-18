using System;
using System.Threading.Tasks;
using ApprendaAPIClient.Services.ClientHelpers;

namespace ApprendaAPIClient.Clients
{
    public abstract class BaseApprendaApiClient
    {
        protected string SessionToken;
        protected readonly IConnectionSettings ConnectionSettings;

        protected readonly string AppsRoot;

        protected BaseApprendaApiClient(IConnectionSettings connectionSettings)
        {
            ConnectionSettings = connectionSettings;

            AppsRoot = connectionSettings.AppsUrl;
        }

        protected BaseApprendaApiClient(IConnectionSettings connectionSettings, IRestSession restSession) : this(connectionSettings)
        {
            if (restSession == null) throw new ArgumentNullException(nameof(restSession));
            SessionToken = restSession.ApprendaSessionToken;
        }

        public Task<string> Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(SessionToken))
            {
                return Task.FromResult(SessionToken);
            }
            var helper = new GenericApiHelper(ConnectionSettings, "developer");
            SessionToken = helper.Authenticator?.Login(userName, password);

            return Task.FromResult(SessionToken);
        }

        public Task Logout(string sessionToken)
        {
            var helper = new GenericApiHelper(ConnectionSettings, "developer");
            helper.Authenticator.Logout(SessionToken);
            SessionToken = null;

            return Task.FromResult(false);
        }
    }
}
