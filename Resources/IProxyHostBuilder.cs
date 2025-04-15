using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Proxies;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Builder for creating a new proxy host
    /// </summary>
    public interface IProxyHostBuilder
    {
        /// <summary>
        /// Sets the domain names for the proxy host
        /// </summary>
        /// <param name="domainNames">The domain names</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithDomains(params string[] domainNames);

        /// <summary>
        /// Sets the forward host for the proxy host
        /// </summary>
        /// <param name="host">The forward host</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder ForwardTo(string host);

        /// <summary>
        /// Sets the forward port for the proxy host
        /// </summary>
        /// <param name="port">The forward port</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithPort(int port);

        /// <summary>
        /// Sets the forward scheme for the proxy host
        /// </summary>
        /// <param name="scheme">The forward scheme</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithScheme(string scheme);

        /// <summary>
        /// Enables SSL for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithSslEnabled();

        /// <summary>
        /// Disables SSL for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithSslDisabled();

        /// <summary>
        /// Enables HSTS for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithHstsEnabled();

        /// <summary>
        /// Disables HSTS for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithHstsDisabled();

        /// <summary>
        /// Enables HSTS subdomains for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithHstsSubdomainsEnabled();

        /// <summary>
        /// Disables HSTS subdomains for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithHstsSubdomainsDisabled();

        /// <summary>
        /// Enables HTTP/2 support for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithHttp2SupportEnabled();

        /// <summary>
        /// Disables HTTP/2 support for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithHttp2SupportDisabled();

        /// <summary>
        /// Enables WebSockets support for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithWebSocketsEnabled();

        /// <summary>
        /// Disables WebSockets support for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithWebSocketsDisabled();

        /// <summary>
        /// Enables blocking of common exploits for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithBlockExploitsEnabled();

        /// <summary>
        /// Disables blocking of common exploits for the proxy host
        /// </summary>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithBlockExploitsDisabled();

        /// <summary>
        /// Sets the advanced configuration for the proxy host
        /// </summary>
        /// <param name="config">The advanced configuration</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithAdvancedConfig(string config);

        /// <summary>
        /// Sets the certificate ID for the proxy host
        /// </summary>
        /// <param name="certificateId">The certificate ID</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithCertificate(int certificateId);

        /// <summary>
        /// Sets the access list ID for the proxy host
        /// </summary>
        /// <param name="accessListId">The access list ID</param>
        /// <returns>The builder instance for method chaining</returns>
        IProxyHostBuilder WithAccessList(int accessListId);

        /// <summary>
        /// Builds the proxy host create request
        /// </summary>
        /// <returns>The proxy host create request</returns>
        ProxyHostCreateRequest Build();

        /// <summary>
        /// Builds the proxy host create request and creates the proxy host
        /// </summary>
        /// <returns>The operation result containing the created proxy host</returns>
        Task<OperationResult<ProxyHost>> BuildAndCreateAsync();
    }
} 