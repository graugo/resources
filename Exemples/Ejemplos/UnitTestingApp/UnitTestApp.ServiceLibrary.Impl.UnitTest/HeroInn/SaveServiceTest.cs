using Moq;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts.Models;
using Xunit;

namespace UnitTestApp.ServiceLibrary.Impl.UnitTest.HeroInn
{
    public class SaveServiceTest
    {
        private Mock<IHeroRepository> _heroRepository;

        public SaveServiceTest()
        {
            _heroRepository = new Mock<IHeroRepository>();
        }

        [Fact]
        public void Save_OK() 
        {
            var hero = new Hero();
            _heroRepository.Setup(x => x.SaveHero(It.IsAny<Hero>())).Returns(true);

            var sut = new SaveService(_heroRepository.Object);
            var result = sut.Save(hero);

            Assert.True(result);
        }

        [Fact]
        public void Save_KO() 
        {
            var hero = new Hero();
            _heroRepository.Setup(x => x.SaveHero(It.IsAny<Hero>())).Returns(false);

            var sut = new SaveService(_heroRepository.Object);
            var result = sut.Save(hero);

            _heroRepository.Verify(x => x.SaveHero(It.IsAny<Hero>()), Times.Once);
            Assert.False(result);
        }

        [Fact]
        public void Save_nullHero() 
        {
            _heroRepository.Setup(x => x.SaveHero(null)).Returns(false);
            var sut = new SaveService(_heroRepository.Object);
            var result = sut.Save(null);

            _heroRepository.Verify(x => x.SaveHero(null), Times.Never);
            Assert.False(result);
        }
    }
}
