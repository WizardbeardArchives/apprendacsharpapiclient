using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Exceptions;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Services;
using ApprendaAPIClient.Services.ClientHelpers;
using Newtonsoft.Json;

namespace ApprendaAPIClient.Clients.ApprendaApiClient
{
    internal partial class ApprendaApiClient
    {
        private const string DEV = "developer";
        private const string ACCOUNT = "account";
        private const string SOC = "soc";

        protected string DevRoot => AppsRoot + "/developer";
        protected string AccountRoot => AppsRoot + "/account";
        protected string SOCRoot => AppsRoot + "/soc";

        /// <summary>
        /// Since so many of our endpoints hang off of apps and versions, and these vary across the portals.
        /// Note that older endpoints might use different paths!
        /// </summary>
        /// <param name="appAlias"></param>
        /// <param name="versionAlias"></param>
        /// <param name="helperType"></param>
        /// <returns></returns>
        private static string GetAppVersionStartPoint(string appAlias, string versionAlias, string helperType)
        {
            switch (helperType)
            {
                case DEV:
                    return $"apps/{appAlias}/versions/{versionAlias}/";
                default:
                    throw new NotImplementedException();
            }
        }

        protected virtual IEnumerable<T> EnumeratePagedResults<T>(string startUrl, string helperType, Action<string> reportFunction = null)
        {
            reportFunction?.Invoke("Starting to depage items from " + startUrl);

            //call the start function
            var start = GetResultSync<PagedResourceBase<T>>(startUrl, helperType);

            if (start == null)
            {
                yield break;
            }

            //while we still have more pages, we need to continue getting
            foreach (var item in start.Items)
            {
                yield return item;
            }


            var nextPage = start.NextPage;

            while (!string.IsNullOrWhiteSpace(nextPage?.Href))
            {
                reportFunction?.Invoke("Getting next page from " + nextPage.Href);

                var next = GetResultSync<PagedResourceBase<T>>(nextPage.Href, helperType);

                if (next != null)
                {
                    foreach (var item in next.Items)
                    {
                        yield return item;
                    }

                    nextPage = next.NextPage;
                }
                else
                {
                    nextPage = null;
                }
            }
        }

        protected virtual T GetResultSync<T>(string path, string helperType,
            [CallerMemberName] string callingMethod = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            var doIt = GetResultAsync<T>(path, helperType, callingMethod);

            return doIt.Result;

        }

        protected virtual async Task<T> GetResultAsync<T>(string path, string helperType, [CallerMemberName] string callingMethod = "")
        {
            var helper = helperType == "socinternal"
                ? (IRestApiClientHelper)new InternalSOCHelper(ConnectionSettings, "soc")
                : new GenericApiHelper(ConnectionSettings, helperType);

            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path);
            var client = GetClient(uri, SessionToken);

            var res = await client.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(res);
        }

        protected virtual async Task<bool> DeleteAsync(string path, string helperType,
            [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);
            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path);
            var client = GetClient(uri, SessionToken);

            var res = await client.DeleteAsync(uri);

            return res.IsSuccessStatusCode;
        }

        protected virtual async Task<T> PostAsync<T>(string path, object body, string helperType,
            object queryParams = null, [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);
            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path, null, queryParams);

            /*
            using (var wc = new WebClient())
            {
                wc.Headers.Add("ApprendaSessionToken", SessionToken);
                wc.Headers.Add("Content-Type", "application/json");
                res = await wc.UploadStringTaskAsync(uri, value);
            }*/

            var client = GetClient(uri, SessionToken, null, "application/json");
            var val = body != null
                ? new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
                : null;

            var res = await client.PostAsync(uri, val);
            var msg = await res.Content.ReadAsStringAsync();
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception(msg);
            }

            return string.IsNullOrWhiteSpace(msg) ? default(T) : JsonConvert.DeserializeObject<T>(msg);
        }

        protected virtual async Task<T> PostBinaryAsync<T>(string path,
            byte[] file, object queryParams,
            string helperType, [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);

            var builder = new ClientUriBuilder(helper.ApiRoot);
            var uri = builder.BuildUri(path, null, queryParams);
            using (var client = GetClient(uri, SessionToken))
            {
                using (var content = new MultipartFormDataContent())
                {
                    using (var stream = new MemoryStream(file))
                    {
                        var streamContent = new StreamContent(stream);
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        content.Add(streamContent, path, path);

                        using (var message = await client.PostAsync(uri, content))
                        {
                            var response = await message.Content.ReadAsStringAsync();

                            if (string.IsNullOrWhiteSpace(response))
                            {
                                return default(T);
                            }

                            try
                            {
                                var res = JsonConvert.DeserializeObject<T>(response);
                                return res;
                            }
                            catch (Exception e)
                            {
                                throw new MismatchedReturnTypeException(typeof(T), response, e);
                            }
                        }
                    }
                }
            }
        }

        protected virtual async Task<T> PostBinaryAsyncOld<T>(string path,
            byte[] file, object queryParams,
            string helperType, [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);

            var builder = new ClientUriBuilder(helper.ApiRoot);
            var uri = builder.BuildUri(path, null, queryParams);

            var client = GetClient(uri, SessionToken);

            var response = await client.PostAsync(uri, new ByteArrayContent(file));

            if (response == null || !response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var retString = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<T>(retString);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        protected virtual async Task<bool> PutVoid(string path, object body, string helperType,
            object queryParams = null, [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);
            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path, null, queryParams);

            var client = GetClient(uri, SessionToken, null, "application/json");

            var val = JsonConvert.SerializeObject(body);

            var response = await client.PutAsync(uri, new StringContent(val, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                var msg = await response.Content.ReadAsStringAsync();
                throw new Exception(msg);
            }

            return response.IsSuccessStatusCode;
        }

        private static HttpClient GetClient(Uri baseAddress, string authenticationToken = null, TimeSpan? timeout = null, string mediaType = null)
        {
            var client = RestApiProxyBase.GetVerbMaintainingClient();
            InitializeHttpClient(baseAddress, authenticationToken, timeout, mediaType, client);
            return client;
        }

        private static void InitializeHttpClient(Uri baseAddress, string authenticationToken, TimeSpan? timeout, string mediaType, HttpClient client)
        {
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType ?? "application/json"));

            if (!string.IsNullOrWhiteSpace(authenticationToken))
            {
                client.DefaultRequestHeaders.Add(RestAuthenticator.HeaderName, authenticationToken);
            }

            if (timeout.HasValue)
            {
                client.Timeout = timeout.Value;
            }
        }
    }
}
