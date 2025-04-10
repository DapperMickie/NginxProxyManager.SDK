using System.Threading;
using System.Threading.Tasks;
using NgninxProxyManager.SDK.Models.Streams;

namespace NgninxProxyManager.SDK.Services.Interfaces
{
    public interface IStreamService
    {
        Task<StreamModel[]> GetStreamsAsync(CancellationToken cancellationToken = default);
        Task<StreamModel[]> GetStreamsAsync(string expand, CancellationToken cancellationToken);
        Task<StreamModel> GetStreamAsync(int streamId, CancellationToken cancellationToken = default);
        Task<StreamModel> CreateStreamAsync(CreateStreamRequest request, CancellationToken cancellationToken = default);
        Task<StreamModel> UpdateStreamAsync(int streamId, UpdateStreamRequest request, CancellationToken cancellationToken = default);
        Task DeleteStreamAsync(int streamId, CancellationToken cancellationToken = default);
        Task<bool> EnableStreamAsync(int streamId, CancellationToken cancellationToken = default);
        Task<bool> DisableStreamAsync(int streamId, CancellationToken cancellationToken = default);
    }
} 