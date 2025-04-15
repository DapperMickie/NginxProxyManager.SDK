using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Redirections
{
    public class RedirectionHostCreateRequest
    {
        /// <summary>
        /// Domain names for the redirection host
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Forward HTTP status code (300-308)
        /// </summary>
        [JsonPropertyName("forward_http_code")]
        [Required]
        [Range(300, 308)]
        public int ForwardHttpCode { get; set; }

        /// <summary>
        /// Forward scheme (auto, http, https)
        /// </summary>
        [JsonPropertyName("forward_scheme")]
        [Required]
        [RegularExpression("^(auto|http|https)$")]
        public string ForwardScheme { get; set; }

        /// <summary>
        /// Forward domain name
        /// </summary>
        [JsonPropertyName("forward_domain_name")]
        [Required]
        [RegularExpression("^(?:[^.*]+\\.?)+[^.]$")]
        public string ForwardDomainName { get; set; }

        /// <summary>
        /// Whether to preserve the path when redirecting
        /// </summary>
        [JsonPropertyName("preserve_path")]
        [Required]
        public bool PreservePath { get; set; }

        /// <summary>
        /// Certificate ID
        /// </summary>
        [JsonPropertyName("certificate_id")]
        public int? CertificateId { get; set; }

        /// <summary>
        /// Whether SSL is forced
        /// </summary>
        [JsonPropertyName("ssl_forced")]
        [Required]
        public bool SslForced { get; set; }

        /// <summary>
        /// Whether HSTS is enabled
        /// </summary>
        [JsonPropertyName("hsts_enabled")]
        [Required]
        public bool HstsEnabled { get; set; }

        /// <summary>
        /// Whether HSTS subdomains are enabled
        /// </summary>
        [JsonPropertyName("hsts_subdomains")]
        [Required]
        public bool HstsSubdomains { get; set; }

        /// <summary>
        /// Whether HTTP/2 is supported
        /// </summary>
        [JsonPropertyName("http2_support")]
        [Required]
        public bool Http2Support { get; set; }

        /// <summary>
        /// Whether to block common exploits
        /// </summary>
        [JsonPropertyName("block_exploits")]
        [Required]
        public bool BlockExploits { get; set; }

        /// <summary>
        /// Advanced configuration
        /// </summary>
        [JsonPropertyName("advanced_config")]
        [Required]
        public string AdvancedConfig { get; set; }

        /// <summary>
        /// Whether the redirection host is enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        [Required]
        public Dictionary<string, object> Meta { get; set; }
    }
} 