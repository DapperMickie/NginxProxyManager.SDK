namespace NginxProxyManager.SDK.Models.Certificates
{
    public class CertificateCreateRequest
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Provider { get; set; }
        public bool IsCustom { get; set; }
        public string CertificateKey { get; set; }
        public string Certificate { get; set; }
        public string IntermediateCertificate { get; set; }
    }
} 