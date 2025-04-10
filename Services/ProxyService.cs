using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Proxies;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class ProxyService : NPMServiceBase, IProxyService
    {
        public ProxyService(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        public Task<ProxyHost[]> GetProxyHostsAsync(CancellationToken cancellationToken = default)
        {
            return GetProxyHostsAsync(null, cancellationToken);
        }

        public async Task<ProxyHost[]> GetProxyHostsAsync(string expand, CancellationToken cancellationToken)
        {
            var path = "nginx/proxy-hosts";
            if (!string.IsNullOrEmpty(expand))
            {
                path += $"?expand={expand}";
            }

            using var request = CreateRequest(HttpMethod.Get, path);
            return await SendAsync<ProxyHost[]>(request, cancellationToken);
        }

        public async Task<ProxyHost> GetProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"nginx/proxy-hosts/{hostId}");
            return await SendAsync<ProxyHost>(request, cancellationToken);
        }

        public async Task<ProxyHost> CreateProxyHostAsync(ProxyHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "nginx/proxy-hosts", request);
            return await SendAsync<ProxyHost>(httpRequest, cancellationToken);
        }

        public async Task<ProxyHost> UpdateProxyHostAsync(int hostId, ProxyHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, $"nginx/proxy-hosts/{hostId}", request);
            return await SendAsync<ProxyHost>(httpRequest, cancellationToken);
        }

        public async Task DeleteProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"nginx/proxy-hosts/{hostId}");
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task<bool> EnableProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"nginx/proxy-hosts/{hostId}/enable");
            return await SendAsync<bool>(request, cancellationToken);
        }

        public async Task<bool> DisableProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Post, $"nginx/proxy-hosts/{hostId}/disable");
            return await SendAsync<bool>(request, cancellationToken);
        }
    }
} 