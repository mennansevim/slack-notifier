using System.Threading.Tasks;

namespace SlackNotifier.Infrastructure.Redis
{
    public interface IRedisService
    {
        Task SetAsync(string key, string value);

        Task<T?> GetAsync<T>(string key);

        Task DeleteKeyAsync(string key);
    }
}