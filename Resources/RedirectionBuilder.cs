using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Redirections;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Collections.Generic;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Implementation of the redirection builder
    /// </summary>
    public class RedirectionBuilder : IRedirectionBuilder
    {
        private readonly RedirectionCreateRequest _request;
        private readonly IRedirectionService _redirectionService;
        /// <summary>
        /// Initializes a new instance of the RedirectionBuilder class
        /// </summary>
        public RedirectionBuilder(IRedirectionService redirectionService)
        {
            _request = new RedirectionCreateRequest
            {
                Enabled = true,
                PreservePath = true,
                SslForced = false,
                HstsEnabled = false,
                HstsSubdomains = false,
                Http2Support = false,
                Meta = new Dictionary<string, object>()
            };
            _redirectionService = redirectionService;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithName(string name)
        {
            _request.Name = name;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithDescription(string description)
        {
            _request.Description = description;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithEnabled(bool enabled)
        {
            _request.Enabled = enabled;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithDomainNames(string[] domainNames)
        {
            _request.DomainNames = domainNames;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithForwardScheme(string scheme)
        {
            _request.ForwardScheme = scheme;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithForwardHost(string host)
        {
            _request.ForwardHost = host;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithForwardPort(int port)
        {
            _request.ForwardPort = port;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithPreservePath(bool preservePath)
        {
            _request.PreservePath = preservePath;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithForceSsl(bool forceSsl)
        {
            _request.SslForced = forceSsl;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithHstsEnabled(bool hstsEnabled)
        {
            _request.HstsEnabled = hstsEnabled;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithHstsSubdomains(bool hstsSubdomains)
        {
            _request.HstsSubdomains = hstsSubdomains;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithHttp2Support(bool http2Support)
        {
            _request.Http2Support = http2Support;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithAdvancedConfig(string advancedConfig)
        {
            _request.AdvancedConfig = advancedConfig;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithCertificateId(int? certificateId)
        {
            _request.CertificateId = certificateId;
            return this;
        }

        /// <inheritdoc/>
        public IRedirectionBuilder WithMeta(Dictionary<string, object> meta)
        {
            _request.Meta = meta;
            return this;
        }

        /// <inheritdoc/>
        public RedirectionCreateRequest Build()
        {
            return _request;
        }

        /// <inheritdoc/>
        public async Task<OperationResult<Redirection>> CreateAsync()
        {
            return await _redirectionService.CreateAsync(_request);
        }
    }
} 