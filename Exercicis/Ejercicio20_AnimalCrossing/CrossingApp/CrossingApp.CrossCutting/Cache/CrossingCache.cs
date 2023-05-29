using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CrossingApp.CrossCutting.Cache
{
    public class CrossingCache : ICrossingCache
    {
        private readonly IDistributedCache _cache;

        public CrossingCache(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<T?> GetAsync<T>(string key)
        {
            try
            {
                var value = await _cache.GetStringAsync(key);
                if (string.IsNullOrEmpty(value)) return default;
                return JsonSerializer.Deserialize<T>(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            try
            {
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(expiration);
                var serializedValue = JsonSerializer.Serialize(value);
                await _cache.SetStringAsync(key, serializedValue, options);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
