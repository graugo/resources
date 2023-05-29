namespace DDDCodeSample.Infrastructure.Contracts.Contracts
{
    public interface IWeatherForecastRepository
    {
        string[] GetSummaries();

        void GetStorm();
    }
}
