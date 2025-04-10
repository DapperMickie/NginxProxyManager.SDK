using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Audit;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLog[]> GetAuditLogsAsync(CancellationToken cancellationToken = default);
        Task<AuditLog> GetAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default);
        Task<AuditLog[]> GetAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<AuditLog[]> GetAuditLogsByActionAsync(string action, CancellationToken cancellationToken = default);
        Task<AuditLog[]> GetAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
        Task DeleteAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default);
        Task DeleteAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task DeleteAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    }
} 