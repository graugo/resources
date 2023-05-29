namespace CrossingApp.Infrastructure.Callers
{
    public interface ITypedHttpClient
    {
        public Task<T> GetAsync<T>(string path);
    }
}
