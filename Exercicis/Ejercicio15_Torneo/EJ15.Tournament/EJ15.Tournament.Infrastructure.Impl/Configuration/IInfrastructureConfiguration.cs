namespace EJ15.Tournament.Infrastructure.Impl.Configuration
{
    public interface IInfrastructureConfiguration
    {
        string PokeApiUrl { get; }
        string FileName { get; }
        string Directory { get; }
    }
}
