using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.DeadHosts;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    public interface IDeadHostService
    {
        Task<DeadHost[]> GetDeadHostsAsync(CancellationToken cancellationToken = default);
        Task<DeadHost> GetDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default);
        Task<DeadHost> CreateDeadHostAsync(CreateDeadHostRequest request, CancellationToken cancellationToken = default);
        Task<DeadHost> UpdateDeadHostAsync(int deadHostId, UpdateDeadHostRequest request, CancellationToken cancellationToken = default);
        Task DeleteDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default);
        Task<DeadHost[]> GetDeadHostsByDomainAsync(string domainName, CancellationToken cancellationToken = default);
        Task<DeadHost[]> GetDeadHostsByForwardHostAsync(string forwardHost, CancellationToken cancellationToken = default);
    }
} 