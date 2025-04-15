using System;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Streams;
using NginxProxyManager.SDK.Resources.Interfaces;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for interacting with streams
    /// </summary>
    public class StreamResource : IStreamResource
    {
        private readonly IStreamService _streamService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamResource"/> class.
        /// </summary>
        /// <param name="streamService">The stream service</param>
        public StreamResource(IStreamService streamService)
        {
            _streamService = streamService ?? throw new ArgumentNullException(nameof(streamService));
        }

        /// <inheritdoc/>
        public Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream[]>> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            return _streamService.GetStreamsAsync(expand, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _streamService.GetStreamAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> CreateAsync(NginxProxyManager.SDK.Models.Streams.Stream stream, CancellationToken cancellationToken = default)
        {
            return _streamService.CreateStreamAsync(stream, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<NginxProxyManager.SDK.Models.Streams.Stream>> UpdateAsync(int id, NginxProxyManager.SDK.Models.Streams.Stream stream, CancellationToken cancellationToken = default)
        {
            return _streamService.UpdateStreamAsync(id, stream, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<object>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return _streamService.DeleteStreamAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<object>> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            return _streamService.EnableStreamAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OperationResult<object>> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            return _streamService.DisableStreamAsync(id, cancellationToken);
        }
    }
} 