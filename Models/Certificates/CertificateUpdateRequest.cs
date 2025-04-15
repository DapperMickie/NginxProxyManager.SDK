using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Certificates
{
    public class CertificateUpdateRequest
    {
        /// <summary>
        /// Nice name for the certificate
        /// </summary>
        [JsonPropertyName("nice_name")]
        public string NiceName { get; set; }

        /// <summary>
        /// Domain names for the certificate
        /// </summary>
        [JsonPropertyName("domain_names")]
        public string[] DomainNames { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        public Dictionary<string, object> Meta { get; set; }

        /// <summary>
        /// Certificate key (for custom certificates)
        /// </summary>
        [JsonPropertyName("certificate_key")]
        public string CertificateKey { get; set; }

        /// <summary>
        /// Certificate (for custom certificates)
        /// </summary>
        [JsonPropertyName("certificate")]
        public string Certificate { get; set; }

        /// <summary>
        /// Intermediate certificate (for custom certificates)
        /// </summary>
        [JsonPropertyName("intermediate_certificate")]
        public string IntermediateCertificate { get; set; }
    }
} 