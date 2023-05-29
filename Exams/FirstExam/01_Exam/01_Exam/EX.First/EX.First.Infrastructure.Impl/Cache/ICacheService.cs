using EX.First.Infrastructure.Impl.Models;
using System;
using System.Collections.Generic;

namespace EX.First.Infrastructure.Impl.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan timeSpan);
    }
}
