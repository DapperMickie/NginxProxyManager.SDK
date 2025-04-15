using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Proxies
{
    /// <summary>
    /// Request model for updating a proxy host
    /// </summary>
    public class ProxyHostUpdateRequest
    {
        /// <summary>
        /// Gets or sets the domain names for the proxy host
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Gets or sets the forward host
        /// </summary>
        [JsonPropertyName("forward_host")]
        [Required]
        public string ForwardHost { get; set; }

        /// <summary>
        /// Gets or sets the forward port
        /// </summary>
        [JsonPropertyName("forward_port")]
        [Required]
        [Range(1, 65535)]
        public int ForwardPort { get; set; }

        /// <summary>
        /// Gets or sets the forward scheme
        /// </summary>
        [JsonPropertyName("forward_scheme")]
        [Required]
        [RegularExpression("^(http|https)$")]
        public string ForwardScheme { get; set; }

        /// <summary>
        /// Gets or sets whether SSL is enabled
        /// </summary>
        [JsonPropertyName("ssl_enabled")]
        public bool SslEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether HSTS is enabled
        /// </summary>
        [JsonPropertyName("hsts_enabled")]
        public bool HstsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether HSTS subdomains are enabled
        /// </summary>
        [JsonPropertyName("hsts_subdomains_enabled")]
        public bool HstsSubdomainsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether HTTP/2 support is enabled
        /// </summary>
        [JsonPropertyName("http2_support_enabled")]
        public bool Http2SupportEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether exploit blocking is enabled
        /// </summary>
        [JsonPropertyName("block_exploits_enabled")]
        public bool BlockExploitsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether WebSockets upgrade is allowed
        /// </summary>
        [JsonPropertyName("allow_websocket_upgrade")]
        public bool AllowWebsocketUpgrade { get; set; }

        /// <summary>
        /// Gets or sets the advanced configuration
        /// </summary>
        [JsonPropertyName("advanced_config")]
        public string AdvancedConfig { get; set; }

        /// <summary>
        /// Gets or sets the certificate ID
        /// </summary>
        [JsonPropertyName("certificate_id")]
        public int? CertificateId { get; set; }

        /// <summary>
        /// Gets or sets the access list ID
        /// </summary>
        [JsonPropertyName("access_list_id")]
        public int? AccessListId { get; set; }
    }
} 