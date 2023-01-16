
using System;

namespace SlackNotifier.Domain.Constants
{
    public class MetricPayload
    {
        public string WebHookUrl { get; set; }
        public string CronExpression { get; set; }
        public string TeamDisplayName { get; set; }
        public string PandoraGroupName { get; set; }
        public string GroupIds { get; set; }
        public DateTime Since => DateTime.UtcNow.AddDays(-PeriodDays);
        public DateTime Until => DateTime.UtcNow;
        public int PeriodDays { get; set; }
    }
}