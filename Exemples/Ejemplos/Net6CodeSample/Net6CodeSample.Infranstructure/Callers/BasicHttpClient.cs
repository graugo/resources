using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Net6CodeSample.Infranstructure.Callers
{
    public class BasicHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasicHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>()
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            var content = string.Empty;
            var call = await client.GetAsync("");
            if (call.IsSuccessStatusCode) 
            {
                content = await call.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }

            return default;

        }
    }
}
