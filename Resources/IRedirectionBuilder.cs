using NginxProxyManager.SDK.Models.Redirections;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Represents a builder for creating redirections
    /// </summary>
    public interface IRedirectionBuilder
    {
        /// <summary>
        /// Sets the name of the redirection
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithName(string name);

        /// <summary>
        /// Sets the description of the redirection
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithDescription(string description);

        /// <summary>
        /// Sets whether the redirection is enabled
        /// </summary>
        /// <param name="enabled">Whether the redirection is enabled</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithEnabled(bool enabled);

        /// <summary>
        /// Sets the domain names for the redirection
        /// </summary>
        /// <param name="domainNames">The domain names</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithDomainNames(string[] domainNames);

        /// <summary>
        /// Sets the forward scheme for the redirection
        /// </summary>
        /// <param name="scheme">The forward scheme</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithForwardScheme(string scheme);

        /// <summary>
        /// Sets the forward host for the redirection
        /// </summary>
        /// <param name="host">The forward host</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithForwardHost(string host);

        /// <summary>
        /// Sets the forward port for the redirection
        /// </summary>
        /// <param name="port">The forward port</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithForwardPort(int port);

        /// <summary>
        /// Sets whether to preserve the path in the redirection
        /// </summary>
        /// <param name="preservePath">Whether to preserve the path</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithPreservePath(bool preservePath);

        /// <summary>
        /// Sets whether to force SSL in the redirection
        /// </summary>
        /// <param name="forceSsl">Whether to force SSL</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithForceSsl(bool forceSsl);

        /// <summary>
        /// Sets whether HSTS is enabled for the redirection
        /// </summary>
        /// <param name="hstsEnabled">Whether HSTS is enabled</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithHstsEnabled(bool hstsEnabled);

        /// <summary>
        /// Sets whether HSTS subdomains are enabled for the redirection
        /// </summary>
        /// <param name="hstsSubdomains">Whether HSTS subdomains are enabled</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithHstsSubdomains(bool hstsSubdomains);

        /// <summary>
        /// Sets whether HTTP/2 is supported for the redirection
        /// </summary>
        /// <param name="http2Support">Whether HTTP/2 is supported</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithHttp2Support(bool http2Support);

        /// <summary>
        /// Sets the advanced configuration for the redirection
        /// </summary>
        /// <param name="advancedConfig">The advanced configuration</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithAdvancedConfig(string advancedConfig);

        /// <summary>
        /// Sets the certificate ID for the redirection
        /// </summary>
        /// <param name="certificateId">The certificate ID</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithCertificateId(int? certificateId);

        /// <summary>
        /// Sets the metadata for the redirection
        /// </summary>
        /// <param name="meta">The metadata</param>
        /// <returns>The builder instance</returns>
        IRedirectionBuilder WithMeta(Dictionary<string, object> meta);

        /// <summary>
        /// Builds the redirection create request
        /// </summary>
        /// <returns>The redirection create request</returns>
        RedirectionCreateRequest Build();
    }
} 