using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.Callers
{
    public interface ITypedHttpClient
    {
        public Task<T> GetAsync<T>(string path);
    }
}
