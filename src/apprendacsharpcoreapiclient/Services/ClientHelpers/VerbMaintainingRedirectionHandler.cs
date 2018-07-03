using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    internal class VerbMaintainingRedirectionHandler : DelegatingHandler
    {
        private static readonly List<HttpStatusCode> redirectCodes = new List<HttpStatusCode>
        {
            HttpStatusCode.Redirect,
            HttpStatusCode.Found,
            HttpStatusCode.MovedPermanently,
            HttpStatusCode.Moved,
            HttpStatusCode.RedirectKeepVerb,
            HttpStatusCode.TemporaryRedirect
        };

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken, new List<Uri>());
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken, List<Uri> locationsFollowed)
        {
            var result = await base.SendAsync(request, cancellationToken);
            return await RedirectionHandler(request, cancellationToken, result, locationsFollowed);
        }

        private async Task<HttpResponseMessage> RedirectionHandler(HttpRequestMessage request, CancellationToken cancellationToken, HttpResponseMessage result, List<Uri> locationsFollowed)
        {
            if (result.Headers.Location != null && redirectCodes.Contains(result.StatusCode))
            {
                if (locationsFollowed.Any(l => l.Equals(result.Headers.Location)) || locationsFollowed.Count > 8)
                {
                    return result;
                }

                locationsFollowed.Add(result.Headers.Location);
                request.RequestUri = GetLocation(request.RequestUri, result.Headers.Location);

                result.Dispose();
                return await SendAsync(request, cancellationToken, locationsFollowed);
            }

            return result;
        }

        private Uri GetLocation(Uri requested, Uri redirect)
        {
            if (redirect.IsAbsoluteUri)
            {
                return redirect;
            }

            var builder = new UriBuilder(requested) { Port = -1, Scheme = requested.Scheme, Path = redirect.OriginalString };
            return builder.Uri;
        }
    }
}
