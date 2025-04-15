using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NginxProxyManager.SDK.Models.AccessLists;
using NginxProxyManager.SDK.Models.Certificates;

namespace NginxProxyManager.SDK.Models.Proxies
{
    public class ProxyHost
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// Date and time of last update
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// User ID of the owner
        /// </summary>
        [JsonPropertyName("owner_user_id")]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Domain names for the proxy host
        /// </summary>
        [JsonPropertyName("domain_names")]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Forward host
        /// </summary>
        [JsonPropertyName("forward_host")]
        public string ForwardHost { get; set; }

        /// <summary>
        /// Forward port
        /// </summary>
        [JsonPropertyName("forward_port")]
        public int ForwardPort { get; set; }

        /// <summary>
        /// Forward scheme (http, https)
        /// </summary>
        [JsonPropertyName("forward_scheme")]
        public string ForwardScheme { get; set; }

        /// <summary>
        /// Whether the proxy host is enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Whether SSL is forced
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
        /// Whether to block exploits
        /// </summary>
        [JsonPropertyName("block_exploits")]
        public bool BlockExploits { get; set; }

        /// <summary>
        /// Advanced configuration
        /// </summary>
        [JsonPropertyName("advanced_config")]
        public string AdvancedConfig { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Associated certificate
        /// </summary>
        [JsonPropertyName("certificate")]
        public CertificateModel Certificate { get; set; }

        /// <summary>
        /// Associated access list
        /// </summary>
        [JsonPropertyName("access_list")]
        public AccessList AccessList { get; set; }

        /// <summary>
        /// Owner user information
        /// </summary>
        [JsonPropertyName("owner")]
        public User Owner { get; set; }
    }
} 