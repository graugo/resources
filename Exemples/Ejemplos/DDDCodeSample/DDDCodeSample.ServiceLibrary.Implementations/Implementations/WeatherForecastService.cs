using DDDCodeSample.Infrastructure.Contracts.Contracts;
using DDDCodeSample.Library.Models;
using DDDCodeSample.ServiceLibrary.Contracts.Contracts;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace DDDCodeSample.ServiceLibrary.Implementations.Implementations
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, ILogger<WeatherForecastService> logger)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger;
        }

        public IEnumerable<WeatherForecastEntity> GetWeatherForecast()
        {
            var summaries =_weatherForecastRepository.GetSummaries();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastEntity
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });
        }

        public void GetStorm() 
        {
            try
            {
                _weatherForecastRepository.GetStorm();
            }
            catch (NullReferenceException e)
            {
                _logger.LogError(e.Message);
            }
            catch (NotImplementedException e)
            {
                if(e.Message.Contains("")) 
                    _logger.LogError(e.Message);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new StackOverflowException(e.Message);
            }
            finally 
            {
                //_weatherForecastRepository.Dispose();
                //_weatherForecastRepository.Close();
            }
        }
    }
}
