using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryCacheSample.WebApi.Infrastructure
{
    public class RedisClient
    {
        private readonly IDatabase _redisCache;

        public RedisClient()
        {
            var multiplexer = ConnectionMultiplexer.Connect("localhost");
            _redisCache = multiplexer.GetDatabase();
        }

        public T GetValue<T>(string key) 
        {
            var value = _redisCache.StringGet(key);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public void SetValue<T>(string key, T value) 
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            _redisCache.StringSet(key, serializedValue, new TimeSpan(0, 20, 0));
        }
    }
}