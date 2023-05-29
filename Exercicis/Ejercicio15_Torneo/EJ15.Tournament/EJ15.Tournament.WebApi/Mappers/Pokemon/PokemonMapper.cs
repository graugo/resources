using EJ15.Tournament.Library.Models.Pokemon;
using EJ15.Tournament.WebApi.Models.Response.Pokemon;

namespace EJ15.Tournament.WebApi.Mappers.Pokemon
{
    public class PokemonMapper : IPokemonMapper
    {
        public MoveResponse ToMoveResponse(MoveEntity entity)
        {
            return new MoveResponse 
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public PokemonResponse ToPokemonResponse(PokemonEntity entity)
        {
            return new PokemonResponse 
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}