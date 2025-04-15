using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.DeadHosts;
using NginxProxyManager.SDK.Services.Interfaces;
using NginxProxyManager.SDK.Common;
using System.Diagnostics;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for managing dead hosts
    /// </summary>
    public class DeadHostService : IDeadHostService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string BasePath = "api/dead-hosts";

        /// <summary>
        /// Initializes a new instance of the <see cref="DeadHostService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public DeadHostService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost[]>> GetAllAsync()
        {
            try
            {
                Debug.WriteLine($"Making GET request to: {BasePath}");
                var response = await _httpClient.GetFromJsonAsync<DeadHost[]>(BasePath);
                return OperationResult<DeadHost[]>.Success(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAllAsync: {ex}");
                return OperationResult<DeadHost[]>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DeadHost>($"{BasePath}/{id}");
                return OperationResult<DeadHost>.Success(response);
            }
            catch (Exception ex)
            {
                return OperationResult<DeadHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> CreateAsync(CreateDeadHostRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BasePath, request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<DeadHost>();
                return OperationResult<DeadHost>.Success(result);
            }
            catch (Exception ex)
            {
                return OperationResult<DeadHost>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> UpdateAsync(int id, UpdateDeadHostRequest request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BasePath}/{id}", request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<DeadHost>();
                return OperationResult<DeadHost>.Success(result);
            }
            catch (Exception ex)
            {
                return OperationResult<DeadHost>.Failure(ex);
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
        public async Task<OperationResult<DeadHost[]>> GetByDomainAsync(string domainName)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DeadHost[]>($"{BasePath}/domain/{domainName}");
                return OperationResult<DeadHost[]>.Success(response);
            }
            catch (Exception ex)
            {
                return OperationResult<DeadHost[]>.Failure(ex);
            }
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost[]>> GetByForwardHostAsync(string forwardHost)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DeadHost[]>($"{BasePath}/forward-host/{forwardHost}");
                return OperationResult<DeadHost[]>.Success(response);
            }
            catch (Exception ex)
            {
                return OperationResult<DeadHost[]>.Failure(ex);
            }
        }
    }
} 