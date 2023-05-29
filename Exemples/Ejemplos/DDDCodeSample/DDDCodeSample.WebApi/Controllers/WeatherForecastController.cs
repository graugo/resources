using DDDCodeSample.ServiceLibrary.Contracts.Contracts;
using DDDCodeSample.WebApi.Mappers;
using DDDCodeSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DDDCodeSample.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IWeatherForecastMapper _mapper;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
                                         IWeatherForecastService weatherForecastService,
                                         IWeatherForecastMapper mapper)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var result = _weatherForecastService.GetWeatherForecast()
                                                .Select(item => _mapper.ToWeatherForecastResponse(item));
                
            return Ok(result);
        }

        [HttpGet]
        [Route("Storm")]
        public IActionResult GetStorm() 
        {
            _weatherForecastService.GetStorm();
            return Ok();
        }
    }
}