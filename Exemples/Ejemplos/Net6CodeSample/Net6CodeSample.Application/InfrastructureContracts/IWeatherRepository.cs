using Net6CodeSample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Application.InfrastructureContracts
{
    public interface IWeatherRepository
    {
        public List<WeatherForecastEntity> GetHistoric();
        public Task InsertHistoricAsync(List<WeatherForecastEntity> weather);
    }
}
