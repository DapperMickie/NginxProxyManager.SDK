using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Certificates;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class CertificateService : NPMServiceBase, ICertificateService
    {
        public CertificateService(HttpClient httpClient)
            : base(httpClient, "api/certificates")
        {
        }

        public async Task<CertificateModel[]> GetCertificatesAsync(CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, "");
            return await SendAsync<CertificateModel[]>(request, cancellationToken);
        }

        public async Task<CertificateModel> GetCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, certificateId.ToString());
            return await SendAsync<CertificateModel>(request, cancellationToken);
        }

        public async Task<CertificateModel> CreateCertificateAsync(CertificateCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "", request);
            return await SendAsync<CertificateModel>(httpRequest, cancellationToken);
        }

        public async Task<CertificateModel> UpdateCertificateAsync(int certificateId, CertificateUpdateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, certificateId.ToString(), request);
            return await SendAsync<CertificateModel>(httpRequest, cancellationToken);
        }

        public async Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, certificateId.ToString());
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task<CertificateModel> RenewCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"{certificateId}/renew");
            return await SendAsync<CertificateModel>(request, cancellationToken);
        }
    }
} 