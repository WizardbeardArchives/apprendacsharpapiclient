using System;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    internal class SocApiHelper : IRestApiClientHelper
    {
        private readonly IConnectionSettings _connectionSettings;
        private readonly IRestApiClientHelper _genericApiHelper;
        private readonly string _portal;

        public SocApiHelper(IConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
            _portal = "soc";
            _genericApiHelper = new GenericApiHelper(connectionSettings, _portal);
        }

        public UriBuilder ApiRoot => _genericApiHelper.ApiRoot;

        public UriBuilder InternalApiRoot => new UriBuilder(_connectionSettings.AppsUrl)
        {
            Path = $"{_portal}/api/internal/"
        };

        public RestAuthenticator Authenticator => _genericApiHelper.Authenticator;
    }
}
