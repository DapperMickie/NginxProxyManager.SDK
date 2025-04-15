using System;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Auth
{
    /// <summary>
    /// Response model containing the authentication token
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Gets or sets the JWT token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token expiration time
        /// </summary>
        [JsonPropertyName("expires")]
        public DateTime Expires { get; set; }
    }
} 