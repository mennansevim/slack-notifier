using System;

namespace SlackNotifier.Domain.Proxies.FourKeyMetrics.Response
{
    public class Period
    {
        public int days { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}