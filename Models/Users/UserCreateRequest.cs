using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Users
{
    public class UserCreateRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; } = default!;
        [JsonPropertyName("roles")]
        public string[] Roles { get; set; } = System.Array.Empty<string>();
        [JsonPropertyName("is_disabled")]
        public bool IsDisabled { get; set; }
    }
}
