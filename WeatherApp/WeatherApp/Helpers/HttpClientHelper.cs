using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Helpers
{
     public class HttpClientHelper
    {
        private static HttpClient httpClient;

        public HttpClientHelper()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer");
        }

        public async Task<T> PerformGet<T>(string route)
        {
            if (httpClient == null)
            {
                new HttpClientHelper();
            }
            var uri = new Uri(route);
            T Items = JsonConvert.DeserializeObject<T>("");
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<T>(content);
            }
            return Items;
        }
    }
}
