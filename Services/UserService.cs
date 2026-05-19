using System.Net.Http.Json;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Users;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    public class UserService : IUserService
    {
        private const string BasePath = "api/users";
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient) => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        public async Task<OperationResult<User[]>> GetAllAsync(CancellationToken cancellationToken = default) => await SendAsync(() => _httpClient.GetFromJsonAsync<User[]>(BasePath, cancellationToken));
        public async Task<OperationResult<User>> GetByIdAsync(int id, CancellationToken cancellationToken = default) => await SendAsync(() => _httpClient.GetFromJsonAsync<User>($"{BasePath}/{id}", cancellationToken));
        public async Task<OperationResult<User>> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default) => await SendWriteAsync<User>(() => _httpClient.PostAsJsonAsync(BasePath, request, cancellationToken), cancellationToken);
        public async Task<OperationResult<User>> UpdateAsync(int id, UserUpdateRequest request, CancellationToken cancellationToken = default) => await SendWriteAsync<User>(() => _httpClient.PutAsJsonAsync($"{BasePath}/{id}", request, cancellationToken), cancellationToken);
        public async Task<OperationResult<bool>> UpdatePasswordAsync(int id, UserPasswordUpdateRequest request, CancellationToken cancellationToken = default)
        {
            try { using var response = await _httpClient.PutAsJsonAsync($"{BasePath}/{id}/auth", request, cancellationToken); response.EnsureSuccessStatusCode(); return OperationResult<bool>.Success(true); }
            catch (Exception ex) { return OperationResult<bool>.Failure(ex); }
        }
        public async Task<OperationResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try { using var response = await _httpClient.DeleteAsync($"{BasePath}/{id}", cancellationToken); response.EnsureSuccessStatusCode(); return OperationResult<bool>.Success(true); }
            catch (Exception ex) { return OperationResult<bool>.Failure(ex); }
        }
        private static async Task<OperationResult<T>> SendAsync<T>(Func<Task<T?>> action)
        {
            try { return OperationResult<T>.Success(await action()); }
            catch (Exception ex) { return OperationResult<T>.Failure(ex); }
        }
        private static async Task<OperationResult<T>> SendWriteAsync<T>(Func<Task<HttpResponseMessage>> action, CancellationToken cancellationToken)
        {
            try { using var response = await action(); response.EnsureSuccessStatusCode(); return OperationResult<T>.Success(await response.Content.ReadFromJsonAsync<T>(cancellationToken)); }
            catch (Exception ex) { return OperationResult<T>.Failure(ex); }
        }
    }
}
