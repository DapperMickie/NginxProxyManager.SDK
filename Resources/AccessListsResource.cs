using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AccessLists;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for managing access lists
    /// </summary>
    public class AccessListsResource : IAccessListsResource
    {
        private readonly IAccessListService _accessListService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessListsResource"/> class.
        /// </summary>
        /// <param name="accessListService">The access list service</param>
        public AccessListsResource(IAccessListService accessListService)
        {
            _accessListService = accessListService;
        }

        /// <inheritdoc />
        public IAccessListBuilder CreateBuilder()
        {
            return new AccessListBuilder(_accessListService);
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> GetAsync(int id)
        {
            return await _accessListService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> GetByIdAsync(int id)
        {
            return await _accessListService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AccessList>>> GetAllAsync()
        {
            var result = await _accessListService.GetAllAsync();
            return new OperationResult<IEnumerable<AccessList>>(result.Result);
        }

        /// <inheritdoc />
        public async Task<OperationResult<IEnumerable<AccessList>>> GetPageAsync(int page, int pageSize)
        {
            // This needs to be implemented in the service layer
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> CreateAsync(AccessListCreateRequest accessList)
        {
            return await _accessListService.CreateAsync(accessList);
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> CreateAsync(AccessList accessList)
        {
            // This method is not applicable for AccessLists as they require a CreateRequest
            throw new System.NotImplementedException("Use CreateAsync(AccessListCreateRequest) instead");
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> UpdateAsync(int id, AccessListUpdateRequest accessList)
        {
            return await _accessListService.UpdateAsync(id, accessList);
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> UpdateAsync(int id, AccessList accessList)
        {
            // This method is not applicable for AccessLists as they require an UpdateRequest
            throw new System.NotImplementedException("Use UpdateAsync(int, AccessListUpdateRequest) instead");
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            return await _accessListService.DeleteAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> EnableAsync(int id)
        {
            return await _accessListService.EnableAccessListAsync(id);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> DisableAsync(int id)
        {
            return await _accessListService.DisableAccessListAsync(id);
        }
    }
} 