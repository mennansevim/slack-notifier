namespace SlackNotifier.Infrastructure.Utils
{
    public static class KafkaConstants
    {
        public const string ExceptionHeader = "Exception";
        public const string RetryCountHeader = "RetryCount";
        public const int MaxRetryCount = 30;
    }
}