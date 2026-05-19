using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Certificates;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Builder for certificate create and update requests.
    /// </summary>
    public interface ICertificateBuilder
    {
        ICertificateBuilder WithId(int id);
        ICertificateBuilder WithProvider(string provider);
        ICertificateBuilder WithNiceName(string niceName);
        ICertificateBuilder WithDomainNames(params string[] domainNames);
        ICertificateBuilder WithMeta(Dictionary<string, object> meta);
        ICertificateBuilder WithCertificate(string certificate);
        ICertificateBuilder WithKey(string key);
        ICertificateBuilder WithIntermediateCertificate(string intermediateCertificate);
        CertificateCreateRequest Build();
        Task<OperationResult<CertificateModel>> BuildAndCreateAsync();
        Task<OperationResult<CertificateModel>> BuildAndUpdateAsync();
    }
}
