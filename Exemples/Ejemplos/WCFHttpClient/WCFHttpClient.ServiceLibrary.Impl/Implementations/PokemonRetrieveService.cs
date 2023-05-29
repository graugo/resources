using log4net;
using WCFHttpClient.Infrastructure.Contracts.Contracts;
using WCFHttpClient.Library.Entity;
using WCFHttpClient.ServiceLibrary.Contracts.Contracts;

namespace WCFHttpClient.ServiceLibrary.Impl.Implementations
{
    public class PokemonRetrieveService : IPokemonRetrieveService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ILog _log;

        public PokemonRetrieveService(IPokemonRepository pokemonRepository, ILog log)
        {
            _pokemonRepository = pokemonRepository; 
            _log = log;
        }

        public PokemonEntity RetrievePokemon(PokemonEntity pokemon)
        {
            PokemonEntity result = new PokemonEntity();
            try
            {
                result = _pokemonRepository.RetrievePokemon(pokemon.Name, pokemon.Id);
            }
            catch (System.Exception e)
            {
                _log.Error(e.Message);
                result.Error = e.Message;
            }
            
            return result;
        }
    }
}
