using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Users
{
    /// <summary>Represents an Nginx Proxy Manager user.</summary>
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; } = default!;
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; } = default!;
        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("is_disabled")]
        public bool IsDisabled { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; } = default!;
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; } = default!;
        [JsonPropertyName("roles")]
        public string[] Roles { get; set; } = System.Array.Empty<string>();
    }
}
