using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.DeadHosts;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for managing dead hosts
    /// </summary>
    public class DeadHostsResource : IDeadHostsResource
    {
        private readonly IDeadHostService _deadHostService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeadHostsResource"/> class.
        /// </summary>
        /// <param name="deadHostService">The dead host service</param>
        public DeadHostsResource(IDeadHostService deadHostService)
        {
            _deadHostService = deadHostService;
        }

        /// <inheritdoc />
        public IDeadHostBuilder CreateBuilder()
        {
            return new DeadHostBuilder(_deadHostService);
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> GetAsync(int id)
        {
            return await _deadHostService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> GetByIdAsync(int id)
        {
            return await _deadHostService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<DeadHost>>> GetAllAsync()
        {
            var result = await _deadHostService.GetAllAsync();
            return new OperationResult<IEnumerable<DeadHost>>(result.Result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<DeadHost>>> GetPageAsync(int page, int pageSize)
        {
            // This needs to be implemented in the service layer
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> CreateAsync(CreateDeadHostRequest deadHost)
        {
            return await _deadHostService.CreateAsync(deadHost);
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> CreateAsync(DeadHost deadHost)
        {
            // This method is not applicable for DeadHosts as they require a CreateRequest
            throw new System.NotImplementedException("Use CreateAsync(CreateDeadHostRequest) instead");
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> UpdateAsync(int id, UpdateDeadHostRequest deadHost)
        {
            return await _deadHostService.UpdateAsync(id, deadHost);
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> UpdateAsync(int id, DeadHost deadHost)
        {
            // This method is not applicable for DeadHosts as they require a CreateRequest
            throw new System.NotImplementedException("Use UpdateAsync(int, UpdateDeadHostRequest) instead");
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            return await _deadHostService.DeleteAsync(id);
        }
    }
} 