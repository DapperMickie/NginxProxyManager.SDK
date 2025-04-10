using System.Text.Json.Serialization;

namespace NgninxProxyManager.SDK.Models.Streams
{
    public class CreateStreamRequest
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