using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using SlackNotifier.Infrastructure.Configurations;
using StackExchange.Redis;

namespace SlackNotifier.Infrastructure.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<ConnectionMultiplexer> _connection;


        public RedisConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(Configuration));
        }

        private ConfigurationOptions Configuration
        {
            get
            {
                var connectionTimeout = 30000;
                var redisConfiguration = new RedisConfiguration();
                _configuration.GetSection(RedisConfiguration.Redis).Bind(redisConfiguration);
                
                var configuration = new ConfigurationOptions
                {
                    Password = redisConfiguration.Password,
                    ConnectTimeout = connectionTimeout
                };

                var hosts = redisConfiguration.Host.Split(',');
                foreach (var host in hosts)
                {
                    configuration.EndPoints.Add(new DnsEndPoint(host, Convert.ToInt32(redisConfiguration.Port)));
                }

                return configuration;
            }
        }

        public IConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
    }
}