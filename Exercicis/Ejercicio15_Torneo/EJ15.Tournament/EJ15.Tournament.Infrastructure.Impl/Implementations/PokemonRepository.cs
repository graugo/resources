using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Infrastructure.Impl.Cache;
using EJ15.Tournament.Infrastructure.Impl.Caller;
using EJ15.Tournament.Infrastructure.Impl.Configuration;
using EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon;
using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using EJ15.Tournament.Library.Models.Pokemon;
using log4net;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EJ15.Tournament.Infrastructure.Impl.Implementations
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IApiCaller _apiCaller;
        private readonly IInfrastructureConfiguration _configuration;
        private readonly IPokeApiMapper _mapper;
        private readonly IPokemonCache _pokemonCache;
        private readonly ILog _logger;

        public PokemonRepository(IApiCaller apiCaller, 
                                 IInfrastructureConfiguration configuration, 
                                 IPokeApiMapper mapper,
                                 IPokemonCache  pokemonCache,
                                 ILog logger)
        {
            _apiCaller = apiCaller;
            _configuration = configuration;
            _mapper = mapper;
            _pokemonCache = pokemonCache;
            _logger = logger;
        }

        public async Task<MoveEntity> GetMoveAsync(int? id, string name)
        {
            try
            {
                MoveDto move = null;
                if (_pokemonCache.Moves != null && _pokemonCache.Moves.Any(p => p.Id == id))
                    move = _pokemonCache.Moves.FirstOrDefault(x => x.Id == id);
                else
                { 
                  if(id != null)
                    move = await _apiCaller.GetAsync<MoveDto>($"{_configuration.PokeApiUrl}move/{id}");
                  else
                  {
                    move = await _apiCaller.GetAsync<MoveDto>($"{_configuration.PokeApiUrl}move/{name}");
                  }
                }
                if (move == null)
                    return null;
                _pokemonCache.AddMove(move);
                _logger.Info("Move save on cache");

                return _mapper.ToMoveEntity(move);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return null;
        }

        public async Task<PokemonEntity> GetPokemonAsync(int id)
        {
            try
            {
                PokemonDto pokemon = null;
                if (_pokemonCache.Pokemons != null && _pokemonCache.Pokemons.Any(p => p.Id == id)) 
                    pokemon = _pokemonCache.Pokemons.FirstOrDefault(x=>x.Id == id);
                else
                    pokemon = await _apiCaller.GetAsync<PokemonDto>($"{_configuration.PokeApiUrl}pokemon/{id}");
                if (pokemon == null) 
                    return null;
                _pokemonCache.AddPokemon(pokemon);

                return _mapper.ToPokemonEntity(pokemon);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return null;          
        }
    }
}
