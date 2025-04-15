using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.DeadHosts;
using NginxProxyManager.SDK.Common;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Interface for the dead host service
    /// </summary>
    public interface IDeadHostService
    {
        /// <summary>
        /// Gets all dead hosts
        /// </summary>
        /// <returns>The operation result containing the dead hosts</returns>
        Task<OperationResult<DeadHost[]>> GetAllAsync();

        /// <summary>
        /// Gets a dead host by ID
        /// </summary>
        /// <param name="id">The dead host ID</param>
        /// <returns>The operation result containing the dead host</returns>
        Task<OperationResult<DeadHost>> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new dead host
        /// </summary>
        /// <param name="request">The create request</param>
        /// <returns>The operation result containing the created dead host</returns>
        Task<OperationResult<DeadHost>> CreateAsync(CreateDeadHostRequest request);

        /// <summary>
        /// Updates an existing dead host
        /// </summary>
        /// <param name="id">The dead host ID</param>
        /// <param name="request">The update request</param>
        /// <returns>The operation result containing the updated dead host</returns>
        Task<OperationResult<DeadHost>> UpdateAsync(int id, UpdateDeadHostRequest request);

        /// <summary>
        /// Deletes a dead host
        /// </summary>
        /// <param name="id">The dead host ID</param>
        /// <returns>The operation result indicating success or failure</returns>
        Task<OperationResult<bool>> DeleteAsync(int id);

        /// <summary>
        /// Gets dead hosts by domain name
        /// </summary>
        /// <param name="domainName">The domain name</param>
        /// <returns>The operation result containing the dead hosts</returns>
        Task<OperationResult<DeadHost[]>> GetByDomainAsync(string domainName);

        /// <summary>
        /// Gets dead hosts by forward host
        /// </summary>
        /// <param name="forwardHost">The forward host</param>
        /// <returns>The operation result containing the dead hosts</returns>
        Task<OperationResult<DeadHost[]>> GetByForwardHostAsync(string forwardHost);
    }
} 