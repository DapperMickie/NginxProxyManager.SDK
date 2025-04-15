using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Proxies;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for managing proxy hosts
    /// </summary>
    public class ProxyHostsResource : IProxyHostsResource
    {
        private readonly IProxyHostService _proxyHostService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyHostsResource"/> class.
        /// </summary>
        /// <param name="proxyHostService">The proxy host service</param>
        public ProxyHostsResource(IProxyHostService proxyHostService)
        {
            _proxyHostService = proxyHostService;
        }

        /// <inheritdoc />
        public IProxyHostBuilder CreateBuilder()
        {
            return new ProxyHostBuilder(_proxyHostService);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> GetAsync(int id)
        {
            return await _proxyHostService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> GetByIdAsync(int id)
        {
            return await _proxyHostService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<ProxyHost>>> GetAllAsync()
        {
            var result = await _proxyHostService.GetAllAsync();
            return new OperationResult<IEnumerable<ProxyHost>>(result.Result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<ProxyHost>>> GetPageAsync(int page, int pageSize)
        {
            // This needs to be implemented in the service layer
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> CreateAsync(ProxyHostCreateRequest proxyHost)
        {
            return await _proxyHostService.CreateAsync(proxyHost);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> CreateAsync(ProxyHost proxyHost)
        {
            // This method is not applicable for ProxyHosts as they require a CreateRequest
            throw new System.NotImplementedException("Use CreateAsync(ProxyHostCreateRequest) instead");
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> UpdateAsync(int id, ProxyHostUpdateRequest proxyHost)
        {
            return await _proxyHostService.UpdateAsync(id, proxyHost);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> UpdateAsync(int id, ProxyHost proxyHost)
        {
            // This method is not applicable for ProxyHosts as they require an UpdateRequest
            throw new System.NotImplementedException("Use UpdateAsync(int, ProxyHostUpdateRequest) instead");
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            return await _proxyHostService.DeleteAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<ProxyHost>>> GetWithSslAsync()
        {
            // This needs to be implemented in the service layer
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<ProxyHost>>> GetWithHstsAsync()
        {
            // This needs to be implemented in the service layer
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<ProxyHost>>> GetWithHttp2SupportAsync()
        {
            // This needs to be implemented in the service layer
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Enables a proxy host
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult<bool>> EnableAsync(int id)
        {
            var result = await _proxyHostService.EnableProxyHostAsync(id);
            return new OperationResult<bool>(result);
        }

        /// <summary>
        /// Disables a proxy host
        /// </summary>
        /// <param name="id">The proxy host ID</param>
        /// <returns>Operation result</returns>
        public async Task<OperationResult<bool>> DisableAsync(int id)
        {
            var result = await _proxyHostService.DisableProxyHostAsync(id);
            return new OperationResult<bool>(result);
        }
    }
} 