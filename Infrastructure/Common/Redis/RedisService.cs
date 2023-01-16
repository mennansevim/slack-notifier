using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using StackExchange.Redis;

namespace SlackNotifier.Infrastructure.Redis
{
    public class RedisService : IRedisService
    {
        private readonly ILogger<RedisService> _logger;
        private readonly IDatabase _database;
        private readonly IConfiguration _configuration;

        public RedisService(IRedisConnectionFactory redisConnectionFactory, ILogger<RedisService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _database = redisConnectionFactory.Connection().GetDatabase() ?? throw new ArgumentNullException();
        }

        public async Task SetAsync(string key, string value)
        {
            var pushFrequencySeconds = TimeSpan.FromSeconds(Convert.ToInt32(_configuration["SlackPushFrequencySeconds"]));
            await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan) => { _logger.LogInformation("Redis retry attempt" + exception.Message); }
                )
                .ExecuteAsync(() => _database.StringSetAsync(key, value, pushFrequencySeconds));
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var result = await Policy
                .Handle<RedisConnectionException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan) => { _logger.LogInformation("Redis retry attempt" + exception.Message); }
                )
                .ExecuteAsync(async () =>
                {
                    var value = await _database.StringGetAsync(key);
                    return !value.IsNull ? (T)Convert.ChangeType(value, typeof(T)) : default;
                });

            return result;
        }

        public async Task DeleteKeyAsync(string key)
        {
            await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan) => { _logger.LogInformation("Redis retry attempt" + exception.Message); }
                )
                .ExecuteAsync(() => _database.KeyDeleteAsync(key));
        }
    }
}