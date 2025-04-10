using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Streams
{
    public class UpdateStreamRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("scheme")]
        public string Scheme { get; set; }

        [JsonPropertyName("forward_host")]
        public string ForwardHost { get; set; }

        [JsonPropertyName("forward_port")]
        public int ForwardPort { get; set; }
    }
} 