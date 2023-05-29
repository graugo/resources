using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.CrossCutting.Cache
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);

        Task SetAsync<T>(string key, T value, TimeSpan time);
    }
}
