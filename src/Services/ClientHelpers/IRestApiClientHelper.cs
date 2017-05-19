using System;
using ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    public interface IRestApiClientHelper
    {
        UriBuilder ApiRoot { get; }
        RestAuthenticator Authenticator { get; }
    }
}
