using AutoMapper;
using Net6CodeSample.Domain;
using Net6CodeSample.Infranstructure.Dto;

namespace Net6CodeSample.Infranstructure.Profiles
{
    internal class WeatherForescastDtoProfile : Profile
    {
        public WeatherForescastDtoProfile()
        {
            CreateMap<WeatherForecastEntity, WeatherForecastDto>()
                .ForMember(
                    x => x.Date, 
                    y => y.MapFrom(z => new DateTime(z.Date.Year, z.Date.Month, z.Date.Day)))
                .ReverseMap()
                .ForMember(
                    x => x.Date,
                    y => y.MapFrom(z => new DateOnly(z.Date.Year, z.Date.Month, z.Date.Day))
                );
        }
    }
}
