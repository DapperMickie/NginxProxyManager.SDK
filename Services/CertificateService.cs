using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Certificates;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class CertificateService : NPMServiceBase, ICertificateService
    {
        public CertificateService(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        public async Task<CertificateModel[]> GetCertificatesAsync(CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, "api/certificates");
            return await SendAsync<CertificateModel[]>(request, cancellationToken);
        }

        public async Task<CertificateModel> GetCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/certificates/{certificateId}");
            return await SendAsync<CertificateModel>(request, cancellationToken);
        }

        public async Task<CertificateModel> CreateCertificateAsync(CertificateCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "api/certificates", request);
            return await SendAsync<CertificateModel>(httpRequest, cancellationToken);
        }

        public async Task<CertificateModel> UpdateCertificateAsync(int certificateId, CertificateUpdateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, $"api/certificates/{certificateId}", request);
            return await SendAsync<CertificateModel>(httpRequest, cancellationToken);
        }

        public async Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"api/certificates/{certificateId}");
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task<CertificateModel> RenewCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"api/certificates/{certificateId}/renew");
            return await SendAsync<CertificateModel>(request, cancellationToken);
        }
    }
} 