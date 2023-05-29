using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.CrossCutting.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetAsync<T>(CacheKeys key)
        {
            if (_memoryCache.TryGetValue(key, out T value))
                return value;
            return default;
        }

        public void SetAsync<T>(CacheKeys key, T value, TimeSpan time)
        {
            _memoryCache.Set(key, value, time);
        }

        public async Task<T> GetOrAddAsync<T>(CacheKeys key, T value, TimeSpan time) 
        {
            return await _memoryCache.GetOrCreateAsync(key, cache => 
            {
                cache.SetAbsoluteExpiration(time);

                return Task.Run(() => value);
            });
        }
    }
}
