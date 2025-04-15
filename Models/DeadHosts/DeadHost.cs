using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.DeadHosts
{
    public class DeadHost
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        [JsonPropertyName("created_on")]
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Date and time of last update
        /// </summary>
        [JsonPropertyName("modified_on")]
        [Required]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Owner user ID
        /// </summary>
        [JsonPropertyName("owner_user_id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Domain names separated by a comma
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
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
        [Required]
        public bool SslForced { get; set; }

        /// <summary>
        /// Is HSTS Enabled
        /// </summary>
        [JsonPropertyName("hsts_enabled")]
        [Required]
        public bool HstsEnabled { get; set; }

        /// <summary>
        /// Is HSTS applicable to all subdomains
        /// </summary>
        [JsonPropertyName("hsts_subdomains")]
        [Required]
        public bool HstsSubdomains { get; set; }

        /// <summary>
        /// HTTP2 Protocol Support
        /// </summary>
        [JsonPropertyName("http2_support")]
        [Required]
        public bool Http2Support { get; set; }

        /// <summary>
        /// Advanced configuration
        /// </summary>
        [JsonPropertyName("advanced_config")]
        [Required]
        public string AdvancedConfig { get; set; }

        /// <summary>
        /// Is Enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Meta information
        /// </summary>
        [JsonPropertyName("meta")]
        [Required]
        public object Meta { get; set; }

        /// <summary>
        /// Owner information
        /// </summary>
        [JsonPropertyName("owner")]
        public User Owner { get; set; }

        /// <summary>
        /// Certificate information
        /// </summary>
        [JsonPropertyName("certificate")]
        public object Certificate { get; set; }
    }
} 