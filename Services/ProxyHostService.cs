using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Client;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Proxies;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Net.Http.Json;
using NginxProxyManager.SDK.Models.Common;
using System.Diagnostics;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for managing proxy hosts
    /// </summary>
    public class ProxyHostService : IProxyHostService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string BasePath = "api/nginx/proxy-hosts";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyHostService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public ProxyHostService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost[]>> GetAllAsync()
        {
            try
            {
                Debug.WriteLine($"Making GET request to: {BasePath}");
                var response = await _httpClient.GetFromJsonAsync<ProxyHost[]>(BasePath);
                return OperationResult<ProxyHost[]>.Success(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAllAsync: {ex}");
                return OperationResult<ProxyHost[]>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ProxyHost>($"{BasePath}/{id}");
                return OperationResult<ProxyHost>.Success(response);
            }
            catch (Exception ex)
            {
                return OperationResult<ProxyHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> CreateAsync(ProxyHostCreateRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BasePath, request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<ProxyHost>();
                return OperationResult<ProxyHost>.Success(result);
            }
            catch (Exception ex)
            {
                return OperationResult<ProxyHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> UpdateAsync(int id, ProxyHostUpdateRequest request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BasePath}/{id}", request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<ProxyHost>();
                return OperationResult<ProxyHost>.Success(result);
            }
            catch (Exception ex)
            {
                return OperationResult<ProxyHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
                response.EnsureSuccessStatusCode();
                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<ProxyHost> CreateProxyHostAsync(ProxyHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(request, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(BasePath, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ProxyHost>(responseContent, _jsonOptions);
        }

        /// <inheritdoc />
        public async Task DeleteProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{hostId}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        public async Task<bool> DisableProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsync($"{BasePath}/{hostId}/disable", null, cancellationToken);
            response.EnsureSuccessStatusCode();
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> EnableProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsync($"{BasePath}/{hostId}/enable", null, cancellationToken);
            response.EnsureSuccessStatusCode();
            return true;
        }

        /// <inheritdoc />
        public async Task<ProxyHost> GetProxyHostAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{hostId}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ProxyHost>(content, _jsonOptions);
        }

        /// <inheritdoc />
        public async Task<ProxyHost[]> GetProxyHostsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(BasePath, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ProxyHost[]>(content, _jsonOptions);
        }

        /// <inheritdoc />
        public async Task<ProxyHost[]> GetProxyHostsAsync(string expand, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"{BasePath}?expand={expand}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ProxyHost[]>(content, _jsonOptions);
        }

        /// <inheritdoc />
        public async Task<ProxyHost> UpdateProxyHostAsync(int hostId, ProxyHostCreateRequest request, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(request, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BasePath}/{hostId}", content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ProxyHost>(responseContent, _jsonOptions);
        }
    }
} 