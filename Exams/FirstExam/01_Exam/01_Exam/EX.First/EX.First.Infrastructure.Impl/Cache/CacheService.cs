using StackExchange.Redis;
using System;
using System.Runtime.Caching;

namespace EX.First.Infrastructure.Impl.Cache
{
    public class CacheService : ICacheService
    {
        private readonly ObjectCache _memoryCache;

        public CacheService()
        {
            _memoryCache = MemoryCache.Default;
        }

        public T Get<T>(string key)
        {
            return (T) _memoryCache.Get(key);
        }

        public void Set<T>(string key, T value, TimeSpan timeSpan)
        {
            _memoryCache.Set(key, value, DateTimeOffset.UtcNow.Add(timeSpan));
        }
    }
}
