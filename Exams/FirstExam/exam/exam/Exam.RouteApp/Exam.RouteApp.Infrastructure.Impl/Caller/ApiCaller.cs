using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Caller
{
    public class ApiCaller : IApiCaller
    {
        private readonly HttpClient _client;

        public ApiCaller(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(content);
            }

            return default(T);
        }
    }
}
