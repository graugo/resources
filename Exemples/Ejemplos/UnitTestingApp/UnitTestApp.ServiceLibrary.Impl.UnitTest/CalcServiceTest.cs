using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.Infrastructure.Impl;
using Xunit;

namespace UnitTestApp.ServiceLibrary.Impl.UnitTest
{
    public class CalcServiceTest
    {
        [Theory]
        [InlineData(5, 10, 15)]
        [InlineData(-5, 10, 5)]
        public void Calc_OK(int x, int y, int expected) 
        {
            //a
            //var x = 5;
            //var y = 10;

            //a
            var sut = new CalcService(new CalcRepository());
            var result = sut.Calc(x, y);

            //asserts
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calc_Ok() 
        {
            //a
            var x = 5;
            var y = 10;

            //a
            var sut = new CalcService(new CalcRepository());
            var result = sut.Calc(x, y);

            //asserts
            Assert.Equal(15, result);
        }

        [Fact]
        public void CalcDecimal_OK() 
        {
            var x = 1;
            var calcRepositoryMock = new Mock<ICalcRepository>();

            calcRepositoryMock.Setup(c => c.GetDecimal()).Returns(1.1M);

            var sut = new CalcService(calcRepositoryMock.Object);
            var result = sut.Calc(x);

            Assert.Equal(1.1M, result);
        }
    }
}
