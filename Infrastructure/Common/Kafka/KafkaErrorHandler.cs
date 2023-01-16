using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using SlackNotifier.Application.Producers.Interfaces;
using SlackNotifier.Infrastructure.Utils;

namespace SlackNotifier.Infrastructure.ErrorHandling
{
    public class KafkaErrorHandler : IKafkaErrorHandler
    {
        private readonly IKafkaProducer _producer;
        private readonly ILogger<KafkaErrorHandler> _logger;

        public KafkaErrorHandler(IKafkaProducer producer,
            ILogger<KafkaErrorHandler> logger)
        {
            _producer = producer;
            _logger = logger;
        }

        public async Task HandleErrorForMainEvent(Exception exception, ConsumeResult<string, string> consumeResult,
            string errorTopic)
        {
            _logger.LogError(exception.ToString());
            if (consumeResult == null)
            {
                return;
            }

            consumeResult.Message.SetHeaderValue(KafkaConstants.ExceptionHeader,
                exception.InnerException != null ? exception.InnerException.ToString() : exception.Message);
            await _producer.Produce(errorTopic, consumeResult.Message);
        }

        public async Task HandleErrorForRetryEvent(Exception exception, ConsumeResult<string, string> consumeResult,
            string errorTopic,
            string failedTopic)
        {
            _logger.LogError(exception.ToString());
            if (consumeResult == null)
            {
                return;
            }

            consumeResult.Message.SetHeaderValue(KafkaConstants.ExceptionHeader,
                exception.InnerException != null ? exception.InnerException.ToString() : exception.Message);
            var retry = consumeResult.Message.GetHeaderValue(KafkaConstants.RetryCountHeader);
            _logger.LogInformation($"HandleErrorForRetryEvent => Retry count : {retry} => MaxRetryCount : {KafkaConstants.MaxRetryCount}");

            if (retry != null && retry.ToInt() > KafkaConstants.MaxRetryCount)
            {
                await _producer.Produce(failedTopic, consumeResult.Message);
            }
            else
            {
                await _producer.Produce(errorTopic, consumeResult.Message);
            }
        }
    }
}