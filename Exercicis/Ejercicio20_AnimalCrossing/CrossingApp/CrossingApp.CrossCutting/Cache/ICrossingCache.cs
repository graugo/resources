namespace CrossingApp.CrossCutting.Cache
{
    public interface ICrossingCache
    {
        Task<T> GetAsync<T>(string key);
        Task<bool> SetAsync<T>(string key, T value, TimeSpan expiration);
    }
}
