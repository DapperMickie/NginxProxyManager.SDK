using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AccessLists;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Represents the AccessLists resource
    /// </summary>
    public interface IAccessListsResource : IResourceCollection<AccessList>
    {
        /// <summary>
        /// Creates a builder for creating a new access list
        /// </summary>
        /// <returns>The access list builder</returns>
        IAccessListBuilder CreateBuilder();

        /// <summary>
        /// Gets an access list by ID
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result containing the access list</returns>
        Task<OperationResult<AccessList>> GetAsync(int id);

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
        /// Enables an access list
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> EnableAsync(int id);

        /// <summary>
        /// Disables an access list
        /// </summary>
        /// <param name="id">The access list ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DisableAsync(int id);
    }
} 