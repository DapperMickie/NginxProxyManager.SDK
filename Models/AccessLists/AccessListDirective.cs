using System.Runtime.Serialization;

namespace NginxProxyManager.SDK.Models.AccessLists
{
    public enum AccessListDirective
    {
        [EnumMember(Value = "allow")]
        Allow = 0,

        [EnumMember(Value = "deny")]
        Deny = 1
    }
} 