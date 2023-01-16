using SlackNotifier.Domain.Extensions;

namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Response
{
    public class FourKeyMetricsBaseResponse : IBaseFourKeyMetrics
    {
        public double DeploymentFrequency { get; set; }
        public double AverageLeadTime { get; set; }
        public double MeanTimeToRestore { get; set; }
        public double ChangeFailPercentage { get; set; }

        public FourKeyMetricsResult ToDisplayResult()
        {
            return new FourKeyMetricsResult
            {
                DeploymentFrequency =  DeploymentFrequency.RoundByDigit(),
                AverageLeadTime = (AverageLeadTime / 60 / 60).RoundByDigit(),
                MeanTimeToRestore = MeanTimeToRestore.RoundByDigit(),
                ChangeFailPercentage = ChangeFailPercentage.RoundByDigit()
            };
        }
    }
}