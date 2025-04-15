using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Redirections;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for managing redirections
    /// </summary>
    public class RedirectionService : NPMServiceBase, IRedirectionService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectionService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public RedirectionService(System.Net.Http.HttpClient httpClient) : base(httpClient, "api/redirections")
        {
        }

        /// <inheritdoc />
        public async Task<OperationResult<Redirection>> GetByIdAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Get, $"{id}");
            var result = await SendAsync<Redirection>(request);
            return new OperationResult<Redirection>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<Redirection>>> GetAllAsync()
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Get, "");
            var result = await SendAsync<IEnumerable<Redirection>>(request);
            return new OperationResult<IEnumerable<Redirection>>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<Redirection>>> GetPageAsync(int page, int pageSize)
        {
            var request = CreateRequest(HttpMethod.Get, $"?page={page}&pageSize={pageSize}");
            var result = await SendAsync<IEnumerable<Redirection>>(request);
            return new OperationResult<IEnumerable<Redirection>>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<Redirection>> CreateAsync(RedirectionCreateRequest redirection)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Post, "", redirection);
            var result = await SendAsync<Redirection>(request);
            return new OperationResult<Redirection>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<Redirection>> UpdateAsync(int id, RedirectionUpdateRequest redirection)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Put, $"{id}", redirection);
            var result = await SendAsync<Redirection>(request);
            return new OperationResult<Redirection>(result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Delete, $"{id}");
            await SendAsync<object>(request);
            return new OperationResult<bool>(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> EnableRedirectionAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Post, $"{id}/enable");
            await SendAsync<object>(request);
            return new OperationResult<bool>(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DisableRedirectionAsync(int id)
        {
            var request = CreateRequest(System.Net.Http.HttpMethod.Post, $"{id}/disable");
            await SendAsync<object>(request);
            return new OperationResult<bool>(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<RedirectionHost[]>> GetRedirectionHostsAsync(CancellationToken cancellationToken = default)
        {
            return await GetRedirectionHostsAsync(null, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<OperationResult<RedirectionHost[]>> GetRedirectionHostsAsync(string expand, CancellationToken cancellationToken)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: nginx/redirection-hosts");
                var path = "nginx/redirection-hosts";
                if (!string.IsNullOrEmpty(expand))
                {
                    path += $"?expand={expand}";
                }

                using var request = CreateRequest(HttpMethod.Get, path);
                var response = await SendAsync<RedirectionHost[]>(request, cancellationToken);
                return OperationResult<RedirectionHost[]>.Success(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetRedirectionHostsAsync: {ex}");
                return OperationResult<RedirectionHost[]>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<RedirectionHost>> GetRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making GET request to: nginx/redirection-hosts/{hostId}");
                using var request = CreateRequest(HttpMethod.Get, $"nginx/redirection-hosts/{hostId}");
                var response = await SendAsync<RedirectionHost>(request, cancellationToken);
                return OperationResult<RedirectionHost>.Success(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetRedirectionHostAsync: {ex}");
                return OperationResult<RedirectionHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<RedirectionHost>> CreateRedirectionHostAsync(RedirectionHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making POST request to: nginx/redirection-hosts");
                using var httpRequest = CreateRequest(HttpMethod.Post, "nginx/redirection-hosts", request);
                var response = await SendAsync<RedirectionHost>(httpRequest, cancellationToken);
                return OperationResult<RedirectionHost>.Success(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in CreateRedirectionHostAsync: {ex}");
                return OperationResult<RedirectionHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<RedirectionHost>> UpdateRedirectionHostAsync(int hostId, RedirectionHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making PUT request to: nginx/redirection-hosts/{hostId}");
                using var httpRequest = CreateRequest(HttpMethod.Put, $"nginx/redirection-hosts/{hostId}", request);
                var response = await SendAsync<RedirectionHost>(httpRequest, cancellationToken);
                return OperationResult<RedirectionHost>.Success(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in UpdateRedirectionHostAsync: {ex}");
                return OperationResult<RedirectionHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            try
            {
                Debug.WriteLine($"Making DELETE request to: nginx/redirection-hosts/{hostId}");
                using var request = CreateRequest(HttpMethod.Delete, $"nginx/redirection-hosts/{hostId}");
                await SendAsync<object>(request, cancellationToken);
                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in DeleteRedirectionHostAsync: {ex}");
                return OperationResult<bool>.Failure(ex);
            }
        }
    }
} 