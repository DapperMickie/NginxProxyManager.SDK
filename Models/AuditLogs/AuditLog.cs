using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.AuditLogs
{
    /// <summary>
    /// Represents an audit log entry
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// Unique identifier for the audit log entry
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        [JsonPropertyName("created_on")]
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Date and time of last update
        /// </summary>
        [JsonPropertyName("modified_on")]
        [Required]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// User ID who performed the action
        /// </summary>
        [JsonPropertyName("user_id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        /// <summary>
        /// Type of object that was affected (e.g., user, proxy_host, dead_host, access_list)
        /// </summary>
        [JsonPropertyName("object_type")]
        [Required]
        public string ObjectType { get; set; }

        /// <summary>
        /// ID of the object that was affected
        /// </summary>
        [JsonPropertyName("object_id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int ObjectId { get; set; }

        /// <summary>
        /// Action performed (e.g., created, updated, deleted)
        /// </summary>
        [JsonPropertyName("action")]
        [Required]
        public string Action { get; set; }

        /// <summary>
        /// Additional metadata about the audit log entry
        /// </summary>
        [JsonPropertyName("meta")]
        [Required]
        public object Meta { get; set; }

        /// <summary>
        /// User information
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
} 