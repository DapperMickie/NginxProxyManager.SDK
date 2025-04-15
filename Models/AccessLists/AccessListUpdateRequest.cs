using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.AccessLists;

public class AccessListUpdateRequest
{
    /// <summary>
    /// Name of the access list
    /// </summary>
    [JsonPropertyName("name")]
    [Required]
    [MinLength(1)]
    public string Name { get; set; }

    /// <summary>
    /// Description of the access list
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// Whether the access list is enabled
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Whether to satisfy all conditions (AND) or any condition (OR)
    /// </summary>
    [JsonPropertyName("satisfy")]
    [Required]
    public string Satisfy { get; set; }

    /// <summary>
    /// IP addresses that are allowed/denied
    /// </summary>
    [JsonPropertyName("ip_addresses")]
    public string IpAddresses { get; set; }

    /// <summary>
    /// Basic authentication credentials
    /// </summary>
    [JsonPropertyName("basic_auth")]
    public string BasicAuth { get; set; }

    /// <summary>
    /// Whether to allow or deny access
    /// </summary>
    [JsonPropertyName("action")]
    [Required]
    public string Action { get; set; }

    /// <summary>
    /// Additional metadata
    /// </summary>
    [JsonPropertyName("meta")]
    public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();
}