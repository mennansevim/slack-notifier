
namespace SlackNotifier.Infrastructure.Configurations
{
    public class RedisConfiguration
    {
        public const string Redis = "RedisConfiguration";
        public string Host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}