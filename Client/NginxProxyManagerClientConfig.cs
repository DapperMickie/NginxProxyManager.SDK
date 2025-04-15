using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace NginxProxyManager.SDK.Client
{
    /// <summary>
    /// Configuration for the Nginx Proxy Manager client
    /// </summary>
    public class NginxProxyManagerClientConfig
    {
        /// <summary>
        /// Gets or sets the base URL for the Nginx Proxy Manager API
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Gets or sets the authentication credentials
        /// </summary>
        public AuthenticationCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP client timeout
        /// </summary>
        public TimeSpan Timeout { get; private set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Gets or sets the retry policy
        /// </summary>
        public RetryPolicy RetryPolicy { get; private set; } = RetryPolicy.None;

        /// <summary>
        /// Gets or sets the logger
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP client
        /// </summary>
        public HttpClient HttpClient { get; private set; }

        /// <summary>
        /// Sets the base URL for the Nginx Proxy Manager API
        /// </summary>
        /// <param name="baseUrl">The base URL</param>
        /// <returns>The configuration instance for method chaining</returns>
        public NginxProxyManagerClientConfig WithEndpoint(string baseUrl)
        {
            BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            return this;
        }

        /// <summary>
        /// Sets the authentication credentials
        /// </summary>
        /// <param name="credentials">The authentication credentials</param>
        /// <returns>The configuration instance for method chaining</returns>
        public NginxProxyManagerClientConfig WithAuthentication(AuthenticationCredentials credentials)
        {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            return this;
        }

        /// <summary>
        /// Sets the HTTP client timeout
        /// </summary>
        /// <param name="timeout">The timeout</param>
        /// <returns>The configuration instance for method chaining</returns>
        public NginxProxyManagerClientConfig WithTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            return this;
        }

        /// <summary>
        /// Sets the retry policy
        /// </summary>
        /// <param name="retryPolicy">The retry policy</param>
        /// <returns>The configuration instance for method chaining</returns>
        public NginxProxyManagerClientConfig WithRetryPolicy(RetryPolicy retryPolicy)
        {
            RetryPolicy = retryPolicy;
            return this;
        }

        /// <summary>
        /// Sets the logger
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <returns>The configuration instance for method chaining</returns>
        public NginxProxyManagerClientConfig WithLogging(ILogger logger)
        {
            Logger = logger;
            return this;
        }

        /// <summary>
        /// Sets the HTTP client
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        /// <returns>The configuration instance for method chaining</returns>
        public NginxProxyManagerClientConfig WithHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            return this;
        }
    }
} 