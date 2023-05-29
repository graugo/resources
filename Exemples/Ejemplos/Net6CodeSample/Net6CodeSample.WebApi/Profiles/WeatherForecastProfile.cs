using AutoMapper;
using Net6CodeSample.Domain;

namespace Net6CodeSample.WebApi.Profiles
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecastEntity, WeatherForecast>().ReverseMap();
        }
    }
}
