using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Proxies;
using NginxProxyManager.SDK.Services;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Implementation of the proxy host builder
    /// </summary>
    public class ProxyHostBuilder : IProxyHostBuilder
    {
        private readonly IProxyHostService _proxyHostService;
        private readonly ProxyHostCreateRequest _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyHostBuilder"/> class.
        /// </summary>
        /// <param name="proxyHostService">The proxy host service</param>
        public ProxyHostBuilder(IProxyHostService proxyHostService)
        {
            _proxyHostService = proxyHostService;
            _request = new ProxyHostCreateRequest();
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithDomains(params string[] domainNames)
        {
            _request.DomainNames = domainNames;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder ForwardTo(string host)
        {
            _request.ForwardHost = host;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithPort(int port)
        {
            _request.ForwardPort = port;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithScheme(string scheme)
        {
            _request.ForwardScheme = scheme;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithSslEnabled()
        {
            _request.SslEnabled = true;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithSslDisabled()
        {
            _request.SslEnabled = false;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithHstsEnabled()
        {
            _request.HstsEnabled = true;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithHstsDisabled()
        {
            _request.HstsEnabled = false;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithHttp2SupportEnabled()
        {
            _request.Http2SupportEnabled = true;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithHttp2SupportDisabled()
        {
            _request.Http2SupportEnabled = false;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithWebSocketsEnabled()
        {
            _request.AllowWebsocketUpgrade = true;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithWebSocketsDisabled()
        {
            _request.AllowWebsocketUpgrade = false;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithBlockExploitsEnabled()
        {
            _request.BlockExploitsEnabled = true;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithBlockExploitsDisabled()
        {
            _request.BlockExploitsEnabled = false;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithAdvancedConfig(string config)
        {
            _request.AdvancedConfig = config;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithCertificate(int certificateId)
        {
            _request.CertificateId = certificateId;
            return this;
        }

        /// <inheritdoc />
        public IProxyHostBuilder WithAccessList(int accessListId)
        {
            _request.AccessListId = accessListId;
            return this;
        }

        /// <inheritdoc />
        public ProxyHostCreateRequest Build()
        {
            return _request;
        }

        /// <inheritdoc />
        public async Task<OperationResult<ProxyHost>> BuildAndCreateAsync()
        {
            return await _proxyHostService.CreateAsync(_request);
        }
    }
} 