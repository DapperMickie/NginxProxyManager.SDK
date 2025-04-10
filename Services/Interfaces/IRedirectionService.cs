using NginxProxyManager.SDK.Models.Redirections;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    public interface IRedirectionService
    {
        Task<RedirectionHost> CreateRedirectionHostAsync(RedirectionHostCreateRequest request, CancellationToken cancellationToken = default);
        Task DeleteRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<RedirectionHost> GetRedirectionHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<RedirectionHost[]> GetRedirectionHostsAsync(CancellationToken cancellationToken = default);
        Task<RedirectionHost[]> GetRedirectionHostsAsync(string expand, CancellationToken cancellationToken);
        Task<RedirectionHost> UpdateRedirectionHostAsync(int hostId, RedirectionHostCreateRequest request, CancellationToken cancellationToken = default);
    }
}