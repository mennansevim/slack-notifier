using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace SlackNotifier.Infrastructure.ErrorHandling
{
    public interface IKafkaErrorHandler
    {
        Task HandleErrorForMainEvent(Exception exception,
            ConsumeResult<string, string> consumeResult,
            string errorTopic);

        Task HandleErrorForRetryEvent(
            Exception exception,
            ConsumeResult<string, string> consumeResult,
            string errorTopic,
            string failedTopic);
    }
}