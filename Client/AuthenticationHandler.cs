using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Services;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Diagnostics;

namespace NginxProxyManager.SDK.Client
{
    /// <summary>
    /// HTTP message handler that adds authentication tokens to requests
    /// </summary>
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthService _authService;
        private readonly AuthenticationCredentials _credentials;
        private string _cachedToken;
        private const int MaxRetries = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationHandler"/> class.
        /// </summary>
        /// <param name="authService">The authentication service</param>
        /// <param name="credentials">The authentication credentials</param>
        public AuthenticationHandler(IAuthService authService, AuthenticationCredentials credentials)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Processing request: {request.Method} {request.RequestUri}");
            
            var retryCount = 0;
            HttpResponseMessage response;

            do
            {
                if (!string.IsNullOrEmpty(_cachedToken))
                {
                    Debug.WriteLine("Using cached token");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _cachedToken);
                }
                else
                {
                    Debug.WriteLine("No cached token, getting new token");
                    var token = await _authService.GetValidTokenAsync(_credentials);
                    _cachedToken = token;
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                response = await base.SendAsync(request, cancellationToken);
                
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && retryCount < MaxRetries)
                {
                    Debug.WriteLine("Received 401 Unauthorized, clearing token and retrying...");
                    _cachedToken = null;
                    retryCount++;
                    continue;
                }

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Request failed: {response.StatusCode}");
                    var content = await response.Content.ReadAsStringAsync(cancellationToken);
                    Debug.WriteLine($"Response content: {content}");
                }
                
                break;
            } while (retryCount <= MaxRetries);
            
            return response;
        }
    }
} 