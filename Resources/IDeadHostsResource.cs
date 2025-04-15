using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.DeadHosts;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Represents the DeadHosts resource
    /// </summary>
    public interface IDeadHostsResource : IResourceCollection<DeadHost>
    {
        /// <summary>
        /// Creates a builder for creating a new dead host
        /// </summary>
        /// <returns>The dead host builder</returns>
        IDeadHostBuilder CreateBuilder();

        /// <summary>
        /// Gets a dead host by ID
        /// </summary>
        /// <param name="id">The dead host ID</param>
        /// <returns>The operation result containing the dead host</returns>
        Task<OperationResult<DeadHost>> GetAsync(int id);

        /// <summary>
        /// Creates a new dead host
        /// </summary>
        /// <param name="deadHost">The dead host to create</param>
        /// <returns>The operation result containing the created dead host</returns>
        Task<OperationResult<DeadHost>> CreateAsync(CreateDeadHostRequest deadHost);

        /// <summary>
        /// Updates an existing dead host
        /// </summary>
        /// <param name="id">The dead host ID</param>
        /// <param name="deadHost">The dead host to update</param>
        /// <returns>The operation result containing the updated dead host</returns>
        Task<OperationResult<DeadHost>> UpdateAsync(int id, UpdateDeadHostRequest deadHost);
    }
} 