using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Streams
{
    public class StreamModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the stream
        /// </summary>
        [JsonPropertyName("name")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Stream scheme (tcp, udp)
        /// </summary>
        [JsonPropertyName("scheme")]
        [Required]
        [RegularExpression("^(tcp|udp)$")]
        public string Scheme { get; set; }

        /// <summary>
        /// Forward host for the stream
        /// </summary>
        [JsonPropertyName("forward_host")]
        [Required]
        [RegularExpression("^(?:[^.*]+\\.?)+[^.]$")]
        public string ForwardHost { get; set; }

        /// <summary>
        /// Forward port for the stream
        /// </summary>
        [JsonPropertyName("forward_port")]
        [Required]
        [Range(1, 65535)]
        public int ForwardPort { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        [JsonPropertyName("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time of last update
        /// </summary>
        [JsonPropertyName("updated_at")]
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
} 