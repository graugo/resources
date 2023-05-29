using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using System.Collections.Generic;

namespace EJ15.Tournament.Infrastructure.Impl.Cache
{
    public class PokemonCache : IPokemonCache
    {
        public List<PokemonDto> Pokemons => _pokemons;
        public List<MoveDto> Moves => _moves;

        private List<PokemonDto> _pokemons;
        private List<MoveDto> _moves;

        public PokemonCache()
        {
            _pokemons = _pokemons ?? new List<PokemonDto>();
            _moves = _moves ?? new List<MoveDto>();
        }

        public IEnumerable<PokemonDto> SetPokemons(List<PokemonDto> pokemonDtos)
        {
            if (_pokemons == null)
            {
                _pokemons = pokemonDtos;
            }

            return _pokemons;
        }

        public IEnumerable<PokemonDto> AddPokemon(PokemonDto pokemonDto) 
        {
            if (_pokemons != null)
            {
                _pokemons.Add(pokemonDto);
            }

            return _pokemons;   
        }
        public IEnumerable<MoveDto> SetMoves(List<MoveDto> moveDtos)
        {
            if (_moves == null)
            {
                _moves = moveDtos;
            }

            return _moves;
        }

        public IEnumerable<MoveDto> AddMove(MoveDto move)
        {
            if (_moves != null)
            {
                _moves.Add(move);
            }

            return _moves;
        }
    }
}
