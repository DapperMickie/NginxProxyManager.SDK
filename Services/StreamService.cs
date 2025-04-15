using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Streams;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for interacting with the streams API
    /// </summary>
    public class StreamService : NPMServiceBase, IStreamService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public StreamService(HttpClient httpClient) : base(httpClient, "api/nginx/streams")
        {
        }

        /// <inheritdoc/>
        public async Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream[]>> GetStreamsAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            var path = expand != null ? $"?expand={expand}" : "";
            using var request = CreateRequest(HttpMethod.Get, path);
            var result = await SendAsync<NginxProxyManager.SDK.Models.Streams.Stream[]>(request, cancellationToken);
            return new OperationResult<NginxProxyManager.SDK.Models.Streams.Stream[]>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> GetStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, streamId.ToString());
            var result = await SendAsync<NginxProxyManager.SDK.Models.Streams.Stream>(request, cancellationToken);
            return new OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> CreateStreamAsync(NginxProxyManager.SDK.Models.Streams.Stream stream, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, "", stream);
            var result = await SendAsync<NginxProxyManager.SDK.Models.Streams.Stream>(request, cancellationToken);
            return new OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> UpdateStreamAsync(int streamId, NginxProxyManager.SDK.Models.Streams.Stream stream, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Put, streamId.ToString(), stream);
            var result = await SendAsync<NginxProxyManager.SDK.Models.Streams.Stream>(request, cancellationToken);
            return new OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>(result);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<object>> DeleteStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, streamId.ToString());
            await SendAsync<object>(request, cancellationToken);
            return new OperationResult<object>(null);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<object>> EnableStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"{streamId}/enable");
            await SendAsync<object>(request, cancellationToken);
            return new OperationResult<object>(null);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<object>> DisableStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"{streamId}/disable");
            await SendAsync<object>(request, cancellationToken);
            return new OperationResult<object>(null);
        }
    }
} 