using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Users
{
    public class UserPasswordUpdateRequest
    {
        [JsonPropertyName("current")]
        public string? Current { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; } = default!;
    }
}
