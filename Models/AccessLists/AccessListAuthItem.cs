using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.AccessLists
{
    public class AccessListAuthItem
    {
        /// <summary>
        /// Unique identifier for the auth item
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Username for basic authentication
        /// </summary>
        [JsonPropertyName("username")]
        [Required]
        [MinLength(1)]
        public string Username { get; set; }

        /// <summary>
        /// Password for basic authentication (hashed)
        /// </summary>
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Creation timestamp
        /// </summary>
        [JsonPropertyName("created_on")]
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Last modification timestamp
        /// </summary>
        [JsonPropertyName("modified_on")]
        [Required]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// ID of the access list this auth item belongs to
        /// </summary>
        [JsonPropertyName("access_list_id")]
        [Required]
        public int AccessListId { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();
    }
} 