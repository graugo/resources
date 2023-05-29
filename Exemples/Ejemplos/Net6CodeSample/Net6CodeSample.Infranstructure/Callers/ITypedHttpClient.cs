namespace Net6CodeSample.Infranstructure.Callers
{
    public interface ITypedHttpClient
    {
        public Task<T> GetAsync<T>(string path);
    }
}