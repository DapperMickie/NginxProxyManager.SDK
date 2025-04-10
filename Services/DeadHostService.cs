using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.DeadHosts;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class DeadHostService : NPMServiceBase, IDeadHostService
    {
        public DeadHostService(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        public async Task<DeadHost[]> GetDeadHostsAsync(CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, "api/dead-hosts");
            return await SendAsync<DeadHost[]>(request, cancellationToken);
        }

        public async Task<DeadHost> GetDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/dead-hosts/{deadHostId}");
            return await SendAsync<DeadHost>(request, cancellationToken);
        }

        public async Task<DeadHost> CreateDeadHostAsync(CreateDeadHostRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "api/dead-hosts", request);
            return await SendAsync<DeadHost>(httpRequest, cancellationToken);
        }

        public async Task<DeadHost> UpdateDeadHostAsync(int deadHostId, UpdateDeadHostRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, $"api/dead-hosts/{deadHostId}", request);
            return await SendAsync<DeadHost>(httpRequest, cancellationToken);
        }

        public async Task DeleteDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"api/dead-hosts/{deadHostId}");
            await SendAsync<object>(request, cancellationToken);
        }

        public async Task<DeadHost[]> GetDeadHostsByDomainAsync(string domainName, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/dead-hosts/domain/{domainName}");
            return await SendAsync<DeadHost[]>(request, cancellationToken);
        }

        public async Task<DeadHost[]> GetDeadHostsByForwardHostAsync(string forwardHost, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"api/dead-hosts/forward-host/{forwardHost}");
            return await SendAsync<DeadHost[]>(request, cancellationToken);
        }
    }
} 