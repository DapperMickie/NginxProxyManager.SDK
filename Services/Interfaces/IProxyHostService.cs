using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Proxies;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Interface for proxy host service
    /// </summary>
    public interface IProxyHostService
    {
        /// <summary>
        /// Gets all proxy hosts
        /// </summary>
        /// <returns>Operation result containing proxy hosts</returns>
        Task<OperationResult<ProxyHost[]>> GetAllAsync();

        /// <summary>
        /// Gets a proxy host by ID
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <returns>Operation result containing the proxy host</returns>
        Task<OperationResult<ProxyHost>> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new proxy host
        /// </summary>
        /// <param name="request">The proxy host create request</param>
        /// <returns>Operation result containing the created proxy host</returns>
        Task<OperationResult<ProxyHost>> CreateAsync(ProxyHostCreateRequest request);

        /// <summary>
        /// Updates a proxy host
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <param name="request">The proxy host update request</param>
        /// <returns>Operation result containing the updated proxy host</returns>
        Task<OperationResult<ProxyHost>> UpdateAsync(int id, ProxyHostUpdateRequest request);

        /// <summary>
        /// Deletes a proxy host
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <returns>Operation result</returns>
        Task<OperationResult<bool>> DeleteAsync(int id);

        /// <summary>
        /// Creates a proxy host
        /// </summary>
        /// <param name="request">The proxy host create request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The created proxy host</returns>
        Task<ProxyHost> CreateProxyHostAsync(ProxyHostCreateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a proxy host
        /// </summary>
        /// <param name="hostId">The proxy host ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task DeleteProxyHostAsync(int hostId, CancellationToken cancellationToken = default);

        Task<bool> DisableProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<bool> EnableProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<ProxyHost> GetProxyHostAsync(int hostId, CancellationToken cancellationToken = default);
        Task<ProxyHost[]> GetProxyHostsAsync(CancellationToken cancellationToken = default);
        Task<ProxyHost[]> GetProxyHostsAsync(string expand, CancellationToken cancellationToken);
        Task<ProxyHost> UpdateProxyHostAsync(int hostId, ProxyHostCreateRequest request, CancellationToken cancellationToken = default);
    }
}