using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AuditLogs;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for managing audit logs
    /// </summary>
    public class AuditLogService : NPMServiceBase, IAuditLogService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public AuditLogService(System.Net.Http.HttpClient httpClient) : base(httpClient, "api/audit-logs")
        {
        }

        /// <inheritdoc />
        public async Task<OperationResult<AuditLog>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: {id}");
                using var request = CreateRequest(HttpMethod.Get, $"{id}");
                var response = await SendAsync<AuditLog>(request, cancellationToken);
                return OperationResult<AuditLog>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetByIdAsync: {ex}");
                return OperationResult<AuditLog>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AuditLog>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine("Making GET request to: ");
                using var request = CreateRequest(HttpMethod.Get, "");
                var response = await SendAsync<IEnumerable<AuditLog>>(request, cancellationToken);
                return OperationResult<IEnumerable<AuditLog>>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetAllAsync: {ex}");
                return OperationResult<IEnumerable<AuditLog>>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AuditLog>>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: ?page={page}&pageSize={pageSize}");
                using var request = CreateRequest(HttpMethod.Get, $"?page={page}&pageSize={pageSize}");
                var response = await SendAsync<IEnumerable<AuditLog>>(request, cancellationToken);
                return OperationResult<IEnumerable<AuditLog>>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetPageAsync: {ex}");
                return OperationResult<IEnumerable<AuditLog>>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AuditLog>>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: ?user_id={userId}");
                using var request = CreateRequest(HttpMethod.Get, $"?user_id={userId}");
                var response = await SendAsync<IEnumerable<AuditLog>>(request, cancellationToken);
                return OperationResult<IEnumerable<AuditLog>>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetByUserIdAsync: {ex}");
                return OperationResult<IEnumerable<AuditLog>>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AuditLog>>> GetByResourceAsync(string resourceType, int resourceId, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: ?resource_type={resourceType}&resource_id={resourceId}");
                using var request = CreateRequest(HttpMethod.Get, $"?resource_type={resourceType}&resource_id={resourceId}");
                var response = await SendAsync<IEnumerable<AuditLog>>(request, cancellationToken);
                return OperationResult<IEnumerable<AuditLog>>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetByResourceAsync: {ex}");
                return OperationResult<IEnumerable<AuditLog>>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AuditLog>>> GetByActionAsync(string action, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: ?action={action}");
                using var request = CreateRequest(HttpMethod.Get, $"?action={action}");
                var response = await SendAsync<IEnumerable<AuditLog>>(request, cancellationToken);
                return OperationResult<IEnumerable<AuditLog>>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetByActionAsync: {ex}");
                return OperationResult<IEnumerable<AuditLog>>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AuditLog>>> GetByDateRangeAsync(System.DateTime startDate, System.DateTime endDate, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: ?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}");
                using var request = CreateRequest(HttpMethod.Get, $"?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}");
                var response = await SendAsync<IEnumerable<AuditLog>>(request, cancellationToken);
                return OperationResult<IEnumerable<AuditLog>>.Success(response);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error in GetByDateRangeAsync: {ex}");
                return OperationResult<IEnumerable<AuditLog>>.Failure(ex);
            }
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