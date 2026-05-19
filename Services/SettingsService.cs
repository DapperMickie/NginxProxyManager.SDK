using System.Net.Http.Json;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Settings;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class SettingsService : ISettingsService
    {
        private const string BasePath = "api/settings";
        private readonly HttpClient _httpClient;
        public SettingsService(HttpClient httpClient) => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        public async Task<OperationResult<Setting[]>> GetAllAsync(CancellationToken cancellationToken = default) => await SendAsync(() => _httpClient.GetFromJsonAsync<Setting[]>(BasePath, cancellationToken));
        public async Task<OperationResult<Setting>> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await SendAsync(() => _httpClient.GetFromJsonAsync<Setting>($"{BasePath}/{Uri.EscapeDataString(id)}", cancellationToken));
        public async Task<OperationResult<Setting>> UpdateAsync(string id, SettingUpdateRequest request, CancellationToken cancellationToken = default)
        {
            try { using var response = await _httpClient.PutAsJsonAsync($"{BasePath}/{Uri.EscapeDataString(id)}", request, cancellationToken); response.EnsureSuccessStatusCode(); return OperationResult<Setting>.Success(await response.Content.ReadFromJsonAsync<Setting>(cancellationToken)); }
            catch (Exception ex) { return OperationResult<Setting>.Failure(ex); }
        }
        private static async Task<OperationResult<T>> SendAsync<T>(Func<Task<T?>> action)
        {
            try { return OperationResult<T>.Success(await action()); }
            catch (Exception ex) { return OperationResult<T>.Failure(ex); }
        }
    }
}
