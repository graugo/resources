using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Net6CodeSample.Infranstructure.Callers
{
    public class TypedHttpClient : ITypedHttpClient
    {
        private HttpClient _httpClient;

        public TypedHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string path) 
        {
            var content = string.Empty;
            var call = await _httpClient.GetAsync(path);
            if (call.IsSuccessStatusCode) 
            {
                content= await call.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }

            return default;
        }
    }
}
