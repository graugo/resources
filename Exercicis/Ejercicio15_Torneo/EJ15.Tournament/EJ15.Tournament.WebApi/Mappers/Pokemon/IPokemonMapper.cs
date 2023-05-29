using EJ15.Tournament.Library.Models.Pokemon;
using EJ15.Tournament.WebApi.Models.Response.Pokemon;

namespace EJ15.Tournament.WebApi.Mappers.Pokemon
{
    public interface IPokemonMapper
    {
        PokemonResponse ToPokemonResponse(PokemonEntity entity);
        MoveResponse ToMoveResponse(MoveEntity entity);
    }
}
