namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Response
{
    public class RawData
    {
        public int deploymentCount { get; set; }
        public int failureCount { get; set; }
        public int commitCount { get; set; }
        public decimal totalLeadTimeSecs { get; set; }
        public decimal totalRestoreTimeSecs { get; set; }
    }
}