using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.CrossCutting.Cache
{
    public interface ICacheService
    {
        public T GetAsync<T>(CacheKeys key);
        public void SetAsync<T>(CacheKeys key, T value, TimeSpan time);
    }
}
