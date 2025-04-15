using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Proxies;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Represents the ProxyHosts resource
    /// </summary>
    public interface IProxyHostsResource : IResourceCollection<ProxyHost>
    {
        /// <summary>
        /// Creates a builder for creating a new proxy host
        /// </summary>
        /// <returns>The proxy host builder</returns>
        IProxyHostBuilder CreateBuilder();

        /// <summary>
        /// Gets a proxy host by ID
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <returns>The operation result containing the proxy host</returns>
        Task<OperationResult<ProxyHost>> GetAsync(int id);

        /// <summary>
        /// Gets all proxy hosts
        /// </summary>
        /// <returns>The operation result containing the proxy hosts</returns>
        Task<OperationResult<IEnumerable<ProxyHost>>> GetAllAsync();

        /// <summary>
        /// Gets a page of proxy hosts
        /// </summary>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>The operation result containing the proxy hosts</returns>
        Task<OperationResult<IEnumerable<ProxyHost>>> GetPageAsync(int page, int pageSize);

        /// <summary>
        /// Creates a new proxy host
        /// </summary>
        /// <param name="proxyHost">The proxy host to create</param>
        /// <returns>The operation result containing the created proxy host</returns>
        Task<OperationResult<ProxyHost>> CreateAsync(ProxyHostCreateRequest proxyHost);

        /// <summary>
        /// Updates an existing proxy host
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <param name="proxyHost">The proxy host to update</param>
        /// <returns>The operation result containing the updated proxy host</returns>
        Task<OperationResult<ProxyHost>> UpdateAsync(int id, ProxyHostUpdateRequest proxyHost);

        /// <summary>
        /// Deletes a proxy host
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DeleteAsync(int id);

        /// <summary>
        /// Gets proxy hosts with SSL enabled
        /// </summary>
        /// <returns>The operation result containing the proxy hosts</returns>
        Task<OperationResult<IEnumerable<ProxyHost>>> GetWithSslAsync();

        /// <summary>
        /// Gets proxy hosts with HSTS enabled
        /// </summary>
        /// <returns>The operation result containing the proxy hosts</returns>
        Task<OperationResult<IEnumerable<ProxyHost>>> GetWithHstsAsync();

        /// <summary>
        /// Gets proxy hosts with HTTP/2 support
        /// </summary>
        /// <returns>The operation result containing the proxy hosts</returns>
        Task<OperationResult<IEnumerable<ProxyHost>>> GetWithHttp2SupportAsync();
    }
} 