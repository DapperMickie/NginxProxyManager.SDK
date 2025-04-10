using System;
using NgninxProxyManager.SDK.Models.AccessLists;
using NgninxProxyManager.SDK.Models.Certificates;

namespace NgninxProxyManager.SDK.Models.Redirections
{
    public class RedirectionHost
    {
        public int Id { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public int OwnerUserId { get; set; }
        public string DomainNames { get; set; }
        public bool Enabled { get; set; }
        public bool SslForced { get; set; }
        public bool HstsEnabled { get; set; }
        public bool HstsSubdomains { get; set; }
        public bool Http2Support { get; set; }
        public bool BlockExploits { get; set; }
        public string AdvancedConfig { get; set; }
        public object Meta { get; set; }
        public CertificateModel Certificate { get; set; }
        public AccessList AccessList { get; set; }
        public string ForwardScheme { get; set; }
        public string ForwardHost { get; set; }
        public int ForwardPort { get; set; }
    }
} 