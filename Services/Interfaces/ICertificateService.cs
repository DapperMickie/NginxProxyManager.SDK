using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Certificates;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    public interface ICertificateService
    {
        Task<CertificateModel[]> GetCertificatesAsync(CancellationToken cancellationToken = default);
        Task<CertificateModel> GetCertificateAsync(int certificateId, CancellationToken cancellationToken = default);
        Task<CertificateModel> CreateCertificateAsync(CertificateCreateRequest request, CancellationToken cancellationToken = default);
        Task<CertificateModel> UpdateCertificateAsync(int certificateId, CertificateUpdateRequest request, CancellationToken cancellationToken = default);
        Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default);
        Task<CertificateModel> RenewCertificateAsync(int certificateId, CancellationToken cancellationToken = default);
    }
} 