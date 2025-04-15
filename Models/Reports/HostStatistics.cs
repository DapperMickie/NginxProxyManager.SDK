using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Reports
{
    /// <summary>
    /// Represents host statistics from the reports endpoint
    /// </summary>
    public class HostStatistics
    {
        /// <summary>
        /// Gets or sets the number of proxy hosts
        /// </summary>
        [JsonPropertyName("proxy")]
        public int ProxyHosts { get; set; }

        /// <summary>
        /// Gets or sets the number of redirection hosts
        /// </summary>
        [JsonPropertyName("redirection")]
        public int RedirectionHosts { get; set; }

        /// <summary>
        /// Gets or sets the number of streams
        /// </summary>
        [JsonPropertyName("stream")]
        public int Streams { get; set; }

        /// <summary>
        /// Gets or sets the number of dead hosts (404)
        /// </summary>
        [JsonPropertyName("dead")]
        public int DeadHosts { get; set; }
    }
} 