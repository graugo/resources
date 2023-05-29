using System.Configuration;

namespace WCFHttpClient.Infrastructure.Impl.Configuration
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public string UrlPokeApi => urlPokeApi;

        private string urlPokeApi;

        public RepositoryConfiguration()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            urlPokeApi = ConfigurationManager.AppSettings["UrlPokeApi"];
        }
    }
}
