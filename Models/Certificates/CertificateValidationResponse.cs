namespace NginxProxyManager.SDK.Models.Certificates
{
    public class CertificateValidationResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
} 