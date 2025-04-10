using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Audit;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class AuditLogService : NPMServiceBase, IAuditLogService
    {
        public AuditLogService(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        public async Task<AuditLog[]> GetAuditLogsAsync(CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, "api/audit-logs");
            return await SendAsync<AuditLog[]>(request, cancellationToken);
        }

        public async Task<AuditLog> GetAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/audit-logs/{auditLogId}");
            return await SendAsync<AuditLog>(request, cancellationToken);
        }

        public async Task<AuditLog[]> GetAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/audit-logs/user/{userId}");
            return await SendAsync<AuditLog[]>(request, cancellationToken);
        }

        public async Task<AuditLog[]> GetAuditLogsByActionAsync(string action, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/audit-logs/action/{action}");
            return await SendAsync<AuditLog[]>(request, cancellationToken);
        }

        public async Task<AuditLog[]> GetAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/audit-logs/date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
            return await SendAsync<AuditLog[]>(request, cancellationToken);
        }

        public async Task DeleteAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"api/audit-logs/{auditLogId}");
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task DeleteAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"api/audit-logs/user/{userId}");
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task DeleteAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"api/audit-logs/date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
            await SendAsync<object>(request, cancellationToken);
        }
    }
} 