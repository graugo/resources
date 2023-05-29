using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace EX.First.Infrastructure.Impl.Caller
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
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return default;
        }
    }
}
