using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Ejercicio19_Subasta.CrossCutting.Redis
{
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);
            return string.IsNullOrEmpty(value) ? default : JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan time)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(time);
            var valueJson = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, valueJson, options);
        }
    }
}
