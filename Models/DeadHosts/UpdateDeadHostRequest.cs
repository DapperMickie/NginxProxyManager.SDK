using System.Text.Json.Serialization;

namespace NgninxProxyManager.SDK.Models.DeadHosts
{
    public class UpdateDeadHostRequest
    {
        [JsonPropertyName("domain_name")]
        public string DomainName { get; set; }

        [JsonPropertyName("forward_host")]
        public string ForwardHost { get; set; }

        [JsonPropertyName("forward_scheme")]
        public string ForwardScheme { get; set; }
    }
} 