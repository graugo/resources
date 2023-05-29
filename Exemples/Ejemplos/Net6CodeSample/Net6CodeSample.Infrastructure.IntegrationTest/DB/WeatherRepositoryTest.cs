using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Net6CodeSample.Domain;
using Net6CodeSample.Infranstructure.Context;
using Net6CodeSample.Infranstructure.Dto;
using Net6CodeSample.Infranstructure.Implementations;
using Net6CodeSample.Infrastructure.IntegrationTest.Fixture;

namespace Net6CodeSample.Infrastructure.IntegrationTest.DB
{
    public class WeatherRepositoryTest : ServiceTestProvider
    {
        private readonly IMapper _mapper;
        private readonly WeatherDbContext _dbContext;

        public WeatherRepositoryTest()
        {
            SetServices();
            _mapper = Services.GetRequiredService<IMapper>();
            _dbContext = Services.GetRequiredService<WeatherDbContext>();

        }

        [Fact]
        public async Task Insert_OK()
        {
            var sut = new WeatherRepository(_mapper, _dbContext);
            await sut.InsertHistoricAsync(new List<WeatherForecastEntity> 
            { 
                new WeatherForecastEntity 
                { 
                    Date = DateOnly.FromDateTime(new DateTime(1999,12,5)),
                    Summary = string.Empty,
                    TemperatureC = 32
                } 
            });
            var result = sut.GetHistoric();
            var lastResult = result.LastOrDefault();

            Assert.True(lastResult.Summary == string.Empty && lastResult.Date == new DateOnly(1999,12,5));
        }
    }
}
