using EX.First.Infrastructure.Contracts;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.First.Infrastructure.Impl.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _redisCache;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _redisCache = connectionMultiplexer.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await  _redisCache.StringGetAsync(key);
            return value.IsNull ? default : JsonConvert.DeserializeObject<T>(value);
        }

        public async Task<bool> SetAsync<T>(string key, T value, TimeSpan timeSpan)
        {
            var valueSerialized = JsonConvert.SerializeObject(value);
            return await _redisCache.StringSetAsync(key, valueSerialized, timeSpan);
        }
    }
}
