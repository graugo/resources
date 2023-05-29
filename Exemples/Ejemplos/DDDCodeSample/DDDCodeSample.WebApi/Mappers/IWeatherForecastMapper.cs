using DDDCodeSample.Library.Models;
using DDDCodeSample.WebApi.Models;

namespace DDDCodeSample.WebApi.Mappers
{
    public interface IWeatherForecastMapper
    {
        WeatherForecastResponse ToWeatherForecastResponse(WeatherForecastEntity entity);
        WeatherForecastEntity ToWeatherForecastEntity(WeatherForecastResponse response);
    }
}