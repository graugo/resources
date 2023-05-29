using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.CrossCutting.Redis
{
    public interface IRedisCache
    {
        Task SetAsync<T>(string key, T value, TimeSpan time);
        Task<T> GetAsync<T>(string key);
    }
}
