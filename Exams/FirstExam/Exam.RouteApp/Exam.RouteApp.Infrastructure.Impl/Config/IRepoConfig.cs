using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Config
{
    public interface IRepoConfig
    {
        string SindicateApiUrl { get; }
        string EmpireApiUrl { get; }
    }
}
