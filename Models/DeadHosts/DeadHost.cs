using System;
using System.Text.Json.Serialization;

namespace NgninxProxyManager.SDK.Models.DeadHosts
{
    public class DeadHost
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("domain_name")]
        public string DomainName { get; set; }

        [JsonPropertyName("forward_host")]
        public string ForwardHost { get; set; }

        [JsonPropertyName("forward_scheme")]
        public string ForwardScheme { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
} 