using log4net;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using WCFHttpClient.Infrastructure.Contracts.Contracts;
using WCFHttpClient.Infrastructure.Contracts.Mappers;
using WCFHttpClient.Infrastructure.Contracts.Models;
using WCFHttpClient.Infrastructure.Impl.Configuration;
using WCFHttpClient.Library.Entity;

namespace WCFHttpClient.Infrastructure.Impl
{
    public class PokemonRepository : IPokemonRepository
    {
        private HttpClient _client;
        private readonly IRepositoryMapper _mapper;
        private readonly ILog _log;
        private readonly IRepositoryConfiguration _configuration;

        public PokemonRepository(HttpClient client, 
                                 IRepositoryMapper mapper, 
                                 ILog log, 
                                 IRepositoryConfiguration configuration)
        {
            _client = client;
            _mapper = mapper;
            _log = log;
            _configuration = configuration;
        }

        public PokemonEntity RetrievePokemon(string name, int id)
        {
            try
            {
                var content = string.Empty;
                HttpResponseMessage response;
                if (!string.IsNullOrEmpty(name))
                    response = _client.GetAsync($"{_configuration.UrlPokeApi}{name}").Result;
                else
                    response = _client.GetAsync($"{_configuration.UrlPokeApi}{id}").Result;
                content = response.Content.ReadAsStringAsync().Result;

                var pokemon = JsonConvert.DeserializeObject<PokemonDTO>(content);

                return _mapper.ToPokemonEntity(pokemon);
            }
            catch (System.Exception e)
            {
                _log.Error("PokemonRepository: "+e.Message);
                throw;
            }
            
        }
    }
}
