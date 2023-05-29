using WCFHttpClient.Library.Entity;

namespace WCFHttpClient.ServiceLibrary.Contracts.Contracts
{
    public interface IPokemonRetrieveService
    {
        PokemonEntity RetrievePokemon(PokemonEntity pokemon);
    }
}
