using System.Threading.Tasks;

namespace EX.First.Infrastructure.Impl.Caller
{
    public interface IApiCaller
    {
        Task<T> GetAsync<T>(string url);
    }
}
