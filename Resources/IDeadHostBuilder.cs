using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.DeadHosts;
using NginxProxyManager.SDK.Common;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Interface for building dead hosts
    /// </summary>
    public interface IDeadHostBuilder
    {
        /// <summary>
        /// Sets the domain names for the dead host
        /// </summary>
        /// <param name="domainNames">The domain names</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithDomains(params string[] domainNames);

        /// <summary>
        /// Sets the certificate ID for the dead host
        /// </summary>
        /// <param name="certificateId">The certificate ID</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithCertificate(int certificateId);

        /// <summary>
        /// Sets the certificate ID to "new" for the dead host
        /// </summary>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithNewCertificate();

        /// <summary>
        /// Sets whether SSL is forced for the dead host
        /// </summary>
        /// <param name="sslForced">Whether SSL is forced</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithSslForced(bool sslForced = true);

        /// <summary>
        /// Sets whether HSTS is enabled for the dead host
        /// </summary>
        /// <param name="hstsEnabled">Whether HSTS is enabled</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithHstsEnabled(bool hstsEnabled = true);

        /// <summary>
        /// Sets whether HSTS subdomains are enabled for the dead host
        /// </summary>
        /// <param name="hstsSubdomains">Whether HSTS subdomains are enabled</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithHstsSubdomains(bool hstsSubdomains = true);

        /// <summary>
        /// Sets whether HTTP/2 support is enabled for the dead host
        /// </summary>
        /// <param name="http2Support">Whether HTTP/2 support is enabled</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithHttp2Support(bool http2Support = true);

        /// <summary>
        /// Sets the advanced configuration for the dead host
        /// </summary>
        /// <param name="config">The advanced configuration</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithAdvancedConfig(string config);

        /// <summary>
        /// Sets whether the dead host is enabled
        /// </summary>
        /// <param name="enabled">Whether the dead host is enabled</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithEnabled(bool enabled = true);

        /// <summary>
        /// Sets the meta information for the dead host
        /// </summary>
        /// <param name="meta">The meta information</param>
        /// <returns>The builder for chaining</returns>
        IDeadHostBuilder WithMeta(object meta);

        /// <summary>
        /// Builds the dead host create request
        /// </summary>
        /// <returns>The dead host create request</returns>
        CreateDeadHostRequest Build();

        /// <summary>
        /// Builds and creates the dead host
        /// </summary>
        /// <returns>The operation result containing the created dead host</returns>
        Task<OperationResult<DeadHost>> BuildAndCreateAsync();
    }
} 