using System;
using ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    internal class AccountApiHelper : IRestApiClientHelper
    {
        private readonly IRestApiClientHelper _genericApiHelper;

        public AccountApiHelper(IConnectionSettings connectionSettings)
        {
            _genericApiHelper = new GenericApiHelper(connectionSettings, "account");
        }

        public UriBuilder ApiRoot => _genericApiHelper.ApiRoot;

        public RestAuthenticator Authenticator => _genericApiHelper.Authenticator;
    }
}
