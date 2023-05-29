using WCFHttpClient.Infrastructure.Contracts.Models;
using WCFHttpClient.Library.Entity;

namespace WCFHttpClient.Infrastructure.Contracts.Mappers
{
    public interface IRepositoryMapper
    {
        PokemonDTO ToPokemonDTO(PokemonEntity pokemonEntity);
        PokemonEntity ToPokemonEntity(PokemonDTO pokemonDTO);
    }
}
