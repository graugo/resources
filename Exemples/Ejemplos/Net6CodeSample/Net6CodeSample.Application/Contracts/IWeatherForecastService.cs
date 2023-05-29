using Net6CodeSample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Application.Contracts
{
    public interface IWeatherForecastService
    {
        public Task<List<WeatherForecastEntity>> GetAsync();
        public List<WeatherForecastEntity> GetHistoric();
    }
}
