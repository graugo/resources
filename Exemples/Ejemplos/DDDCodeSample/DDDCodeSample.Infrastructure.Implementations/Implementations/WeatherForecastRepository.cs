using DDDCodeSample.Infrastructure.Contracts.Contracts;
using DDDCodeSample.Library.Exceptions;

namespace DDDCodeSample.Infrastructure.Implementations.Implementations
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public void GetStorm()
        {
            if (false)
                throw new StormException("An Storm");
            else
                throw new NotImplementedException();
        }

        public string[] GetSummaries()
        {
            return new[]
            {
                "Freezing", 
                "Bracing",
                "Chilly", 
                "Cool", 
                "Mild", 
                "Warm", 
                "Balmy", 
                "Hot", 
                "Sweltering", 
                "Scorching"
            };
        }
    }
}
