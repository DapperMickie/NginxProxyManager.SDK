using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Redirections;
using System.Threading;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Service for managing redirections
    /// </summary>
    public interface IRedirectionService
    {
        /// <summary>
        /// Gets a redirection by ID
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result containing the redirection</returns>
        Task<OperationResult<Redirection>> GetByIdAsync(int id);

        /// <summary>
        /// Gets all redirections
        /// </summary>
        /// <returns>The operation result containing the redirections</returns>
        Task<OperationResult<IEnumerable<Redirection>>> GetAllAsync();

        /// <summary>
        /// Gets a page of redirections
        /// </summary>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>The operation result containing the redirections</returns>
        Task<OperationResult<IEnumerable<Redirection>>> GetPageAsync(int page, int pageSize);

        /// <summary>
        /// Creates a new redirection
        /// </summary>
        /// <param name="redirection">The redirection to create</param>
        /// <returns>The operation result containing the created redirection</returns>
        Task<OperationResult<Redirection>> CreateAsync(RedirectionCreateRequest redirection);

        /// <summary>
        /// Updates an existing redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <param name="redirection">The redirection to update</param>
        /// <returns>The operation result containing the updated redirection</returns>
        Task<OperationResult<Redirection>> UpdateAsync(int id, RedirectionUpdateRequest redirection);

        /// <summary>
        /// Deletes a redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DeleteAsync(int id);

        /// <summary>
        /// Enables a redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> EnableRedirectionAsync(int id);

        /// <summary>
        /// Disables a redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DisableRedirectionAsync(int id);

        /// <summary>
        /// Gets all redirection hosts
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the redirection hosts</returns>
        Task<OperationResult<RedirectionHost[]>> GetRedirectionHostsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all redirection hosts with optional expansion
        /// </summary>
        /// <param name="expand">The expansion parameter</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the redirection hosts</returns>
        Task<OperationResult<RedirectionHost[]>> GetRedirectionHostsAsync(string expand, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a redirection host by ID
        /// </summary>
        /// <param name="hostId">The redirection host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the redirection host</returns>
        Task<OperationResult<RedirectionHost>> GetRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new redirection host
        /// </summary>
        /// <param name="request">The redirection host create request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the created redirection host</returns>
        Task<OperationResult<RedirectionHost>> CreateRedirectionHostAsync(RedirectionHostCreateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing redirection host
        /// </summary>
        /// <param name="hostId">The redirection host ID</param>
        /// <param name="request">The redirection host update request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the updated redirection host</returns>
        Task<OperationResult<RedirectionHost>> UpdateRedirectionHostAsync(int hostId, RedirectionHostCreateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a redirection host
        /// </summary>
        /// <param name="hostId">The redirection host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DeleteRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default);
    }
}