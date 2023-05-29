using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Caller
{
    public interface IApiCaller
    {
        Task<T> GetAsync<T>(string url);
    }
}
