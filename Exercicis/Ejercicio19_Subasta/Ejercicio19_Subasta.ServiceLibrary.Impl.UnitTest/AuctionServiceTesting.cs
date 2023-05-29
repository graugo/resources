using Ejercicio19_Subasta.Application.Implementation;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using Moq;

namespace Ejercicio19_Subasta.ServiceLibrary.Impl.UnitTest
{
    public class AuctionServiceTesting
    {
        private Mock<IPokemonRepository> _pokemonRepository;
        private Mock<IBidRepository> _bidRepository;

        public AuctionServiceTesting()
        {
            _pokemonRepository = new Mock<IPokemonRepository>();
            _bidRepository = new Mock<IBidRepository>();
        }

        [Fact]
        public void RegisterAuction_Ok()
        {
            _pokemonRepository.Setup(x => x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(GetPokemon());
            _pokemonRepository.Setup(x => x.GetLocationAreaAsync(It.IsAny<int>())).ReturnsAsync(GetLocation());
            _pokemonRepository.Setup(x => x.GetDetailsAsync(It.IsAny<PokemonSpecieEntity>(), It.IsAny<LocationEntity>())).ReturnsAsync(GetDetails());
            _bidRepository.Setup(x => x.GetActualAuctions()).Returns(GetAuctions());

            var sut = new AuctionService(_pokemonRepository.Object, _bidRepository.Object);

            var result = sut.Register();

            Assert.True(result.Result);
        }

        [Fact]
        public void RegisterAuction_WhenDetailsIsNull()
        {
            _pokemonRepository.Setup(x => x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(GetPokemon());
            _pokemonRepository.Setup(x => x.GetLocationAreaAsync(It.IsAny<int>())).ReturnsAsync(GetLocation());
            _pokemonRepository.Setup(x => x.GetDetailsAsync(It.IsAny<PokemonSpecieEntity>(), It.IsAny<LocationEntity>())).ReturnsAsync(() => null);
            _bidRepository.Setup(x => x.GetActualAuctions()).Returns(GetAuctions());

            var sut = new AuctionService(_pokemonRepository.Object, _bidRepository.Object);

            var result = sut.Register();

            Assert.False(result.Result);
        }
        private List<AuctionEntity> GetAuctions()
        {
            return new List<AuctionEntity> {
                new AuctionEntity
                {
                    AuctionId = 1,
                    AuctionName = "Auction:1",
                    EntryPrice = 123,
                    ActualPrice = 123,
                    PokemonLocationId = 1,
                    NumberBid = 1,
                    Created = DateTime.Now.TimeOfDay,
                    IsShiny = true
                }
            };
        }

        private PokemonLocationEntity GetDetails()
        {
            return new PokemonLocationEntity
            {
                LocationId = 130,
                PokemonId = 92,
                Level = 12,
                MaxChance = 100
            };
        }
        private PokemonSpecieEntity GetPokemon()
        {
            return new PokemonSpecieEntity
            {
                PokemonIdentifier = 92,
                Name = "gastly",
                Weight = 1,
                Height = 13
            };
        }
        private LocationEntity GetLocation()
        {
            return new LocationEntity
            {
                Name = "old-chateau-2f-leftmost-room",
                URL = "dsadf/130/"
            };
        }
    }
}