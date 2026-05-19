using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Certificates;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Represents the certificates resource.
    /// </summary>
    public interface ICertificatesResource : IResourceCollection<CertificateModel>
    {
        ICertificateBuilder CreateBuilder();
        Task<OperationResult<CertificateModel>> GetAsync(int id);
        Task<OperationResult<CertificateModel>> CreateAsync(CertificateCreateRequest certificate);
        Task<OperationResult<CertificateModel>> UpdateAsync(int id, CertificateUpdateRequest certificate);
        Task<OperationResult<CertificateModel>> RenewAsync(int id);
    }
}
