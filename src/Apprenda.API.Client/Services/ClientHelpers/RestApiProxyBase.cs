using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    public interface IRestApiContext
    {
        bool IsLegacyToken { get; }

        string AuthToken { get; set; }

        string CloudUrl { get; }
    }

    public abstract class RestApiProxyBase
    {
        public const string JsonMimeType = "application/json";
        public const string XmlMimeType = "application/xml";

        // Another copy of this constant exists in Apprenda.SaaSGrid.RestAuthenticationToken
        private const string sessionTokenHeaderName = "ApprendaSessionToken";
        private static readonly string[] supportedMimeTypes = { JsonMimeType, XmlMimeType };

        private string managedPath;
        private readonly string requiredScheme;
        private string appsUrl;
        private Uri targetUri;

        protected RestApiProxyBase(IRestApiContext context, string managedPath)
            : this(context, managedPath, null)
        {
        }

        protected RestApiProxyBase(IRestApiContext context, string managedPath, string requiredScheme)
        {
            Context = context;
            this.managedPath = managedPath;
            this.requiredScheme = requiredScheme;
        }

        public IRestApiContext Context { get; private set; }

        protected Uri TargetUri
        {
            get
            {
                //Update if Context.AppsUrl has changed
                if (targetUri == null || appsUrl.Equals(Context.CloudUrl))
                {
                    appsUrl = Context.CloudUrl;
                    var builder = new UriBuilder(appsUrl);

                    if (!string.IsNullOrWhiteSpace(managedPath))
                    {
                        builder.Path = managedPath;
                    }

                    if (!string.IsNullOrWhiteSpace(requiredScheme))
                    {
                        builder.Scheme = requiredScheme;
                        builder.Port = -1;
                    }

                    targetUri = builder.Uri;
                }
                return targetUri;
            }
        }

        protected virtual HttpClient GetClient(TimeSpan? timeout = null)
        {
            return GetClient(TargetUri, Context.AuthToken, Context.IsLegacyToken, timeout);
        }

        /// <summary>
        /// Initialize an HttpClient
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="authToken"></param>
        /// <param name="timeout"></param>
        /// <param name="mediaTypes">if none are provided, all supported types are used (Json/Xml)</param>
        /// <returns></returns>
        public static HttpClient GetClient(Uri baseAddress = null, string authToken = null, bool isLegacyToken = false, TimeSpan? timeout = null, params string[] mediaTypes)
        {
            isLegacyToken = IsLegacyToken(authToken) ?? isLegacyToken;
            var client = GetVerbMaintainingClient();
            client.BaseAddress = baseAddress;
            if (mediaTypes == null || mediaTypes.Length == 0)
            {
                mediaTypes = supportedMimeTypes;
            }
            foreach (var mediaType in mediaTypes)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            }
            if (authToken != null)
            {
                client.DefaultRequestHeaders.Add(isLegacyToken ? "AuthenticationToken" : sessionTokenHeaderName, authToken);
            }
            if (timeout.HasValue)
            {
                client.Timeout = timeout.Value;
            }
            return client;
        }

        public static HttpClient GetVerbMaintainingClient(bool allowAutoRedirect)
        {
            var handler = new VerbMaintainingRedirectionHandler
            {
                InnerHandler = new HttpClientHandler { AllowAutoRedirect = allowAutoRedirect }
            };

            return new HttpClient(handler);
        }

        public static HttpClient GetVerbMaintainingClient()
        {
            return GetVerbMaintainingClient(allowAutoRedirect: false);
        }

        private static bool? IsLegacyToken(string authToken)
        {
            if (string.IsNullOrWhiteSpace(authToken))
            {
                return null;
            }

            Guid g;
            return Guid.TryParse(authToken, out g);
        }
    }
}
