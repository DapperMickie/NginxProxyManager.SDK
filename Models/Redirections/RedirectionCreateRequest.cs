using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Redirections
{
    public class RedirectionCreateRequest
    {
        /// <summary>
        /// Name of the redirection
        /// </summary>
        [JsonPropertyName("name")]
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        /// <summary>
        /// Description of the redirection
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether the redirection is enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Domain names for the redirection
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Forward scheme (http, https)
        /// </summary>
        [JsonPropertyName("forward_scheme")]
        [Required]
        public string ForwardScheme { get; set; }

        /// <summary>
        /// Forward host
        /// </summary>
        [JsonPropertyName("forward_host")]
        [Required]
        public string ForwardHost { get; set; }

        /// <summary>
        /// Forward port
        /// </summary>
        [JsonPropertyName("forward_port")]
        [Required]
        [Range(1, 65535)]
        public int ForwardPort { get; set; }

        /// <summary>
        /// Whether to preserve the path when forwarding
        /// </summary>
        [JsonPropertyName("preserve_path")]
        public bool PreservePath { get; set; }

        /// <summary>
        /// Whether to preserve the query string when forwarding
        /// </summary>
        [JsonPropertyName("preserve_query_string")]
        public bool PreserveQueryString { get; set; }

        /// <summary>
        /// Whether to force SSL
        /// </summary>
        [JsonPropertyName("ssl_forced")]
        public bool SslForced { get; set; }

        /// <summary>
        /// Whether HSTS is enabled
        /// </summary>
        [JsonPropertyName("hsts_enabled")]
        public bool HstsEnabled { get; set; }

        /// <summary>
        /// Whether HSTS subdomains are enabled
        /// </summary>
        [JsonPropertyName("hsts_subdomains")]
        public bool HstsSubdomains { get; set; }

        /// <summary>
        /// Whether HTTP/2 support is enabled
        /// </summary>
        [JsonPropertyName("http2_support")]
        public bool Http2Support { get; set; }

        /// <summary>
        /// Advanced configuration
        /// </summary>
        [JsonPropertyName("advanced_config")]
        public string AdvancedConfig { get; set; }

        /// <summary>
        /// Certificate ID
        /// </summary>
        [JsonPropertyName("certificate_id")]
        public int? CertificateId { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();
    }
} 