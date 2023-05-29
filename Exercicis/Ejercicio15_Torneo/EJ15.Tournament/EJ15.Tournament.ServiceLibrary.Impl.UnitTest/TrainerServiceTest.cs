using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Library.Models.Pokemon;
using EJ15.Tournament.ServiceLibrary.Impl.Configuration;
using EJ15.Tournament.ServiceLibrary.Impl.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EJ15.Tournament.ServiceLibrary.Impl.UnitTest
{
    public class TrainerServiceTest
    {
        private readonly Mock<IPokemonRepository> _pokemonRepositoryMock;
        private readonly Mock<IServiceConfiguration> _serviceConfigurationMock;
        private readonly Mock<ITrainerRepository> _trainerRepositoryMock;

        public TrainerServiceTest()
        {
            _pokemonRepositoryMock= new Mock<IPokemonRepository>();
            _serviceConfigurationMock= new Mock<IServiceConfiguration>();
            _trainerRepositoryMock= new Mock<ITrainerRepository>();

            SetCommonMocks();
        }

        /*
         OK
            - when move id is informed
            - when move name is informed
         When GeneratePokemonList returns null or empty list
         When SetMove doesnt set moves
         */

        [Fact]
        public async Task CreateTrainer_Ok_WhenMoveId() 
        {
            _pokemonRepositoryMock.Setup(x=> x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(new PokemonEntity 
            {
                Id = 1,
                Name = "bulbasaur",
                Moves = new List<MoveEntity>
                {
                    new MoveEntity
                    {
                        Id = 1
                    }
                }
            });
            _pokemonRepositoryMock.Setup(x => x.GetMoveAsync(It.IsAny<int>(), null)).ReturnsAsync(new MoveEntity { Id = 1});
            
            var sut = new TrainerService(_pokemonRepositoryMock.Object, _serviceConfigurationMock.Object, _trainerRepositoryMock.Object);

            var result = await sut.CreateTrainer();

            Assert.True(result != default);
        }

        [Fact]
        public async Task CreateTrainer_OK_WhenMoveName() 
        {
            _pokemonRepositoryMock.Setup(x => x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(new PokemonEntity
            {
                Id = 1,
                Name = "bulbasaur",
                Moves = new List<MoveEntity>
                {
                    new MoveEntity
                    {
                        Name = "pound"
                    }
                }
            });
            _pokemonRepositoryMock.Setup(x => x.GetMoveAsync(null, It.IsAny<string>())).ReturnsAsync(new MoveEntity { Name = "pound" });
      
            var sut = new TrainerService(_pokemonRepositoryMock.Object, _serviceConfigurationMock.Object, _trainerRepositoryMock.Object);

            var result = await sut.CreateTrainer();

            Assert.True(result != default);
        }

        [Fact]
        public async Task CreateTrainer_DefaultGuid_WhenPokemonNull() 
        {
            _pokemonRepositoryMock.Setup(x => x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            var sut = new TrainerService(_pokemonRepositoryMock.Object, _serviceConfigurationMock.Object, null);

            var result = await sut.CreateTrainer();

            Assert.True(result == default);
            _trainerRepositoryMock.Verify(x => x.SetTrainer(It.IsAny<TrainerEntity>()), Times.Never);
        }

        [Fact]
        public async Task CreateTrainer_DefaultGuid_WhenMoveAreNull() 
        {
            _pokemonRepositoryMock.Setup(x => x.GetPokemonAsync(It.IsAny<int>())).ReturnsAsync(() => {
                return new PokemonEntity
                {
                    Id = 1,
                    Name = "bulbasaur",
                    Moves = new List<MoveEntity>
                {
                    new MoveEntity
                    {
                        Id = 1
                    }
                }
                };
            });
            _pokemonRepositoryMock.Setup(x => x.GetMoveAsync(It.IsAny<int>(), null)).ReturnsAsync(() => null);
            var sut = new TrainerService(_pokemonRepositoryMock.Object, _serviceConfigurationMock.Object, null);

            var result = await sut.CreateTrainer();

            Assert.True(result == default);
            _trainerRepositoryMock.Verify(x => x.SetTrainer(It.IsAny<TrainerEntity>()), Times.Never);

        }

        private void SetCommonMocks() 
        {
            _serviceConfigurationMock.Setup(x => x.MinValueRandom).Returns(1);
            _serviceConfigurationMock.Setup(x => x.MaxValueRandom).Returns(152);
            _trainerRepositoryMock.Setup(x => x.SetTrainer(It.IsAny<TrainerEntity>()));
        }

    }
}
