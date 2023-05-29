using DDDCodeSample.Library.Models;
using DDDCodeSample.WebApi.Models;

namespace DDDCodeSample.WebApi.Mappers
{
    public class WeatherForecastMapper : IWeatherForecastMapper
    {
        public WeatherForecastEntity ToWeatherForecastEntity(WeatherForecastResponse response)
        {
            return new WeatherForecastEntity 
            {
                Date = response.Date,
                Summary = response.Summary,
                TemperatureC = response.TemperatureC
            };
        }

        public WeatherForecastResponse ToWeatherForecastResponse(WeatherForecastEntity entity)
        {
            return new WeatherForecastResponse 
            {
                Date = entity.Date,
                Summary = entity.Summary,
                TemperatureC = entity.TemperatureC,
                TemperatureF = entity.TemperatureF
            };
        }
    }
}
