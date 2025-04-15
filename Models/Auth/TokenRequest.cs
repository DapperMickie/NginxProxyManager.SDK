using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Auth
{
    /// <summary>
    /// Request model for obtaining an authentication token
    /// </summary>
    public class TokenRequest
    {
        /// <summary>
        /// Gets or sets the identity (email/username)
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Gets or sets the secret (password)
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
} 