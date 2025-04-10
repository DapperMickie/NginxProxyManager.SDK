using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Audit;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public AuditLogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<AuditLog[]> GetAuditLogsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("api/audit-logs", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<AuditLog[]>(content, _jsonOptions);
        }

        public async Task<AuditLog> GetAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/audit-logs/{auditLogId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<AuditLog>(content, _jsonOptions);
        }

        public async Task<AuditLog[]> GetAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/audit-logs/user/{userId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<AuditLog[]>(content, _jsonOptions);
        }

        public async Task<AuditLog[]> GetAuditLogsByActionAsync(string action, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/audit-logs/action/{action}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<AuditLog[]>(content, _jsonOptions);
        }

        public async Task<AuditLog[]> GetAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/audit-logs/date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<AuditLog[]>(content, _jsonOptions);
        }

        public async Task DeleteAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/audit-logs/{auditLogId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/audit-logs/user/{userId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/audit-logs/date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }
    }
} 