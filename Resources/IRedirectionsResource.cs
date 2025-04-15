using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Redirections;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Represents the Redirections resource
    /// </summary>
    public interface IRedirectionsResource : IResourceCollection<Redirection>
    {
        /// <summary>
        /// Creates a builder for creating a new redirection
        /// </summary>
        /// <returns>The redirection builder</returns>
        IRedirectionBuilder CreateBuilder();

        /// <summary>
        /// Gets a redirection by ID
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result containing the redirection</returns>
        Task<OperationResult<Redirection>> GetAsync(int id);

        /// <summary>
        /// Creates a new redirection
        /// </summary>
        /// <param name="redirection">The redirection to create</param>
        /// <returns>The operation result containing the created redirection</returns>
        Task<OperationResult<Redirection>> CreateAsync(RedirectionCreateRequest redirection);

        /// <summary>
        /// Updates an existing redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <param name="redirection">The redirection to update</param>
        /// <returns>The operation result containing the updated redirection</returns>
        Task<OperationResult<Redirection>> UpdateAsync(int id, RedirectionUpdateRequest redirection);

        /// <summary>
        /// Enables a redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> EnableAsync(int id);

        /// <summary>
        /// Disables a redirection
        /// </summary>
        /// <param name="id">The redirection ID</param>
        /// <returns>The operation result</returns>
        Task<OperationResult<bool>> DisableAsync(int id);
    }
} 