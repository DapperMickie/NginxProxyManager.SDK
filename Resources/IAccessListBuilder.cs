using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.AccessLists;
using NginxProxyManager.SDK.Common;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Interface for building access lists
    /// </summary>
    public interface IAccessListBuilder
    {
        /// <summary>
        /// Sets the name for the access list
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithName(string name);

        /// <summary>
        /// Sets the description for the access list
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithDescription(string description);

        /// <summary>
        /// Sets whether the access list is enabled
        /// </summary>
        /// <param name="enabled">Whether the access list is enabled</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithEnabled(bool enabled = true);

        /// <summary>
        /// Sets whether to satisfy all conditions (AND) or any condition (OR)
        /// </summary>
        /// <param name="satisfy">The satisfy value</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithSatisfy(string satisfy);

        /// <summary>
        /// Sets the IP addresses that are allowed/denied
        /// </summary>
        /// <param name="ipAddresses">The IP addresses</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithIpAddresses(string ipAddresses);

        /// <summary>
        /// Sets the basic authentication credentials
        /// </summary>
        /// <param name="basicAuth">The basic authentication credentials</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithBasicAuth(string basicAuth);

        /// <summary>
        /// Sets whether to allow or deny access
        /// </summary>
        /// <param name="action">The action</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithAction(string action);

        /// <summary>
        /// Sets the meta information for the access list
        /// </summary>
        /// <param name="meta">The meta information</param>
        /// <returns>The builder for chaining</returns>
        IAccessListBuilder WithMeta(object meta);

        /// <summary>
        /// Builds the access list create request
        /// </summary>
        /// <returns>The access list create request</returns>
        AccessListCreateRequest Build();

        /// <summary>
        /// Builds and creates the access list
        /// </summary>
        /// <returns>The operation result containing the created access list</returns>
        Task<OperationResult<AccessList>> BuildAndCreateAsync();
    }
} 