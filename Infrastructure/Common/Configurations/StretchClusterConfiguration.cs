namespace SlackNotifier.Infrastructure.Configurations
{
    public class StretchClusterConfiguration
    {
        public const string StretchCluster = "StretchClusterConfiguration";
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
        public string SslCaLocation { get; set; }
        public string SslKeystorePassword { get; set; }
        public string Servers { get; set; }
    }
}
