
namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Response
{
    public class FourKeyMetricsResult
    {
        public string DeploymentFrequency { get; set; }
        public string AverageLeadTime { get; set; }
        public string MeanTimeToRestore { get; set; }
        public string ChangeFailPercentage { get; set; }
    }
}