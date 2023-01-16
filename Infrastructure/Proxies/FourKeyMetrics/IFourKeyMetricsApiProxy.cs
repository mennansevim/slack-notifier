using System.Collections.Generic;
using System.Threading.Tasks;
using SlackNotifier.Domain.Proxies.FourKeyMetrics.Request;
using SlackNotifier.Domain.Proxies.FourKeyMetrics.Response;

namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Interfaces
{
    public interface IFourKeyMetricsApiProxy
    {
        Task<List<FourKeyMetricResponse>> GetMetricsAsync(FourKeyMetricRequest request);
        Task<List<FourKeyRateResponse>> GetRatesAsync(FourKeyRatesRequest request);
    }
}