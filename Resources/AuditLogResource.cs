using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AuditLogs;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for querying audit logs
    /// </summary>
    public class AuditLogResource : IAuditLogResource
    {
        private readonly IAuditLogService _auditLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogResource"/> class.
        /// </summary>
        /// <param name="auditLogService">The audit log service</param>
        public AuditLogResource(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService ?? throw new ArgumentNullException(nameof(auditLogService));
        }

        /// <inheritdoc/>
        public Task<OperationResult<AuditLog>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<IEnumerable<AuditLog>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetAllAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<IEnumerable<AuditLog>>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetPageAsync(page, pageSize, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<IEnumerable<AuditLog>>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetByUserIdAsync(userId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<IEnumerable<AuditLog>>> GetByObjectAsync(string objectType, int objectId, CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetByResourceAsync(objectType, objectId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<IEnumerable<AuditLog>>> GetByActionAsync(string action, CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetByActionAsync(action, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<IEnumerable<AuditLog>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return _auditLogService.GetByDateRangeAsync(startDate, endDate, cancellationToken);
        }
    }
} 