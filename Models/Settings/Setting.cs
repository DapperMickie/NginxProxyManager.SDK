using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Settings
{
    public class Setting
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;
        [JsonPropertyName("value")]
        public object? Value { get; set; }
        [JsonPropertyName("meta")]
        public Dictionary<string, object> Meta { get; set; } = new();
    }
}
