using System;
using System.Threading.Tasks;

namespace EX.First.Infrastructure.Contracts
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task<bool> SetAsync<T>(string key, T value, TimeSpan timeSpan);
    }
}