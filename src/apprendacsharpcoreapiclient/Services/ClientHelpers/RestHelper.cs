using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Services.ClientHelpers;
using apprendacsharpcoreapiclient;
namespace ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers
{
    public class NotLoggedInException : Exception
    {
        public NotLoggedInException(string msg)
            : base(msg)
        {
        }
    }

    public class ApprendaRestApiException : Exception
    {
        public ApprendaRestApiException(HttpResponseMessage response, string message)
            : this(response.StatusCode, message)
        {
            Request = response.RequestMessage;
        }

        public ApprendaRestApiException(HttpStatusCode statusCode, string message)
            : this(statusCode, message, null)
        {
        }

        public ApprendaRestApiException(HttpStatusCode statusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
        public HttpRequestMessage Request { get; set; }
    }

    public static class RestHelper
    {
        // Another copy of this constant exists in Apprenda.SaaSGrid.Session
        private const string tokenBasedUnauthorizedMessage = "You are not authorized to access this application";
        private const string userDisabledUnauthorizedMessage = "because the user is disabled.";
        private static readonly ConcurrentDictionary<Type, Func<HttpResponseMessage, object>> specialHandlers = new ConcurrentDictionary<Type, Func<HttpResponseMessage, object>>();

        public static void RegisterSpecialErrorContentHandler<TResp>(Func<HttpResponseMessage, TResp> handler)
        {
            specialHandlers.AddOrUpdate(typeof(TResp), response => (object)handler(response), (_, current) => current);
        }

        public static TResp ReadAs<TResp>(this HttpContent content)
        {
            return SafeSync<TResp>(content.ReadAsAsync<TResp>);
        }

        public static TResp Get<TResp>(this HttpClient client, string uri = "", bool defaultIfNotFound = false)
        {
            return GetContentOrDefault<TResp>(SafeSync(() => client.GetAsync(uri)), defaultIfNotFound);
        }

        public static byte[] GetBytes(this HttpClient client, string uri = "")
        {
            return GetByteContent(SafeSync(() => client.GetAsync(uri)));
        }

        public static IEnumerable<TResp> List<TResp>(this HttpClient client, string uri = "")
        {
            return GetContentOrDefault<IEnumerable<TResp>>(SafeSync(() => client.GetAsync(uri)));
        }

        public static void Update<T>(this HttpClient client, string uri, T item)
        {
            AssertNoErrors(SafeSync(() => client.PutAsJsonAsync(uri, item)));
        }

        public static void Put(this HttpClient client, string uri)
        {
            AssertNoErrors(SafeSync(() => client.PutAsync(uri, null)));
        }

        public static void Put<T>(this HttpClient client, string uri, T item)
        {
            AssertNoErrors(SafeSync(() => client.PutAsJsonAsync(uri, item)));
        }

        public static void Delete(this HttpClient client, string uri)
        {
            AssertNoErrors(SafeSync(() => client.DeleteAsync(uri)));
        }

        public static void Post(this HttpClient client, string uri)
        {
            AssertNoErrors(SafeSync(() => client.PostAsync(uri, null)));
        }

        public static void Post<T>(this HttpClient client, string uri, T item)
        {
            AssertNoErrors(SafeSync(() => client.PostAsJsonAsync(uri, item)));
        }

        public static void PostBytes(this HttpClient client, string uri, byte[] bytes)
        {
            var content = new ByteArrayContent(bytes);
            AssertNoErrors(SafeSync(() => client.PostAsync(uri, content)));
        }

        public static TResp PostWithResponse<T, TResp>(this HttpClient client, T item)
        {
            return PostWithResponse<T, TResp>(client, null, item);
        }

        public static TResp PostWithResponse<T, TResp>(this HttpClient client, string uri, T item)
        {
            return GetContentOrDefault<TResp>(SafeSync(() => client.PostAsJsonAsync(uri, item)));
        }

        public static TResp PostWithContent<TResp>(this HttpClient client, string uri, HttpContent content)
        {
            return GetContentOrDefault<TResp>(SafeSync(() => client.PostAsync(uri, content)));
        }

        private static TResp GetContentOrDefault<TResp>(HttpResponseMessage response, bool defaultIfNotFound = false)
        {
            using (response)
            {
                if (response.IsSuccessStatusCode && (response.Content.Headers.ContentLength ?? 0) == 0)
                {
                    return default(TResp);
                }

                Func<HttpResponseMessage, object> handler;
                if (specialHandlers.TryGetValue(typeof(TResp), out handler))
                {
                    var result = handler(response);
                    if (result != null)
                    {
                        return (TResp)result;
                    }
                }
                else if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAs<TResp>();
                }
                else if (defaultIfNotFound && response.StatusCode == HttpStatusCode.NotFound)
                {
                    return default(TResp);
                }

                throw BuildResponseException(response);
            }
        }

        private static byte[] GetByteContent(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode && (response.Content.Headers.ContentLength ?? 0) == 0)
            {
                return new byte[0];
            }

            if (response.IsSuccessStatusCode)
            {
                return SafeSync(() => response.Content.ReadAsByteArrayAsync());
            }

            throw BuildResponseException(response);
        }

        private static void AssertNoErrors(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw BuildResponseException(response);
            }
        }

        private static Exception BuildResponseException(HttpResponseMessage response)
        {
            var message = response.GetApprendaErrorMessage();

            if ((response.StatusCode == HttpStatusCode.Forbidden && response.ReasonPhrase == tokenBasedUnauthorizedMessage) ||
                (response.StatusCode == HttpStatusCode.Unauthorized && !message.EndsWith(userDisabledUnauthorizedMessage)))
            {
                throw new NotLoggedInException(message);
            }

            throw new ApprendaRestApiException(response, message);
        }

        public static string GetApprendaErrorMessage(this HttpResponseMessage response)
        {
            string message;
            // no need to observe the return, it handles the special cases.
            new FallbackHandler().TryHandle(response, out message);

            return message;
        }

        public static T SafeSync<T>(Func<Task<T>> taskCreator)
        {
            // If there's a synchronization context, the async method will try to return to the current thread when it is awaited
            // which results in a deadlock because WE are about to block that thread waiting for the async method to complete.
            // In this case, we need to get out of the synchronization context by spinning up an extra task (ugly, I know) so that
            // the async method can complete on any thread. If there is NO synchronization context, we don't need to worry and can
            // avoid the unnecessary overhead
            return Synchronization.SafeSync(taskCreator);
        }
    }

    public class RestExceptionMessage
    {
        public string Message { get; set; }
    }

    public class ApprendaReportCardMessage
    {
        public string Severity { get; set; }

        public string Message { get; set; }
    }

    public class ApprendaReportCard
    {
        public string Title { get; set; }

        public bool Success { get; set; }

        public List<ApprendaReportCardMessage> Messages { get; set; }
    }
}
