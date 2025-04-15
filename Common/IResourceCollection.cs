using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NginxProxyManager.SDK.Common
{
    /// <summary>
    /// Represents a collection of resources
    /// </summary>
    /// <typeparam name="T">The type of the resource</typeparam>
    public interface IResourceCollection<T>
    {
        /// <summary>
        /// Gets a page of resources
        /// </summary>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>The operation result containing the resources</returns>
        Task<OperationResult<IEnumerable<T>>> GetPageAsync(int page, int pageSize);

        /// <summary>
        /// Gets all resources
        /// </summary>
        /// <returns>The operation result containing the resources</returns>
        Task<OperationResult<IEnumerable<T>>> GetAllAsync();

        /// <summary>
        /// Gets a resource by ID
        /// </summary>
        /// <param name="id">The resource ID</param>
        /// <returns>The operation result containing the resource</returns>
        Task<OperationResult<T>> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new resource
        /// </summary>
        /// <param name="resource">The resource to create</param>
        /// <returns>The operation result containing the created resource</returns>
        Task<OperationResult<T>> CreateAsync(T resource);

        /// <summary>
        /// Updates an existing resource
        /// </summary>
        /// <param name="id">The resource ID</param>
        /// <param name="resource">The resource to update</param>
        /// <returns>The operation result containing the updated resource</returns>
        Task<OperationResult<T>> UpdateAsync(int id, T resource);

        /// <summary>
        /// Deletes a resource
        /// </summary>
        /// <param name="id">The resource ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
} 