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
    public class OrderServiceTest
    {
        private Mock<IHeroRepository> _heroRepository;

        public OrderServiceTest()
        {
            _heroRepository = new Mock<IHeroRepository>();
        }

        [Theory]
        [InlineData("Nombre", "Ascendente", "a")]
        [InlineData("Nombre", "Descendente", "b")]
        [InlineData("nombre", "ascendente", "a")]
        [InlineData(null, "Ascendente", "a")]
        [InlineData(null, "Descendente", "b")]
        [InlineData("nombre", null, "b")]
        public void Order_Ok(string orderFactor, string asc, string expected) 
        {
            _heroRepository.Setup(x => x.GetHeroes()).Returns(GetHeroes());
            var sut = new OrderService(_heroRepository.Object);

            var result = sut.Order(orderFactor, asc);

            Assert.True(result.First().Nombre == expected);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Order_WhenHeroesListIsNull(bool isEmpty) 
        {
            _heroRepository.Setup(x => x.GetHeroes()).Returns(GetNull(isEmpty));
            var sut = new OrderService(_heroRepository.Object);

            var result = sut.Order("nombre", "asc");

            Assert.True(result.Count() == 0);
        }

        private List<Hero> GetNull(bool isEmpty) 
        {
            return isEmpty ? new List<Hero>() : null;
        }

        private List<Hero> GetHeroes() 
        {
            return new List<Hero>
            {
                new Hero
                {
                    Nombre = "b"
                },
                new Hero
                {
                    Nombre = "a"
                }
            };
        }
    }
}
