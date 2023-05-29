using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Config
{
    public class RepoConfig : IRepoConfig
    {
        public string SindicateApiUrl => _sindicateUrl;
        private string _sindicateUrl;
        public string EmpireApiUrl => _empireUrl;
        private string _empireUrl;

        public RepoConfig()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            _sindicateUrl = ConfigurationManager.AppSettings["SindicateApiUrl"];
            _empireUrl = ConfigurationManager.AppSettings["EmpireApiUrl"];
        }
    }
}
