using Microsoft.Extensions.Caching.Memory;

namespace Ejercicio19_Subasta.CrossCutting.Cache
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
            _memoryCache.Set(key, value);
        }
    }
}
