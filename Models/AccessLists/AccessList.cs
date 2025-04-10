using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NginxProxyManager.SDK.Models.AccessLists
{
    public class AccessList : AccessListBase { }

    public class AccessListFull : AccessListBase { }

    public class AccessListCreateRequest
    {
        [JsonProperty("name", Required = Required.Always)]
        [Required]
        public string Name { get; set; }

        [JsonProperty("directive", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AccessListDirective Directive { get; set; }

        [JsonProperty("address", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonProperty("satisfy_any", Required = Required.Always)]
        public bool SatisfyAny { get; set; }

        [JsonProperty("pass_auth", Required = Required.Always)]
        public bool PassAuth { get; set; }

        [JsonProperty("meta", Required = Required.Always)]
        [Required]
        public object Meta { get; set; } = new object();
    }

    public class AccessListUpdateRequest : AccessListCreateRequest { }
} 