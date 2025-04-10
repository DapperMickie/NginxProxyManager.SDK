using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.ServerErrors;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class ServerErrorService : IServerErrorService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ServerErrorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ServerError[]> GetServerErrorsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("api/server-errors", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ServerError[]>(content, _jsonOptions);
        }

        public async Task<ServerError> GetServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/server-errors/{serverErrorId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ServerError>(content, _jsonOptions);
        }

        public async Task<ServerError[]> GetServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/server-errors/host/{hostId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ServerError[]>(content, _jsonOptions);
        }

        public async Task DeleteServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/server-errors/{serverErrorId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/server-errors/host/{hostId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }
    }
} 