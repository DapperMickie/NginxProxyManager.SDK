using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AuditLogs;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Interface for the audit log resource
    /// </summary>
    public interface IAuditLogResource
    {
        /// <summary>
        /// Gets an audit log by ID
        /// </summary>
        /// <param name="id">The audit log ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit log</returns>
        Task<OperationResult<AuditLog>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all audit logs
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit logs</returns>
        Task<OperationResult<IEnumerable<AuditLog>>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a page of audit logs
        /// </summary>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit logs</returns>
        Task<OperationResult<IEnumerable<AuditLog>>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets audit logs for a specific user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit logs</returns>
        Task<OperationResult<IEnumerable<AuditLog>>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets audit logs for a specific resource
        /// </summary>
        /// <param name="objectType">The object type</param>
        /// <param name="objectId">The object ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit logs</returns>
        Task<OperationResult<IEnumerable<AuditLog>>> GetByObjectAsync(string objectType, int objectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets audit logs for a specific action
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit logs</returns>
        Task<OperationResult<IEnumerable<AuditLog>>> GetByActionAsync(string action, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets audit logs within a date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the audit logs</returns>
        Task<OperationResult<IEnumerable<AuditLog>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    }
} 