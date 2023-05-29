using System.Configuration;

namespace EJ15.Tournament.Infrastructure.Impl.Configuration
{
    public class InfrastructureConfiguration : IInfrastructureConfiguration
    {
        public string PokeApiUrl => _pokeApiUrl;

        public string FileName => _fileName;

        public string Directory => _directory;

        private string _pokeApiUrl;
        private string _fileName;
        private string _directory;

        public InfrastructureConfiguration()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            _pokeApiUrl = ConfigurationManager.AppSettings["PokeApiUrl"];
            _fileName = ConfigurationManager.AppSettings["FileName"];
            _directory = ConfigurationManager.AppSettings["Directory"];
        }
    }
}
