using ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    internal class DefaultRestApiContext : IRestApiContext
    {
        public DefaultRestApiContext(string cloudUrl)
        {
            CloudUrl = cloudUrl;
        }

        public bool IsLegacyToken { get { return false; } }

        public string AuthToken { get; set; }

        public string CloudUrl { get; set; }
    }
}
