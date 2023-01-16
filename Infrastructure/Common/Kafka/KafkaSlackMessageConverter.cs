using Confluent.Kafka;
using Newtonsoft.Json;

namespace SlackNotifier.Domain.Converters
{
    public static class KafkaSlackMessageConverter
    {
        public static KafkaSlackMessage ToKafkaSlackMessage(this ConsumeResult<string, string> consumeResult)
        {
            var slackMessage = JsonConvert.DeserializeObject<KafkaSlackMessage>(consumeResult.Message.Value);
            if (slackMessage == null)
            {
                throw new JsonSerializationException();
            }

            return slackMessage;
        }
    }
}