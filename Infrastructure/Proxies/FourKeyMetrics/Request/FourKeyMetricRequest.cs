using System;

namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Request
{
    public class FourKeyMetricRequest
    {
        public string? GroupIds { get; set; }
        public int PeriodDays { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

        public string? ToQueryString()
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("since",
                Since.ToUniversalTime().Date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
            queryString.Add("until",
                Until.ToUniversalTime().Date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
            queryString.Add("period", PeriodDays.ToString());
            queryString.Add("groupIds", GroupIds);

            return queryString.ToString();
        }
    }
}