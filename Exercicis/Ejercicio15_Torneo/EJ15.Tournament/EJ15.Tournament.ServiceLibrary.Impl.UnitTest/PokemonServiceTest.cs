using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Library.Models.Pokemon;
using EJ15.Tournament.ServiceLibrary.Impl.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EJ15.Tournament.ServiceLibrary.Impl.UnitTest
{
    public class PokemonServiceTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepositoryMock;

        public PokemonServiceTest()
        {
            _pokemonRepositoryMock= new Mock<IPokemonRepository>();
        }

        [Fact]
        public async Task GetPokemonAsync_OK() 
        {
            //arrange
            _pokemonRepositoryMock.Setup(x=>x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(
            new PokemonEntity 
            {
                Id = 1, 
                Name = "bulbasaur",
                Moves = new List<MoveEntity> 
                {
                    new MoveEntity()
                } 
            });
            var sut = new PokemonService(_pokemonRepositoryMock.Object);
            //act
            var response = await sut.GetPokemonAsync(1);
            //assert
            Assert.NotNull(response);
            Assert.Equal(1, response.Id);
            Assert.Equal("bulbasaur", response.Name);
            Assert.True(response.Moves.Any());
        }

        [Fact]
        public async Task GetPokemonAsync_returnNull() 
        {
            _pokemonRepositoryMock.Setup(x => x.GetPokemonAsync(0)).ReturnsAsync(()=> null);
            var sut = new PokemonService(_pokemonRepositoryMock.Object);
            var result = await sut.GetPokemonAsync(0);

            Assert.Null(result);
        }
    }
}
