using DDDCodeSample.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCodeSample.ServiceLibrary.Contracts.Contracts
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecastEntity> GetWeatherForecast();
        public void GetStorm();
    }
}
