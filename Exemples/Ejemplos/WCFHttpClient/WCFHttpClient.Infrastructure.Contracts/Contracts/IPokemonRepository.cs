using WCFHttpClient.Library.Entity;

namespace WCFHttpClient.Infrastructure.Contracts.Contracts
{
    public interface IPokemonRepository
    {
        PokemonEntity RetrievePokemon(string name, int id);
    }
}
