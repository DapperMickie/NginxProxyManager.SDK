using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.Streams
{
    /// <summary>
    /// Represents a stream in Nginx Proxy Manager
    /// </summary>
    public class Stream
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last modification date and time
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the owner user ID
        /// </summary>
        [JsonPropertyName("owner_user_id")]
        [Required]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Gets or sets the incoming port
        /// </summary>
        [JsonPropertyName("incoming_port")]
        [Required]
        [Range(1, 65535)]
        public int IncomingPort { get; set; }

        /// <summary>
        /// Gets or sets the forwarding host
        /// </summary>
        [JsonPropertyName("forwarding_host")]
        [Required]
        public string ForwardingHost { get; set; }

        /// <summary>
        /// Gets or sets the forwarding port
        /// </summary>
        [JsonPropertyName("forwarding_port")]
        [Required]
        [Range(1, 65535)]
        public int ForwardingPort { get; set; }

        /// <summary>
        /// Gets or sets whether TCP forwarding is enabled
        /// </summary>
        [JsonPropertyName("tcp_forwarding")]
        [Required]
        public bool TcpForwarding { get; set; }

        /// <summary>
        /// Gets or sets whether UDP forwarding is enabled
        /// </summary>
        [JsonPropertyName("udp_forwarding")]
        [Required]
        public bool UdpForwarding { get; set; }

        /// <summary>
        /// Gets or sets whether the stream is enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the certificate ID
        /// </summary>
        [JsonPropertyName("certificate_id")]
        public int? CertificateId { get; set; }

        /// <summary>
        /// Gets or sets the metadata
        /// </summary>
        [JsonPropertyName("meta")]
        public StreamMeta Meta { get; set; }
    }

    /// <summary>
    /// Represents metadata for a stream
    /// </summary>
    public class StreamMeta
    {
        /// <summary>
        /// Gets or sets whether Nginx is online
        /// </summary>
        [JsonPropertyName("nginx_online")]
        public bool NginxOnline { get; set; }

        /// <summary>
        /// Gets or sets any Nginx errors
        /// </summary>
        [JsonPropertyName("nginx_err")]
        public string NginxError { get; set; }
    }
} 