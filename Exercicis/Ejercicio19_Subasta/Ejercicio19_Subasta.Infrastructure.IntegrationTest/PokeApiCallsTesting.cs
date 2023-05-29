using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.IntegrationTest.IOC;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ejercicio19_Subasta.Infrastructure.IntegrationTest
{
    public class PokeApiCallsTesting
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPokemonRepository _sut;
        public PokeApiCallsTesting()
        {
            var services = InfrastructureTestingModule.AddInfrastructureTestingModule();
            _serviceProvider = services.BuildServiceProvider();
            _sut = _serviceProvider.GetService<IPokemonRepository>();
        }

        // Pokemon repository ok
        [Fact]
        public async Task GetPokemonAsync_Ok()
        {
            int pokemonId = 1;
            var pokemon = await _sut.GetPokemonAsync(pokemonId);
            Assert.NotNull(pokemon);
            Assert.Equal(pokemonId, pokemon.PokemonIdentifier);
        }

        // Pokemon repository ko
        [Fact]
        public async Task GetPokemonAsync_Ko()
        {
            int pokemonId = 0;
            var pokemon = await _sut.GetPokemonAsync(pokemonId);
            Assert.Null(pokemon);
        }

        // Location repository ok
        [Fact]
        public async Task GetLocationAsync_Ok()
        {
            int pokemonId = 1;
            var location = await _sut.GetLocationAreaAsync(pokemonId);
            Assert.NotNull(location);
        }

        // Location repository ko
        [Fact]
        public async Task GetLocationAsync_Ko()
        {
            int pokemonId = 0;
            var location = await _sut.GetLocationAreaAsync(pokemonId);
            Assert.Null(location);
        }

        // Pokemon species repository ok
        [Fact]
        public async Task GetPokemonSpecieAsync_Ok()
        {
            var pokemon = new PokemonSpecieEntity
            {
                PokemonIdentifier = 1,
                Name = "bulbasaur",
            };

            var location = new LocationEntity
            {
                URL = "https://pokeapi.co/api/v2/location-area/281/",
            };
            var pokemonLocation = await _sut.GetDetailsAsync(pokemon, location);
            Assert.NotNull(pokemonLocation);
            Assert.Equal(pokemon.PokemonIdentifier, pokemonLocation.PokemonId);
            Assert.Equal(location.LocationIdentifier, pokemonLocation.LocationId);
        }
        [Fact]
        public async Task GetPokemonSpecieAsync_Ko()
        {
            var pokemon = new PokemonSpecieEntity
            {
                PokemonIdentifier = 1,
                Name = "bulbasaur",
            };
            var location = new LocationEntity
            {
                URL = "https://pokeapi.co/api/v2/location-area/1/",
            };
            var pokemonLocation = await _sut.GetDetailsAsync(pokemon, location);
            Assert.Null(pokemonLocation);
        }
    }
}