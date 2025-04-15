using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NginxProxyManager.SDK.Models.AccessLists
{
    public class AccessList : AccessListBase
    {
        /// <summary>
        /// Owner user information
        /// </summary>
        [JsonPropertyName("owner")]
        public User Owner { get; set; }
    }
} 