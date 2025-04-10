using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Certificates;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public CertificateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<CertificateModel[]> GetCertificatesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("api/certificates", cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CertificateModel[]>(_jsonOptions, cancellationToken);
        }

        public async Task<CertificateModel> GetCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/certificates/{certificateId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CertificateModel>(_jsonOptions, cancellationToken);
        }

        public async Task<CertificateModel> CreateCertificateAsync(CertificateCreateRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("api/certificates", request, _jsonOptions, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CertificateModel>(_jsonOptions, cancellationToken);
        }

        public async Task<CertificateModel> UpdateCertificateAsync(int certificateId, CertificateUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/certificates/{certificateId}", request, _jsonOptions, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CertificateModel>(_jsonOptions, cancellationToken);
        }

        public async Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/certificates/{certificateId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CertificateModel> RenewCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsync($"api/certificates/{certificateId}/renew", null, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CertificateModel>(_jsonOptions, cancellationToken);
        }
    }
} 