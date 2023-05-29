using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts.Models;
using Xunit;

namespace UnitTestApp.ServiceLibrary.Impl.UnitTest.HeroInn
{
    public class PersistServiceTest
    {
        private Mock<IHeroRepository> _heroRepository;
        private Mock<IHeroFileRepository> _heroFileRepository;

        public PersistServiceTest()
        {
            _heroRepository = new Mock<IHeroRepository>();
            _heroFileRepository = new Mock<IHeroFileRepository>();
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        public void Persist_OK(bool save, bool delete, bool expected) 
        {
            //arrange
            _heroRepository.Setup(x => x.GetHeroes()).Returns(new List<Hero> 
            {
                new Hero { Nombre = "a"},
                new Hero { Nombre = "b"}
            }).Verifiable();
            _heroRepository.Setup(x => x.DeleteHero()).Returns(delete).Verifiable();
            _heroFileRepository.Setup(x => x.Save(It.IsAny<List<string>>())).Returns(save).Verifiable();
            var sut = new PersistService(_heroRepository.Object, _heroFileRepository.Object);

            //act
            var result = sut.Persist();

            //asserts
            Assert.Equal(expected ,result);

            _heroFileRepository.VerifyAll();
            _heroRepository.VerifyAll();
        }
    }
}
