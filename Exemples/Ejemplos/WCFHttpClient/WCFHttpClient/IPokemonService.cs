using System.ServiceModel;
using WCFHttpClient.Models.Request;
using WCFHttpClient.Models.Response;

namespace WCFHttpClient
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPokemonService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPokemonService
    {
        [OperationContract]
        PokemonResponse RetrievePokemon(PokemonRequest request);
    }
}
