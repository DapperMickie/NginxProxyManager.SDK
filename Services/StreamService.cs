using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Streams;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class StreamService : NPMServiceBase, IStreamService
    {
        public StreamService(HttpClient httpClient, string baseUrl) 
            : base(httpClient, baseUrl)
        {
        }

        public Task<StreamModel[]> GetStreamsAsync(CancellationToken cancellationToken = default)
        {
            return GetStreamsAsync(null, cancellationToken);
        }

        public async Task<StreamModel[]> GetStreamsAsync(string expand, CancellationToken cancellationToken)
        {
            var path = "nginx/streams";
            if (!string.IsNullOrEmpty(expand))
            {
                path += $"?expand={expand}";
            }

            using var request = CreateRequest(HttpMethod.Get, path);
            return await SendAsync<StreamModel[]>(request, cancellationToken);
        }

        public async Task<StreamModel> GetStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"nginx/streams/{streamId}");
            return await SendAsync<StreamModel>(request, cancellationToken);
        }

        public async Task<StreamModel> CreateStreamAsync(CreateStreamRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "nginx/streams", request);
            return await SendAsync<StreamModel>(httpRequest, cancellationToken);
        }

        public async Task<StreamModel> UpdateStreamAsync(int streamId, UpdateStreamRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, $"nginx/streams/{streamId}", request);
            return await SendAsync<StreamModel>(httpRequest, cancellationToken);
        }

        public async Task DeleteStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"nginx/streams/{streamId}");
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task<bool> EnableStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"nginx/streams/{streamId}/enable");
            return await SendAsync<bool>(request, cancellationToken);
        }

        public async Task<bool> DisableStreamAsync(int streamId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"nginx/streams/{streamId}/disable");
            return await SendAsync<bool>(request, cancellationToken);
        }
    }
} 