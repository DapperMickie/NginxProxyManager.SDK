using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AccessLists;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Service for managing access lists
    /// </summary>
    public interface IAccessListService
    {
        /// <summary>
        /// Gets an access list by ID
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result containing the access list</returns>
        Task<OperationResult<AccessList>> GetByIdAsync(int id);

        /// <summary>
        /// Gets all access lists
        /// </summary>
        /// <returns>The operation result containing the access lists</returns>
        Task<OperationResult<IEnumerable<AccessList>>> GetAllAsync();

        /// <summary>
        /// Creates a new access list
        /// </summary>
        /// <param name="accessList">The access list to create</param>
        /// <returns>The operation result containing the created access list</returns>
        Task<OperationResult<AccessList>> CreateAsync(AccessListCreateRequest accessList);

        /// <summary>
        /// Updates an existing access list
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <param name="accessList">The access list to update</param>
        /// <returns>The operation result containing the updated access list</returns>
        Task<OperationResult<AccessList>> UpdateAsync(int id, AccessListUpdateRequest accessList);

        /// <summary>
        /// Deletes an access list
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DeleteAsync(int id);

        /// <summary>
        /// Enables an access list
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> EnableAccessListAsync(int id);

        /// <summary>
        /// Disables an access list
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DisableAccessListAsync(int id);
    }
} 