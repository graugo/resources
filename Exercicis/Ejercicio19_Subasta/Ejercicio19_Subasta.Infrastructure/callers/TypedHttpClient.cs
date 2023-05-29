using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.Callers
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
            try
            {
                var content = string.Empty;
                var call = await _httpClient.GetAsync(_httpClient.BaseAddress+path);
                if (call.IsSuccessStatusCode)
                {
                    content = await call.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(content);
                }
            } catch (Exception ex) { }

            return default;
        }
    }
}
