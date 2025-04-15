using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.ServerErrors;

namespace NginxProxyManager.SDK.Resources.Interfaces
{
    /// <summary>
    /// Interface for the server error resource
    /// </summary>
    public interface IServerErrorResource
    {
        /// <summary>
        /// Gets all server errors
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the server errors</returns>
        Task<OperationResult<ServerError[]>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a server error by ID
        /// </summary>
        /// <param name="id">The server error ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the server error</returns>
        Task<OperationResult<ServerError>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets server errors by host ID
        /// </summary>
        /// <param name="hostId">The host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the server errors</returns>
        Task<OperationResult<ServerError[]>> GetByHostIdAsync(int hostId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a server error
        /// </summary>
        /// <param name="id">The server error ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> DeleteAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes server errors by host ID
        /// </summary>
        /// <param name="hostId">The host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> DeleteByHostIdAsync(int hostId, CancellationToken cancellationToken = default);
    }
} 