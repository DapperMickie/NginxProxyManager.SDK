using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Settings
{
    public class SettingUpdateRequest
    {
        [JsonPropertyName("value")]
        public object? Value { get; set; }
    }
}
