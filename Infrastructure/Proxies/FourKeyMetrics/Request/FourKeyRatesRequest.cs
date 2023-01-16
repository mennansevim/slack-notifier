namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Request
{
    public class FourKeyRatesRequest
    {
        public string? GroupIds { get; set; }
        public int Period { get; set; }

        public string? ToQueryString()
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("period", Period.ToString());
            queryString.Add("groupIds", GroupIds);

            return queryString.ToString();
        }
    }
}