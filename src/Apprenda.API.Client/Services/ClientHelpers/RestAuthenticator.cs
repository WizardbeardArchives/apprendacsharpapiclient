using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    public interface IRestAuthenticator
    {
        bool Test();

        string Login(string user, string password);

        void Logout(string token);
    }

    public class RestAuthenticator : RestApiProxyBase, IRestAuthenticator
    {
        public const string HeaderName = "ApprendaSessionToken";
        private const string nullString = null;

        public RestAuthenticator(IRestApiContext context, string appAlias)
            : base(context, $"authentication/api/v1/sessions/{appAlias}/", "https")
        {
        }

        /// <summary>
        /// Ensures that the authentication endpoints exist on the current cloud.
        /// </summary>
        /// <returns>True when the connection is successful, otherwise false.</returns>
        /// <exception cref="AggregateException">If an exception occurs when sending the request</exception>
        public bool Test()
        {
            var result = GetClient().PostAsJsonAsync(nullString, new LoginRequest { Username = "!", Password = "!" }).Result;
            return result.IsSuccessStatusCode || result.StatusCode == HttpStatusCode.Unauthorized;
        }

        public bool TestAuthenticated(string username)
        {
            var result = GetClient().GetAsync($"tenants?username={Uri.EscapeDataString(username)}").Result;
            return result.IsSuccessStatusCode;
        }

        public IEnumerable<string> GetTenants(string user, string password = null)
        {
            var pathBuilder = new StringBuilder();
            pathBuilder.AppendFormat("tenants?username={0}", Uri.EscapeDataString(user));
            if (!string.IsNullOrWhiteSpace(password))
            {
                pathBuilder.AppendFormat("&password={0}", Uri.EscapeDataString(password));
            }
            var result = GetClient().Get<UserTenants>(pathBuilder.ToString());
            return result.Tenants;
        }

        public Task<HttpResponseMessage> LoginAsync(string user, string password, string tenantAlias = null)
        {
            return GetClient().PostAsJsonAsync(nullString, BuildLoginRequest(user, password, tenantAlias));
        }

        public string Login(string user, string password)
        {
            return Login(user, password, null);
        }

        public string Login(string user, string password, string tenantAlias)
        {
            var result = GetClient().PostWithResponse<LoginRequest, RestSession>(BuildLoginRequest(user, password, tenantAlias));
            Context.AuthToken = result?.ApprendaSessionToken;
            return Context.AuthToken;
        }

        public void Logout(string token)
        {
            GetClient().Delete(token);
        }

        private static LoginRequest BuildLoginRequest(string username, string password, string tenantAlias)
        {
            return new LoginRequest
            {
                Username = username,
                Password = password,
                TenantAlias = tenantAlias
            };
        }

        private class RestSession
        {
            public string ApprendaSessionToken { get; set; }
        }

        private class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string TenantAlias { get; set; }
        }

        private class UserTenants
        {
            public IEnumerable<string> Tenants { get; set; }
        }
    }
}
