using System;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.ServerErrors;
using NginxProxyManager.SDK.Resources.Interfaces;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for interacting with server errors
    /// </summary>
    public class ServerErrorResource : IServerErrorResource
    {
        private readonly IServerErrorService _serverErrorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerErrorResource"/> class.
        /// </summary>
        /// <param name="serverErrorService">The server error service</param>
        public ServerErrorResource(IServerErrorService serverErrorService)
        {
            _serverErrorService = serverErrorService ?? throw new ArgumentNullException(nameof(serverErrorService));
        }

        /// <inheritdoc/>
        public Task<OperationResult<ServerError[]>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _serverErrorService.GetServerErrorsAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<ServerError>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _serverErrorService.GetServerErrorAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<ServerError[]>> GetByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
        {
            return _serverErrorService.GetServerErrorsByHostIdAsync(hostId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<object>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return _serverErrorService.DeleteServerErrorAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<object>> DeleteByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
        {
            return _serverErrorService.DeleteServerErrorsByHostIdAsync(hostId, cancellationToken);
        }
    }
} 