using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.AccessLists
{
    public class AccessListFull : AccessListBase
    {
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
        /// ID of the user who owns this access list
        /// </summary>
        [JsonPropertyName("owner_user_id")]
        [Required]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Additional metadata
        /// </summary>
        [JsonPropertyName("meta")]
        public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Owner user information
        /// </summary>
        [JsonPropertyName("owner")]
        public User Owner { get; set; }

        /// <summary>
        /// Authentication items associated with this access list
        /// </summary>
        [JsonPropertyName("auth_items")]
        public List<AccessListAuthItem> AuthItems { get; set; } = new List<AccessListAuthItem>();
    }
} 