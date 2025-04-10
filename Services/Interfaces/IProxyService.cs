using NgninxProxyManager.SDK.Models.Proxies;

namespace NgninxProxyManager.SDK.Services.Interfaces
{
    public interface IProxyService
    {
        Task<ProxyHost> CreateProxyHostAsync(ProxyHostCreateRequest request, CancellationToken cancellationToken = default);
        Task DeleteProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<bool> DisableProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<bool> EnableProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<ProxyHost> GetProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<ProxyHost[]> GetProxyHostsAsync(CancellationToken cancellationToken = default);
        Task<ProxyHost[]> GetProxyHostsAsync(string expand, CancellationToken cancellationToken);
        Task<ProxyHost> UpdateProxyHostAsync(int hostId, ProxyHostCreateRequest request, CancellationToken cancellationToken = default);
    }
}