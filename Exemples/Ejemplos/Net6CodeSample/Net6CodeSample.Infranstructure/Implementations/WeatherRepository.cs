using AutoMapper;
using Microsoft.Extensions.Configuration;
using Net6CodeSample.Application.InfrastructureContracts;
using Net6CodeSample.Domain;
using Net6CodeSample.Infranstructure.Callers;
using Net6CodeSample.Infranstructure.Context;
using Net6CodeSample.Infranstructure.Dto;

namespace Net6CodeSample.Infranstructure.Implementations
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITypedHttpClient _client;
        private readonly IConfiguration _config;

        public WeatherRepository(IMapper mapper, WeatherDbContext context, ITypedHttpClient client, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _client = client;
            _config = config;
        }

        public List<WeatherForecastEntity> GetHistoric()
        {
            var result = _context.WeatherForecasts.Where(x => !string.IsNullOrEmpty(x.Summary)).ToList();
            return _mapper.Map<List<WeatherForecastEntity>>(result);
        }

        public async Task InsertHistoricAsync(List<WeatherForecastEntity> weather)
        {
            var url = new Uri(_config["Urls:Empire"]);
            var a = _client.GetAsync<string>("");
            _context.WeatherForecasts.AddRange(_mapper.Map<List<WeatherForecastDto>>(weather));
            await _context.SaveChangesAsync();
        }
    }
}
