using Microsoft.Extensions.Options;
using Net6CodeSample.Application.Contracts;
using Net6CodeSample.Application.InfrastructureContracts;
using Net6CodeSample.CrossCutting.Cache;
using Net6CodeSample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Application.Implementations
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly SummariesEntity _summaries;
        private readonly ICacheService _cacheService;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastService(IOptions<SummariesEntity> options, 
                                      ICacheService cacheService, 
                                      IRedisCacheService redisCacheService,
                                      IWeatherRepository weatherRepository)
        {
            _summaries = options.Value;
            _cacheService = cacheService;
            _redisCacheService = redisCacheService;
            _weatherRepository = weatherRepository;
        }

        public async Task<List<WeatherForecastEntity>> GetAsync()
        {
            var weather = await _redisCacheService.GetAsync<List<WeatherForecastEntity>>(CacheKeys.Key1.ToString());
            if(weather == null)
            {
                var rnd = Random.Shared.Next(_summaries.Summaries.Count);
                weather = Enumerable.Range(1,5).Select(x => new WeatherForecastEntity
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(x)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = _summaries.Summaries[x]
                }).ToList();

                await _redisCacheService.SetAsync(CacheKeys.Key1.ToString(), weather, new TimeSpan(0, 0, 20));
                await _weatherRepository.InsertHistoricAsync(weather);
            }
            
            return weather;
        }

        public List<WeatherForecastEntity> GetHistoric() 
        {
            return _weatherRepository.GetHistoric();
        }
    }
}
