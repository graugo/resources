using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Net6CodeSample.Application.Contracts;
using Net6CodeSample.Domain;

namespace Net6CodeSample.WebApi.Controllers;
/// <summary>
/// Test api
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;
    private readonly IMapper _mapper;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
                                     IWeatherForecastService weatherForecastService,
                                     IMapper mapper)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
        _mapper = mapper;
    }

    /// <summary>
    /// Get random WeatherForecast
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        var weather = await _weatherForecastService.GetAsync();
        var result = _mapper.Map<List<WeatherForecast>>(weather);
        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    [Route("GetHistoric")]
    public IActionResult GetHistoric() 
    {
        var historic = _weatherForecastService.GetHistoric();
        var result = _mapper.Map<List<WeatherForecast>>(historic);

        return Ok(result);
    }
}
