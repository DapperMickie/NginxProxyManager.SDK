using System;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.ServerErrors
{
    public class ServerError
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("host_id")]
        public int HostId { get; set; }

        [JsonPropertyName("host_name")]
        public string HostName { get; set; }

        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("request_url")]
        public string RequestUrl { get; set; }

        [JsonPropertyName("request_method")]
        public string RequestMethod { get; set; }

        [JsonPropertyName("request_headers")]
        public string RequestHeaders { get; set; }

        [JsonPropertyName("request_body")]
        public string RequestBody { get; set; }

        [JsonPropertyName("response_headers")]
        public string ResponseHeaders { get; set; }

        [JsonPropertyName("response_body")]
        public string ResponseBody { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
} 