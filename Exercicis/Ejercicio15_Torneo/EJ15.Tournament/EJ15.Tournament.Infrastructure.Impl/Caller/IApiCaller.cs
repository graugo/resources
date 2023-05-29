using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.Infrastructure.Impl.Caller
{
    public interface IApiCaller
    {
        Task<T> GetAsync<T>(string url); 
    }
}
