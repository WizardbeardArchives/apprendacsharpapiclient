using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
namespace apprendacsharpcoreapiclient
{
    /// <summary>
    /// Used since .NET core deprecated some methods
    /// </summary>
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string uri, T item)
        {
            return client.PutAsync(uri, new StringContent(JsonConvert.SerializeObject(item)));
        }

        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string uri, T item)
        {
            return client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(item)));
        }

        public static async Task<TResp> ReadAsAsync<TResp>(this HttpContent content)
        {
            var val = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResp>(val);
        }
    }
}
