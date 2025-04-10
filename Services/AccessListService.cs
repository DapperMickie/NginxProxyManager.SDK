using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.AccessLists;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class AccessListService : NPMServiceBase, IAccessListService
    {
        public AccessListService(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        public Task<AccessList[]> GetAccessListsAsync(CancellationToken cancellationToken = default)
        {
            return GetAccessListsAsync(null, cancellationToken);
        }

        public async Task<AccessList[]> GetAccessListsAsync(string expand, CancellationToken cancellationToken)
        {
            var path = "nginx/access-lists";
            if (!string.IsNullOrEmpty(expand))
            {
                path += $"?expand={expand}";
            }

            using var request = CreateRequest(HttpMethod.Get, path);
            return await SendAsync<AccessList[]>(request, cancellationToken);
        }

        public async Task<AccessList> CreateAccessListAsync(AccessListCreateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Post, "nginx/access-lists", request);
            return await SendAsync<AccessList>(httpRequest, cancellationToken);
        }

        public async Task<AccessListFull> GetAccessListAsync(int listId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, $"nginx/access-lists/{listId}");
            return await SendAsync<AccessListFull>(request, cancellationToken);
        }

        public async Task<AccessList> UpdateAccessListAsync(int listId, AccessListUpdateRequest request, CancellationToken cancellationToken = default)
        {
            using var httpRequest = CreateRequest(HttpMethod.Put, $"nginx/access-lists/{listId}", request);
            return await SendAsync<AccessList>(httpRequest, cancellationToken);
        }

        public async Task DeleteAccessListAsync(int listId, CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Delete, $"nginx/access-lists/{listId}");
            await SendAsync<object>(request, cancellationToken);
        }
    }
}