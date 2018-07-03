using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ApprendaAPIClient.Services;

namespace ApprendaAPIClient.Clients
{
    /// <summary>
    /// Version of the API client which can get injected with a reporter to send information back about requests
    /// </summary>
    internal class ApprendaTattletaleApiClient : ApprendaApiClient.ApprendaApiClient
    {
        private readonly ITelemetryReportingService _reportingService;

        public ApprendaTattletaleApiClient(IConnectionSettings connectionSettings, ITelemetryReportingService reportingService)
            : base(connectionSettings)
        {
            _reportingService = reportingService;
        }

        public ApprendaTattletaleApiClient(IConnectionSettings connectionSettings, IRestSession restSession, ITelemetryReportingService reportingService)
            : base(connectionSettings, restSession)
        {
            _reportingService = reportingService;
        }

        public ApprendaTattletaleApiClient(string sessionToken, ITelemetryReportingService reportingService)
            : base(sessionToken)
        {
            _reportingService = reportingService;
        }

        protected override async Task<T> GetResultAsync<T>(string path, string helperType, [CallerMemberName] string callingMethod = "")
        {
            var tags = new List<string> { "clientcall", callingMethod, "get" };
            await _reportingService.ReportInfo("Starting GET request to " + path, tags);
            try
            {
                var res = await base.GetResultAsync<T>(path, helperType);
                await _reportingService.ReportInfo("Finished GET request to " + path, tags);

                return res;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "get" });
                throw;
            }
        }

        protected override async Task<bool> DeleteAsync(string path, string helperType, string callingMethod = "")
        {
            var tags = new List<string> { "clientcall", callingMethod };
            await _reportingService.ReportInfo("Starting DELETE request to " + path, tags);
            try
            {
                // ReSharper disable once ExplicitCallerInfoArgument
                var res = await base.DeleteAsync(path, helperType, callingMethod);
                await _reportingService.ReportInfo("Finished DELETE request to " + path, tags);

                return res;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "delete" });
                throw;
            }
        }

        protected override async Task<bool> DeleteAsync(string path, object body, string helperType, string callingMethod = "")
        {
            var tags = new List<string> { "clientcall", callingMethod };
            await _reportingService.ReportInfo("Starting DELETE request to " + path, tags);
            try
            {
                // ReSharper disable once ExplicitCallerInfoArgument
                var res = await base.DeleteAsync(path, body, helperType, callingMethod);
                await _reportingService.ReportInfo("Finished DELETE request to " + path, tags);

                return res;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "delete" });
                throw;
            }
        }

        protected override async Task<T> PostAsync<T>(string path, object body, string helperType,
            object queryParams = null, string callingMethod = "")
        {
            var tags = new List<string> { "clientcall", callingMethod };
            await _reportingService.ReportInfo("Starting POST request to " + path, tags);
            try
            {
                var res = await base.PostAsync<T>(path, body, helperType, queryParams);
                await _reportingService.ReportInfo("Finished POST request to " + path, tags);

                return res;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "post" });
                throw;
            }
        }

        protected override async Task<T> PostBinaryAsync<T>(string path, byte[] file, object queryParams, string helperType,
            string callingMethod = "")
        {
            var tags = new List<string> { "clientcall", callingMethod };
            await _reportingService.ReportInfo("Starting binary POST request to " + path, tags);
            try
            {
                // ReSharper disable once ExplicitCallerInfoArgument
                var res = await base.PostBinaryAsync<T>(path, file, queryParams, helperType, callingMethod);
                await _reportingService.ReportInfo("Finished binary POST request to " + path, tags);

                return res;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "put" });
                throw;
            }
        }

        protected override async Task<bool> PutVoid(string path, object body, string helperType, object queryParams = null,
            string callingMethod = "")
        {
            var tags = new List<string> { "clientcall", callingMethod };
            await _reportingService.ReportInfo("Starting PUT request to " + path, tags);
            try
            {
                // ReSharper disable once ExplicitCallerInfoArgument
                var res = await base.PutVoid(path, body, helperType, queryParams, callingMethod);
                await _reportingService.ReportInfo("Finished PUT request to " + path, tags);

                return res;
            }
            catch (Exception e)
            {
                await _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "put" });
                throw;
            }
        }

        protected override IEnumerable<T> EnumeratePagedResults<T>(string startUrl, string helperType, Action<string> reportFunction = null, [CallerMemberName] string callingMethod = "")
        {
            Action<string> reportingFunction = async msg =>
            {
                if (_reportingService != null)
                {
                    await _reportingService.ReportInfo(msg, new List<string> { "depaging" });
                }
            };

            try
            {
                // ReSharper disable once ExplicitCallerInfoArgument
                return base.EnumeratePagedResults<T>(startUrl, helperType, reportingFunction, callingMethod);
            }
            catch (Exception e)
            {
                var task = _reportingService.ReportInfo($"Exception thrown {e.Message}",
                    new List<string> { "exception", "get" });
                task.Wait();
                throw;
            }
        }
    }
}
