using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace MemoryCacheSample.WebApi.Infrastructure
{
    public class CacheService
    {
        private readonly ObjectCache _cache;

        public CacheService()
        {
            _cache = MemoryCache.Default;
        }

        public T GetValue<T>(string key) 
        {
            return (T)_cache[key];
        }

        public void SetValue<T>(string key, T value)
        {
            _cache.Set(key, value, DateTimeOffset.UtcNow.Add(new TimeSpan(0, 20, 0)));
        }
    }
}