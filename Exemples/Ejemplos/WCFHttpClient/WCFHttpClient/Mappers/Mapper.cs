using System;
using WCFHttpClient.Library.Entity;
using WCFHttpClient.Models.Request;
using WCFHttpClient.Models.Response;

namespace WCFHttpClient.Mappers
{
    public class Mapper : IMapper
    {
        public PokemonEntity ToPokemonEntity(PokemonRequest request)
        {
            return new PokemonEntity 
            {
                Id= request.Id,
                Name= request.Name
            };
        }

        public PokemonResponse ToPokemonResponse(PokemonEntity entity)
        {
            return new PokemonResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                PokemonType = entity.GetTypesName(),
                Error = entity.Error
            };
        }
    }
}