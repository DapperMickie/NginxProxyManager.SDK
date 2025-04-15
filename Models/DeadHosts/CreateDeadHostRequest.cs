using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.DeadHosts
{
    public class CreateDeadHostRequest
    {
        /// <summary>
        /// Domain names separated by a comma
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Certificate ID
        /// </summary>
        [JsonPropertyName("certificate_id")]
        [Required]
        public int CertificateId { get; set; }

        /// <summary>
        /// Is SSL Forced
        /// </summary>
        [JsonPropertyName("ssl_forced")]
        public bool SslForced { get; set; }

        /// <summary>
        /// Is HSTS Enabled
        /// </summary>
        [JsonPropertyName("hsts_enabled")]
        public bool HstsEnabled { get; set; }

        /// <summary>
        /// Is HSTS applicable to all subdomains
        /// </summary>
        [JsonPropertyName("hsts_subdomains")]
        public bool HstsSubdomains { get; set; }

        /// <summary>
        /// HTTP2 Protocol Support
        /// </summary>
        [JsonPropertyName("http2_support")]
        public bool Http2Support { get; set; }

        /// <summary>
        /// Advanced configuration
        /// </summary>
        [JsonPropertyName("advanced_config")]
        public string AdvancedConfig { get; set; }

        /// <summary>
        /// Is Enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Meta information
        /// </summary>
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
    }
} 