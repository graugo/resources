using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestApp.Infrastructure.Impl.IntegrationTest
{
    public class HeroFileRepositoryTest
    {
        [Fact]
        public void Save_Ok() 
        {
            var sut = new HeroFileRepository("/results/Heroes.txt");

            var result = sut.Save(new List<string> { "test1", "test2"});

            Assert.True(result);
        }

        [Fact]
        public void Save_ThrowingError() 
        {
            var sut = new HeroFileRepository("");

            Assert.Throws<ArgumentException>(() => sut.Save(new List<string>()));
        }
    }
}
