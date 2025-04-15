using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Redirections;
using NginxProxyManager.SDK.Resources;
using NginxProxyManager.SDK.Resources.Interfaces;
using NginxProxyManager.SDK.Services;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Client
{
    /// <summary>
    /// Client for interacting with the Nginx Proxy Manager API
    /// </summary>
    public class NginxProxyManagerClient : IDisposable
    {
        private readonly NginxProxyManagerClientFactory _factory;
        private readonly HttpClient _httpClient;
        private bool _disposed;

        /// <summary>
        /// Gets the proxy hosts resource
        /// </summary>
        public IProxyHostsResource ProxyHosts { get; }

        /// <summary>
        /// Gets the dead hosts resource
        /// </summary>
        public IDeadHostsResource DeadHosts { get; }

        /// <summary>
        /// Gets the access lists resource
        /// </summary>
        public IAccessListsResource AccessLists { get; }

        /// <summary>
        /// Gets the redirections resource
        /// </summary>
        public IRedirectionsResource Redirections { get; }

        /// <summary>
        /// Gets the audit logs resource
        /// </summary>
        public IAuditLogResource AuditLogs { get; }

        /// <summary>
        /// Gets the reports resource
        /// </summary>
        public IReportsResource Reports { get; }

        /// <summary>
        /// Gets the server errors resource
        /// </summary>
        public IServerErrorResource ServerErrors { get; }

        /// <summary>
        /// Gets the streams resource
        /// </summary>
        public IStreamResource Streams { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NginxProxyManagerClient"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL of the Nginx Proxy Manager API</param>
        /// <param name="credentials">The authentication credentials</param>
        public NginxProxyManagerClient(string baseUrl, AuthenticationCredentials credentials)
        {
            _factory = new NginxProxyManagerClientFactory(baseUrl, credentials);
            _httpClient = _factory.CreateClient();

            // Initialize services
            var proxyHostService = new ProxyHostService(_httpClient);
            var deadHostService = new DeadHostService(_httpClient);
            var accessListService = new AccessListService(_httpClient);
            var redirectionService = new RedirectionService(_httpClient);
            var auditLogService = new AuditLogService(_httpClient);
            var reportsService = new ReportsService(_httpClient);
            var serverErrorService = new ServerErrorService(_httpClient);
            var streamService = new StreamService(_httpClient);

            // Initialize resources
            ProxyHosts = new ProxyHostsResource(proxyHostService);
            DeadHosts = new DeadHostsResource(deadHostService);
            AccessLists = new AccessListsResource(accessListService);
            Redirections = new RedirectionsResource(redirectionService);
            AuditLogs = new AuditLogResource(auditLogService);
            Reports = new ReportsResource(reportsService);
            ServerErrors = new ServerErrorResource(serverErrorService);
            Streams = new StreamResource(streamService);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="NginxProxyManagerClient"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }

                _disposed = true;
            }
        }
    }
} 