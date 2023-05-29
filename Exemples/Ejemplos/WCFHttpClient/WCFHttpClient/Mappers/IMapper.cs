using WCFHttpClient.Library.Entity;
using WCFHttpClient.Models.Request;
using WCFHttpClient.Models.Response;

namespace WCFHttpClient.Mappers
{
    public interface IMapper
    {
        PokemonEntity ToPokemonEntity(PokemonRequest request);
        PokemonResponse ToPokemonResponse(PokemonEntity entity);
    }
}
