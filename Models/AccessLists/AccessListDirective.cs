using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.AccessLists
{
    /// <summary>
    /// Access list directive type
    /// </summary>
    public enum AccessListDirective
    {
        /// <summary>
        /// Allow access
        /// </summary>
        [JsonPropertyName("allow")]
        Allow,

        /// <summary>
        /// Deny access
        /// </summary>
        [JsonPropertyName("deny")]
        Deny
    }
} 