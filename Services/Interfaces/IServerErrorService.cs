using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.ServerErrors;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Interface for the server error service
    /// </summary>
    public interface IServerErrorService
    {
        /// <summary>
        /// Gets all server errors
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the server errors</returns>
        Task<OperationResult<ServerError[]>> GetServerErrorsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a server error by ID
        /// </summary>
        /// <param name="serverErrorId">The server error ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the server error</returns>
        Task<OperationResult<ServerError>> GetServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets server errors by host ID
        /// </summary>
        /// <param name="hostId">The host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the server errors</returns>
        Task<OperationResult<ServerError[]>> GetServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a server error
        /// </summary>
        /// <param name="serverErrorId">The server error ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> DeleteServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes server errors by host ID
        /// </summary>
        /// <param name="hostId">The host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> DeleteServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default);
    }
} 