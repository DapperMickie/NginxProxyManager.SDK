using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Streams;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Interface for the stream service
    /// </summary>
    public interface IStreamService
    {
        /// <summary>
        /// Gets all streams
        /// </summary>
        /// <param name="expand">Optional expansion parameter</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the streams</returns>
        Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream[]>> GetStreamsAsync(string expand = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a stream by ID
        /// </summary>
        /// <param name="streamId">The stream ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the stream</returns>
        Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> GetStreamAsync(int streamId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new stream
        /// </summary>
        /// <param name="stream">The stream to create</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the created stream</returns>
        Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> CreateStreamAsync(NginxProxyManager.SDK.Models.Streams.Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing stream
        /// </summary>
        /// <param name="streamId">The stream ID</param>
        /// <param name="stream">The stream to update</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the updated stream</returns>
        Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> UpdateStreamAsync(int streamId, NginxProxyManager.SDK.Models.Streams.Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a stream
        /// </summary>
        /// <param name="streamId">The stream ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> DeleteStreamAsync(int streamId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Enables a stream
        /// </summary>
        /// <param name="streamId">The stream ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> EnableStreamAsync(int streamId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Disables a stream
        /// </summary>
        /// <param name="streamId">The stream ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<object>> DisableStreamAsync(int streamId, CancellationToken cancellationToken = default);
    }
} 