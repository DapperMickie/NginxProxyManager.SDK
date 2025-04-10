using NgninxProxyManager.SDK.Models.Certificates;

namespace NgninxProxyManager.SDK.Models.Proxies
{
    public class ProxyHostCreateRequest
    {
        public string DomainNames { get; set; }
        public bool Enabled { get; set; }
        public bool SslForced { get; set; }
        public bool HstsEnabled { get; set; }
        public bool HstsSubdomains { get; set; }
        public bool Http2Support { get; set; }
        public bool BlockExploits { get; set; }
        public string AdvancedConfig { get; set; }
        public int? CertificateId { get; set; }
        public int? AccessListId { get; set; }
    }
} 