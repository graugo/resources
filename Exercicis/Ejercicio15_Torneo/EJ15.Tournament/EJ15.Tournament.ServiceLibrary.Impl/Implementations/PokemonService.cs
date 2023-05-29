using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Library.Models.Pokemon;
using EJ15.Tournament.ServiceLibrary.Contracts.Contract;
using System;
using System.Threading.Tasks;

namespace EJ15.Tournament.ServiceLibrary.Impl.Implementations
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<MoveEntity> GetMoveAsync(int id)
        {
            return await _pokemonRepository.GetMoveAsync(id, null);
        }

        public async Task<PokemonEntity> GetPokemonAsync(int id)
        {
            return await _pokemonRepository.GetPokemonAsync(id);
        }

        public Task<TypeEntity> GetTypeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
