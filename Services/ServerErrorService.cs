using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.ServerErrors;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for interacting with the server errors API
    /// </summary>
    public class ServerErrorService : NPMServiceBase, IServerErrorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerErrorService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public ServerErrorService(HttpClient httpClient) : base(httpClient, "api/server-errors")
        {
        }

        /// <inheritdoc/>
        public async Task<OperationResult<ServerError[]>> GetServerErrorsAsync(CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, "");
            var result = await SendAsync<ServerError[]>(request, cancellationToken);
            return new OperationResult<ServerError[]>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<ServerError>> GetServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, serverErrorId.ToString());
            var result = await SendAsync<ServerError>(request, cancellationToken);
            return new OperationResult<ServerError>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<ServerError[]>> GetServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"host/{hostId}");
            var result = await SendAsync<ServerError[]>(request, cancellationToken);
            return new OperationResult<ServerError[]>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<object>> DeleteServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, serverErrorId.ToString());
            await SendAsync<object>(request, cancellationToken);
            return new OperationResult<object>(null);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<object>> DeleteServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"host/{hostId}");
            await SendAsync<object>(request, cancellationToken);
            return new OperationResult<object>(null);
        }
    }
} 