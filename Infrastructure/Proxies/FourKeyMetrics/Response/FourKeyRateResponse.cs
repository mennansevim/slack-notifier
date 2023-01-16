
namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Response
{
    public class FourKeyRateResponse
    {
        public string MetricName { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }

        public string GetStatusSlackIcon()
        {
            return Status == "stable" ? ":heavy_minus_sign:" : $":{Status}-icon:";
        }
    }
}
