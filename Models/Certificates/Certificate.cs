using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Certificates
{
    public class CertificateModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        [JsonPropertyName("created_on")]
        [Required]
        public string CreatedOn { get; set; }

        /// <summary>
        /// Date and time of last update
        /// </summary>
        [JsonPropertyName("modified_on")]
        [Required]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// User ID of the owner
        /// </summary>
        [JsonPropertyName("owner_user_id")]
        [Range(1, int.MaxValue)]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Certificate provider (letsencrypt or other)
        /// </summary>
        [JsonPropertyName("provider")]
        [Required]
        [RegularExpression("^(letsencrypt|other)$")]
        public string Provider { get; set; }

        /// <summary>
        /// Nice name for the certificate
        /// </summary>
        [JsonPropertyName("nice_name")]
        [Required]
        public string NiceName { get; set; }

        /// <summary>
        /// Domain names for the certificate
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Expiration date
        /// </summary>
        [JsonPropertyName("expires_on")]
        [Required]
        public string ExpiresOn { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        [Required]
        public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();
    }
} 