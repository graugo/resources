using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using EJ15.Tournament.Library.Models.Pokemon;

namespace EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon
{
    public interface IPokeApiMapper
    {
        PokemonEntity ToPokemonEntity(PokemonDto dto);
        MoveEntity ToMoveEntity(MoveDto dto);
        PokemonDto ToPokemonDto(PokemonEntity entity);
    }
}
