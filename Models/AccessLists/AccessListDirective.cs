using System.Runtime.Serialization;

namespace NgninxProxyManager.SDK.Models.AccessLists
{
    public enum AccessListDirective
    {
        [EnumMember(Value = "allow")]
        Allow = 0,

        [EnumMember(Value = "deny")]
        Deny = 1
    }
} 