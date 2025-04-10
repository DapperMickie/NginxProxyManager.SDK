using System;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Streams
{
    public class StreamModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("scheme")]
        public string Scheme { get; set; }

        [JsonPropertyName("forward_host")]
        public string ForwardHost { get; set; }

        [JsonPropertyName("forward_port")]
        public int ForwardPort { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
} 