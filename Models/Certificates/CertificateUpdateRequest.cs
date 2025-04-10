using System.Text.Json.Serialization;

namespace NgninxProxyManager.SDK.Models.Certificates
{
    public class CertificateUpdateRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("certificate")]
        public string Certificate { get; set; }

        [JsonPropertyName("certificate_key")]
        public string CertificateKey { get; set; }

        [JsonPropertyName("intermediate_certificate")]
        public string IntermediateCertificate { get; set; }
    }
} 