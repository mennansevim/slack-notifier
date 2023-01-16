
namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Response
{
    public interface IBaseFourKeyMetrics
    {
        public double DeploymentFrequency { get; set; }

        public double AverageLeadTime { get; set; }

        public double MeanTimeToRestore { get; set; }

        public double ChangeFailPercentage { get; set; }
    }
}