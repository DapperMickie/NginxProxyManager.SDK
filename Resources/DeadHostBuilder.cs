using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.DeadHosts;
using NginxProxyManager.SDK.Services.Interfaces;
using NginxProxyManager.SDK.Common;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Implementation of the dead host builder
    /// </summary>
    public class DeadHostBuilder : IDeadHostBuilder
    {
        private readonly IDeadHostService _deadHostService;
        private readonly CreateDeadHostRequest _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeadHostBuilder"/> class.
        /// </summary>
        /// <param name="deadHostService">The dead host service</param>
        public DeadHostBuilder(IDeadHostService deadHostService)
        {
            _deadHostService = deadHostService;
            _request = new CreateDeadHostRequest();
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithDomains(params string[] domainNames)
        {
            _request.DomainNames = domainNames;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithCertificate(int certificateId)
        {
            _request.CertificateId = certificateId;
            return this;
        }


        /// <inheritdoc />
        public IDeadHostBuilder WithSslForced(bool sslForced = true)
        {
            _request.SslForced = sslForced;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithHstsEnabled(bool hstsEnabled = true)
        {
            _request.HstsEnabled = hstsEnabled;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithHstsSubdomains(bool hstsSubdomains = true)
        {
            _request.HstsSubdomains = hstsSubdomains;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithHttp2Support(bool http2Support = true)
        {
            _request.Http2Support = http2Support;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithAdvancedConfig(string config)
        {
            _request.AdvancedConfig = config;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithEnabled(bool enabled = true)
        {
            _request.Enabled = enabled;
            return this;
        }

        /// <inheritdoc />
        public IDeadHostBuilder WithMeta(object meta)
        {
            _request.Meta = meta;
            return this;
        }

        /// <inheritdoc />
        public CreateDeadHostRequest Build()
        {
            return _request;
        }

        /// <inheritdoc />
        public async Task<OperationResult<DeadHost>> BuildAndCreateAsync()
        {
            return await _deadHostService.CreateAsync(_request);
        }

        public IDeadHostBuilder WithNewCertificate()
        {
            throw new NotImplementedException();
        }
    }
} 