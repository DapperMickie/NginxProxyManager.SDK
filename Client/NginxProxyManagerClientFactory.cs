using System;
using System.Net.Http;
using NginxProxyManager.SDK.Services;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Diagnostics;

namespace NginxProxyManager.SDK.Client
{
    /// <summary>
    /// Factory for creating Nginx Proxy Manager clients
    /// </summary>
    public class NginxProxyManagerClientFactory : IDisposable
    {
        private readonly string _baseUrl;
        private readonly AuthenticationCredentials _credentials;
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="NginxProxyManagerClientFactory"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL of the Nginx Proxy Manager API</param>
        /// <param name="credentials">The authentication credentials</param>
        public NginxProxyManagerClientFactory(string baseUrl, AuthenticationCredentials credentials)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));

            // Create the base HTTP client
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            _authService = new AuthService(_httpClient);
        }

        /// <summary>
        /// Creates a new HTTP client with authentication
        /// </summary>
        /// <returns>The authenticated HTTP client</returns>
        public HttpClient CreateClient()
        {
            Debug.WriteLine($"Creating client with base URL: {_baseUrl}");

            // Create the base handler
            var baseHandler = new HttpClientHandler();

            // Create the auth handler
            var authHandler = new AuthenticationHandler(_authService, _credentials);

            // Set up the pipeline
            authHandler.InnerHandler = baseHandler;

            // Create the final client with the pipeline
            var client = new HttpClient(authHandler)
            {
                BaseAddress = new Uri(_baseUrl)
            };

            Debug.WriteLine("Client created successfully");
            return client;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="NginxProxyManagerClientFactory"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }

                _disposed = true;
            }
        }
    }

    /// <summary>
    /// Pipeline of HTTP message handlers
    /// </summary>
    internal class HttpMessageHandlerPipeline : DelegatingHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMessageHandlerPipeline"/> class.
        /// </summary>
        /// <param name="handlers">The message handlers</param>
        public HttpMessageHandlerPipeline(params HttpMessageHandler[] handlers)
        {
            if (handlers == null || handlers.Length == 0)
                throw new ArgumentException("At least one handler must be provided", nameof(handlers));

            var current = handlers[0];
            for (int i = 1; i < handlers.Length; i++)
            {
                var next = handlers[i];
                if (current is DelegatingHandler delegatingHandler)
                {
                    delegatingHandler.InnerHandler = next;
                }
                current = next;
            }

            InnerHandler = current;
        }
    }
} 