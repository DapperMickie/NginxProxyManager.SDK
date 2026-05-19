using System;

namespace NginxProxyManager.SDK.Configuration
{
    public class NPMConfiguration
    {
        /// <summary>
        /// The base URL of your Nginx Proxy Manager instance (e.g., "http://localhost:81")
        /// </summary>
        public string BaseUrl { get; set; } = default!;

        /// <summary>
        /// The email/username for authentication
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// The password for authentication
        /// </summary>
        public string Password { get; set; } = default!;

        /// <summary>
        /// Optional timeout for HTTP requests in seconds (default: 30)
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// Optional flag to ignore SSL certificate validation (default: false)
        /// </summary>
        public bool IgnoreSslValidation { get; set; } = false;
    }
} 