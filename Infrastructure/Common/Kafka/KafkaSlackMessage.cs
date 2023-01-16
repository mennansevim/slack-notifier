using XCore.Slack.Webhooks;

namespace SlackNotifier.Domain
{
    public class KafkaSlackMessage : SlackMessage
    {
        public string WebHookUrl { get; set; }
    }
}