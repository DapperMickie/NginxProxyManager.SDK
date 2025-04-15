using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.ServerErrors
{
    public class ServerError
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// ID of the host where the error occurred
        /// </summary>
        [JsonPropertyName("host_id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int HostId { get; set; }

        /// <summary>
        /// Name of the host where the error occurred
        /// </summary>
        [JsonPropertyName("host_name")]
        [Required]
        [StringLength(255)]
        public string HostName { get; set; }

        /// <summary>
        /// HTTP error code
        /// </summary>
        [JsonPropertyName("error_code")]
        [Required]
        [Range(400, 599)]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonPropertyName("error_message")]
        [Required]
        [StringLength(1000)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// URL of the request that caused the error
        /// </summary>
        [JsonPropertyName("request_url")]
        [Required]
        [StringLength(2048)]
        public string RequestUrl { get; set; }

        /// <summary>
        /// HTTP method of the request
        /// </summary>
        [JsonPropertyName("request_method")]
        [Required]
        [RegularExpression("^(GET|POST|PUT|DELETE|PATCH|HEAD|OPTIONS|TRACE|CONNECT)$")]
        public string RequestMethod { get; set; }

        /// <summary>
        /// Headers of the request
        /// </summary>
        [JsonPropertyName("request_headers")]
        [StringLength(4000)]
        public string RequestHeaders { get; set; }

        /// <summary>
        /// Body of the request
        /// </summary>
        [JsonPropertyName("request_body")]
        [StringLength(10000)]
        public string RequestBody { get; set; }

        /// <summary>
        /// Headers of the response
        /// </summary>
        [JsonPropertyName("response_headers")]
        [StringLength(4000)]
        public string ResponseHeaders { get; set; }

        /// <summary>
        /// Body of the response
        /// </summary>
        [JsonPropertyName("response_body")]
        [StringLength(10000)]
        public string ResponseBody { get; set; }

        /// <summary>
        /// Date and time when the error occurred
        /// </summary>
        [JsonPropertyName("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }
    }
} 