using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NgninxProxyManager.SDK.Models.DeadHosts;
using NgninxProxyManager.SDK.Services.Interfaces;

namespace NgninxProxyManager.SDK.Services
{
    public class DeadHostService : IDeadHostService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public DeadHostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<DeadHost[]> GetDeadHostsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("api/dead-hosts", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<DeadHost[]>(content, _jsonOptions);
        }

        public async Task<DeadHost> GetDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/dead-hosts/{deadHostId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<DeadHost>(content, _jsonOptions);
        }

        public async Task<DeadHost> CreateDeadHostAsync(CreateDeadHostRequest request, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(request, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/dead-hosts", content, cancellationToken);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<DeadHost>(responseContent, _jsonOptions);
        }

        public async Task<DeadHost> UpdateDeadHostAsync(int deadHostId, UpdateDeadHostRequest request, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(request, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/dead-hosts/{deadHostId}", content, cancellationToken);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<DeadHost>(responseContent, _jsonOptions);
        }

        public async Task DeleteDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/dead-hosts/{deadHostId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public async Task<DeadHost[]> GetDeadHostsByDomainAsync(string domainName, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/dead-hosts/domain/{domainName}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<DeadHost[]>(content, _jsonOptions);
        }

        public async Task<DeadHost[]> GetDeadHostsByForwardHostAsync(string forwardHost, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/dead-hosts/forward-host/{forwardHost}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<DeadHost[]>(content, _jsonOptions);
        }
    }
} 