using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;
using SlackNotifier.Domain.Proxies.FourKeyMetrics.Interfaces;
using SlackNotifier.Domain.Proxies.FourKeyMetrics.Request;
using SlackNotifier.Domain.Proxies.FourKeyMetrics.Response;
using SlackNotifier.Infrastructure.Extensions;

namespace SlackNotifier.Domain.Proxies.FourKeyMetrics
{
    public class FourKeyMetricsApiProxy : IFourKeyMetricsApiProxy
    {
        private readonly IRestClient _restClient;

        public FourKeyMetricsApiProxy(IConfiguration configuration)
        {
            _restClient = new RestClient(configuration["FourKeyMetricsUrl"])
          {
              Encoding = Encoding.UTF8
          };
        }

        public async Task<List<FourKeyMetricResponse>> GetMetricsAsync(FourKeyMetricRequest request)
        {
            var query = $"/groups?{request.ToQueryString()}";
            Console.WriteLine($"request: {query}");

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            
            IRestRequest restRequest = new RestRequest(query);
            var restResponse = await _restClient.ExecuteTaskAsync(restRequest);

            if (!restResponse.IsSuccessful)
            {
                Console.WriteLine($"restResponse: {restResponse.ErrorMessage}");
            }

            return restResponse.ToGetResponse<List<FourKeyMetricResponse>>(otherStatus: () => throw new HttpRequestException(restResponse.ErrorMessage));
        }
        
        public async Task<List<FourKeyRateResponse>> GetRatesAsync(FourKeyRatesRequest request)
        {
            var query = $"/rates?{request.ToQueryString()}";
          
            IRestRequest restRequest = new RestRequest(query);
            var restResponse = await _restClient.ExecuteTaskAsync(restRequest);
 
            return restResponse.ToGetResponse<List<FourKeyRateResponse>>(otherStatus: () => throw new HttpRequestException(restResponse.ErrorMessage));
        }
    }
}
