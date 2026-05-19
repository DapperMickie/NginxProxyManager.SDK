using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Certificates
{
    public class CertificateCreateRequest
    {
        /// <summary>
        /// Certificate provider (letsencrypt or other)
        /// </summary>
        [JsonPropertyName("provider")]
        [Required]
        [RegularExpression("^(letsencrypt|other)$")]
        public string Provider { get; set; } = default!;

        /// <summary>
        /// Nice name for the certificate
        /// </summary>
        [JsonPropertyName("nice_name")]
        [Required]
        public string NiceName { get; set; } = default!;

        /// <summary>
        /// Domain names for the certificate
        /// </summary>
        [JsonPropertyName("domain_names")]
        [Required]
        public string[] DomainNames { get; set; } = default!;

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        [Required]
        public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Certificate key (for custom certificates)
        /// </summary>
        [JsonPropertyName("certificate_key")]
        public string CertificateKey { get; set; } = default!;

        /// <summary>
        /// Certificate (for custom certificates)
        /// </summary>
        [JsonPropertyName("certificate")]
        public string Certificate { get; set; } = default!;

        /// <summary>
        /// Intermediate certificate (for custom certificates)
        /// </summary>
        [JsonPropertyName("intermediate_certificate")]
        public string IntermediateCertificate { get; set; } = default!;
    }
} 