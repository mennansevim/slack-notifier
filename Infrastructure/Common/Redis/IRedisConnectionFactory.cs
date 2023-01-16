using StackExchange.Redis;

namespace SlackNotifier.Infrastructure.Redis
{
    public interface IRedisConnectionFactory
    {
        IConnectionMultiplexer Connection();
    }
}