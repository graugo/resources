using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using System.Collections.Generic;

namespace EJ15.Tournament.Infrastructure.Impl.Cache
{
    public interface IPokemonCache
    {
        List<PokemonDto> Pokemons { get; }
        List<MoveDto> Moves { get; }

        IEnumerable<PokemonDto> SetPokemons(List<PokemonDto> pokemonDtos);
        IEnumerable<PokemonDto> AddPokemon(PokemonDto pokemonDto);
        IEnumerable<MoveDto> AddMove(MoveDto moveDto);
        IEnumerable<MoveDto> SetMoves(List<MoveDto> moves);
    }
}
