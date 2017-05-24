using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApprendaAPIClient.Models;
using ApprendaAPIClient.Models.DeveloperPortal;
using ApprendaAPIClient.Models.SOC;
using ApprendaAPIClient.Services;
using ApprendaAPIClient.Services.ClientHelpers;
using IO.Swagger.Model;
using Newtonsoft.Json;
using Application = ApprendaAPIClient.Models.DeveloperPortal.Application;
using ByteArrayContent = System.Net.Http.ByteArrayContent;
using Cloud = ApprendaAPIClient.Models.SOC.Cloud;
using Component = ApprendaAPIClient.Models.DeveloperPortal.Component;
using CustomProperty = ApprendaAPIClient.Models.SOC.CustomProperty;
using Version = IO.Swagger.Model.Version;

namespace ApprendaAPIClient.Clients
{
    internal class ApprendaApiClient : BaseApprendaApiClient, IApprendaApiClient
    {
        protected string DevRoot => AppsRoot + "/developer";
        protected string AccountRoot => AppsRoot + "/account";
        protected string SOCRoot => AppsRoot + "/soc";

        public ApprendaApiClient(IConnectionSettings connectionSettings)
            : base(connectionSettings)
        {
        }

        public Task<IEnumerable<Application>> GetApplications()
        {
            return GetResultAsync<IEnumerable<Application>>("apps");
        }

        public Task<EnrichedApplication> GetApplication(string appAlias)
        {
            return GetResultAsync<EnrichedApplication>("apps/" + appAlias);
        }

        public Task<bool> PostApp(Application app)
        {
            return PostAsync<bool>("apps", app);
        }

        public Task<bool> DeleteApplication(string appAlias)
        {
            return DeleteAsync("apps/" + appAlias);
        }

        public Task<IEnumerable<Version>> GetVersionsForApplication(string appAlias)
        {
            return GetResultAsync<IEnumerable<Version>>("versions/" + appAlias);
        }

        public Task<EnrichedVersion> GetVersion(string appAlias, string versionAlias)
        {
            return GetResultAsync<EnrichedVersion>("versions/" + appAlias + "/" + versionAlias);
        }

        public Task<IEnumerable<Host>> GetAllHosts()
        {
            return GetResultAsync<IEnumerable<Host>>("hosts", "socinternal");
        }


        public Task<PagedResourceBase<HealthReport>> GetHealthReports(string hostName)
        {
            return GetResultAsync<PagedResourceBase<HealthReport>>($"hosts/{hostName}/healthreports", "soc");
        }

        public Task<PagedResourceBase<CustomProperty>> GetAllCustomProperties()
        {
            return GetResultAsync<PagedResourceBase<CustomProperty>>("customproperties", "soc");
        }

        public Task<CustomProperty> GetCustomProperty(int id)
        {
            return GetResultAsync<CustomProperty>($"customproperties/{id}", "soc");
        }

        public Task<CustomProperty> CreateCustomProperty(CustomProperty customProperty)
        {
            return PostAsync<CustomProperty>("customproperties", customProperty, "soc");
        }

        public Task<bool> UpdateCustomProperty(CustomPropertyUpdate customPropertyUpdate)
        {
            return PutVoid($"customproperties/{customPropertyUpdate.Id}", customPropertyUpdate, "soc");
        }

        public Task<bool> DeleteCustomProperty(int id)
        {
            return DeleteAsync($"customproperties/{id}", "soc");
        }

        public async Task<ReportCard> SetArchive(string appAlias, string versionAlias, bool destructive, byte[] archive)
        {
            var queryParams = new {action = "setArchive", destructive = 1,};
            var res = await PostBinaryAsync<ReportCard>($"versions/{appAlias}/{versionAlias}", archive, queryParams);

            return res;
        }

        public Task<PublishReportCardDTO> PatchVersion(string appAlias, string versionAlias, bool constructive, 
            byte[] file, string newVersionAlias = null, string newVersionName = null,
            string useScalingSettingsFrom = null, bool async = false)
        {
            //https://apps.apprenda.stella/developer/api/v1/versions/archivesearch2017/v1?action=patch&patchMode=constructive&newVersionAlias=&newVersionName=&stage=&accept_override=text/html&async=true

            var queryParams =
                new
                {
                    action = "patch",
                    patchMode = constructive? "constructive": "destructive",
                    async,
                    newVersionAlias,
                    newVersionName,
                    accept_override = "text / html"

                };

            return PostBinaryAsync<PublishReportCardDTO>($"versions/{appAlias}/{versionAlias}", file, queryParams);
        }

        public Task<bool> PromoteVersion(string appAlias, string versionAlias, ApplicationVersionStage desiredStage,
            bool waitForMinInstanceCount = false, bool inheritPublishedScalingSettings = false, bool async = true)
        {
            //https://apps.apprenda.stella/developer/shim/api/v1/versions/archivesearch2017/v1?async=true&shim_action=promote

            var qp = new
            {
                async,
                action = "promote",
                waitForMinInstanceCount,
                stage = desiredStage.ToString(),
                inheritPublishedScalingSettings 
            };

            return PostAsync<bool>($"versions/{appAlias}/{versionAlias}", null, "developer", qp);
        }

        public Task<UnpagedResourceBase<Component>> GetComponents(string appAlias, string versionAlias)
        {
            return GetResultAsync<UnpagedResourceBase<Component>>(
                $"apps/{appAlias}/versions/{versionAlias}/components");
        }

        public Task<UnpagedResourceBase<Cloud>> GetClouds()
        {
            return GetResultAsync<UnpagedResourceBase<Cloud>>("clouds", "soc");
        }

        public Task<Cloud> GetCloud(int id)
        {
            return GetResultAsync<Cloud>($"clouds/{id}", "soc");
        }

        public Task<EnvironmentVariableData> GetEnvironmentVariables(string appAlias, string versionAlias, string componentAlias)
        {
            return GetResultAsync<EnvironmentVariableData>(
                $"apps/{appAlias}/versions/{versionAlias}/components/{componentAlias}/environmentvariables");
        }


        public Task<bool> SetEnvironmentVariable(string appAlias, string versionAlias, string componentAlias, EnvironmentVariableData data)
        {
            return PutVoid($"apps/{appAlias}/versions/{versionAlias}/components/{componentAlias}/environmentvariables", data);
        }


        protected virtual async Task<T> GetResultAsync<T>(string path, string helperType = "developer", [CallerMemberName] string callingMethod = "")
        {
            var helper = helperType == "socinternal"
                ? (IRestApiClientHelper) new InternalSOCHelper(ConnectionSettings, "soc") 
                :  new GenericApiHelper(ConnectionSettings, helperType);

            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path);
            var client = GetClient(uri, SessionToken);

            var res = await client.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(res);
        }

        protected virtual async Task<bool> DeleteAsync(string path, string helperType = "developer",
            [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);
            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path);
            var client = GetClient(uri, SessionToken);

            var res = await client.DeleteAsync(uri);

            return res.IsSuccessStatusCode;
        }

        protected virtual async Task<T> PostAsync<T>(string path, object body, string helperType = "developer",
           object queryParams = null, [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);
            var uri = new ClientUriBuilder(helper.ApiRoot).BuildUri(path, null, queryParams);

            var value = JsonConvert.SerializeObject(body);
            string res;
            using (var wc = new WebClient())
            {
                wc.Headers.Add("ApprendaSessionToken", SessionToken);
                wc.Headers.Add("Content-Type", "application/json");
                res = await wc.UploadStringTaskAsync(uri, value);
            }

            return string.IsNullOrWhiteSpace(res) 
                ? default(T)
                : JsonConvert.DeserializeObject<T>(res);
        }

        protected virtual async Task<T> PostBinaryAsync<T>(string path, 
            byte[] file, object queryParams,
            string helperType = "developer", [CallerMemberName] string callingMethod = "")
        {
            var helper = new GenericApiHelper(ConnectionSettings, helperType);

            var builder = new ClientUriBuilder(helper.ApiRoot);
            var uri =  builder.BuildUri(path, null, queryParams);

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

        protected virtual async Task<bool> PutVoid(string path, object body, string helperType = "developer",
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
