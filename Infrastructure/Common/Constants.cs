namespace SlackNotifier.Infrastructure.Utils
{
    internal static class Channels
    {
        internal static readonly string FourKeyMetricsSlackChannel = "FourKeyMetricsSlackChannel";
    }
    
    public  static class TopicConstants
    {
        public const string SlackMessageCreated = "globalplatforms.om.slack.message.created.0";
        public const string SlackMessageCreatedError = "globalplatforms.om.slack.message.created.0.slack-message-consumer.error";
        public const string SlackMessageCreatedFailed = "globalplatforms.om.slack.message.created.0.slack-message-consumer.failed";
    }

    public static class ConsumerConstants
    {
        public const string SendSlackMessageGroupId = "globalplatforms.om.send-slack-message-listener";
    }
}