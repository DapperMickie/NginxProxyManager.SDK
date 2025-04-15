using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AccessLists;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for managing access lists
    /// </summary>
    public class AccessListService : NPMServiceBase, IAccessListService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessListService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public AccessListService(System.Net.Http.HttpClient httpClient) : base(httpClient, "api/access-lists")
        {
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> GetByIdAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Get, $"{id}");
            var result = await SendAsync<AccessList>(request);
            return new OperationResult<AccessList>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AccessList>>> GetAllAsync()
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Get, "");
            var result = await SendAsync<IEnumerable<AccessList>>(request);
            return new OperationResult<IEnumerable<AccessList>>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> CreateAsync(AccessListCreateRequest accessList)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Post, "", accessList);
            var result = await SendAsync<AccessList>(request);
            return new OperationResult<AccessList>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> UpdateAsync(int id, AccessListUpdateRequest accessList)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Put, $"{id}", accessList);
            var result = await SendAsync<AccessList>(request);
            return new OperationResult<AccessList>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Delete, $"{id}");
            await SendAsync<object>(request);
            return new OperationResult<bool>(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> EnableAccessListAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Post, $"{id}/enable");
            await SendAsync<object>(request);
            return new OperationResult<bool>(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DisableAccessListAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Post, $"{id}/disable");
            await SendAsync<object>(request);
            return new OperationResult<bool>(true);
        }
    }
}