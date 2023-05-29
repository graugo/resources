using System.Configuration;

namespace EX.First.Infrastructure.Impl.Configuration
{
    public class InfrastructureConfiguration : IInfrastructureConfiguration
    {
        public string SindicateUrl => _sindicateUrl;

        public string EmpireUrl => _empireUrl;

        private string _empireUrl;
        private string _sindicateUrl;

        public InfrastructureConfiguration()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            _sindicateUrl = ConfigurationManager.AppSettings["SindicateUrl"];
            _empireUrl = ConfigurationManager.AppSettings["EmpireUrl"];
        }
    }
}
