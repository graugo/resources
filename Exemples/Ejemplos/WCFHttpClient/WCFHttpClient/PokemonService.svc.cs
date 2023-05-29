using log4net;
using System;
using System.Runtime.Remoting.Messaging;
using WCFHttpClient.Extensions;
using WCFHttpClient.Mappers;
using WCFHttpClient.Models.Request;
using WCFHttpClient.Models.Response;
using WCFHttpClient.ServiceLibrary.Contracts.Contracts;

namespace WCFHttpClient
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PokemonService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PokemonService.svc o PokemonService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRetrieveService _pokemonRetrieveService;
        private readonly IMapper _mapper;
        ILog _log;

        public PokemonService(IPokemonRetrieveService pokemonRetrieveService, IMapper mapper, ILog log)
        {
            _pokemonRetrieveService = pokemonRetrieveService;
            _mapper = mapper;
            _log = log;
        }

        public PokemonResponse RetrievePokemon(PokemonRequest request)
        {
            var pokemon = _pokemonRetrieveService.RetrievePokemon(_mapper.ToPokemonEntity(request));
            var result = _mapper.ToPokemonResponse(pokemon);
            _log.Info($"pokemon name: {pokemon.Name}");

            return result;
        }
    }
}
