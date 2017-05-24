using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApprendaSmokeTestsBase.Services.Implementation.ClientHelpers;
using Newtonsoft.Json.Linq;

namespace ApprendaAPIClient.Services.ClientHelpers
{
    public static class Synchronization
    {
        public static T SafeSync<T>(Func<Task<T>> taskCreator)
        {
            // If there's a synchronization context, the async method will try to return to the current thread when it is awaited
            // which results in a deadlock because WE are about to block that thread waiting for the async method to complete.
            // In this case, we need to get out of the synchronization context by spinning up an extra task (ugly, I know) so that
            // the async method can complete on any thread. If there is NO synchronization context, we don't need to worry and can
            // avoid the unnecessary overhead
            return SynchronizationContext.Current != null
                ? Task.Run(taskCreator).Result
                : taskCreator().Result;
        }
    }

    public abstract class ResponseHandlerBase<TResponse>
    {
        protected bool HasContent(HttpResponseMessage response)
        {
            return (response.Content.Headers.ContentLength ?? 0) > 0;
        }

        protected string SafeGetContent(HttpResponseMessage response)
        {
            return this.HasContent(response) ? Synchronization.SafeSync(() => response.Content.ReadAsStringAsync()) : "";
        }

        public abstract bool TryHandle(HttpResponseMessage response, out TResponse result);
    }

    public abstract class JsonResponseHandlerBase<TResponse> : ResponseHandlerBase<TResponse> where TResponse : class
    {
        protected abstract bool CanConvert(JObject item);

        public override bool TryHandle(HttpResponseMessage response, out TResponse result)
        {
            var json = this.SafeGetContent(response);

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    var obj = JObject.Parse(json);

                    if (this.CanConvert(obj))
                    {
                        result = obj.ToObject<TResponse>();
                        return true;
                    }
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch
                {
                }
            }

            result = null;
            return false;
        }
    }
    public sealed class ApprendaReportCardHandler : JsonResponseHandlerBase<ApprendaReportCard>
    {
        protected override bool CanConvert(JObject item)
        {
            return ContainsKey(item, "messages", StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsKey<T>(IDictionary<string, T> dictionary, string key, StringComparison comparison)
        {
            return dictionary.Keys.Any(k => k.Equals(key, comparison));
        }
    }

    public sealed class FallbackHandler : ResponseHandlerBase<string>
    {
        public override bool TryHandle(HttpResponseMessage response, out string result)
        {
            if (response.IsSuccessStatusCode)
            {
                result = "";
                return true;
            }

            ApprendaReportCard reportCard;
            if (new ApprendaReportCardHandler().TryHandle(response, out reportCard) && !reportCard.Success && reportCard.Messages != null)
            {
                // ReSharper disable once UseStringInterpolation
                result = string.Format(
                    "{0}{1}{2}",
                    reportCard.Title,
                    Environment.NewLine,
                    string.Join(Environment.NewLine, reportCard.Messages.Where(m => m.Severity.Equals("Error")).Select(m => m.Message)));
                return true;
            }

            RestExceptionMessage restException;
            if (new RestExceptionMessageHandler().TryHandle(response, out restException))
            {
                result = restException.Message;
                return true;
            }

            result = SafeGetContent(response);
            return true;
        }

        public sealed class RestExceptionMessageHandler : JsonResponseHandlerBase<RestExceptionMessage>
        {
            protected override bool CanConvert(JObject item)
            {
                return ContainsKey(item, "message", StringComparison.OrdinalIgnoreCase);
            }

            public static bool ContainsKey<T>(IDictionary<string, T> dictionary, string key, StringComparison comparison)
            {
                return dictionary.Keys.Any(k => k.Equals(key, comparison));
            }
        }
    }
}
