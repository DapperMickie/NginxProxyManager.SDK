using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Redirections;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class RedirectionService : NPMServiceBase, IRedirectionService
    {
        public RedirectionService(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        public Task<RedirectionHost[]> GetRedirectionHostsAsync(CancellationToken cancellationToken = default)
        {
            return GetRedirectionHostsAsync(null, cancellationToken);
        }

        public async Task<RedirectionHost[]> GetRedirectionHostsAsync(string expand, CancellationToken cancellationToken)
        {
            var path = "nginx/redirection-hosts";
            if (!string.IsNullOrEmpty(expand))
            {
                path += $"?expand={expand}";
            }

            using var request = CreateRequest(HttpMethod.Get, path);
            return await SendAsync<RedirectionHost[]>(request, cancellationToken);
        }

        public async Task<RedirectionHost> GetRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"nginx/redirection-hosts/{hostId}");
            return await SendAsync<RedirectionHost>(request, cancellationToken);
        }

        public async Task<RedirectionHost> CreateRedirectionHostAsync(RedirectionHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "nginx/redirection-hosts", request);
            return await SendAsync<RedirectionHost>(httpRequest, cancellationToken);
        }

        public async Task<RedirectionHost> UpdateRedirectionHostAsync(int hostId, RedirectionHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, $"nginx/redirection-hosts/{hostId}", request);
            return await SendAsync<RedirectionHost>(httpRequest, cancellationToken);
        }

        public async Task DeleteRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"nginx/redirection-hosts/{hostId}");
            await SendAsync<object>(request, cancellationToken);
        }
    }
} 