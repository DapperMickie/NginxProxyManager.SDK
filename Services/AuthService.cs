using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.Auth;
using NginxProxyManager.SDK.Services.Interfaces;
using NginxProxyManager.SDK.Client;
using System.Diagnostics;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for handling authentication with the Nginx Proxy Manager API
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private string _cachedToken;
        private DateTime _tokenExpiration;
        private static readonly TimeSpan _refreshBuffer = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <inheritdoc />
        public async Task<string> AuthenticateAsync(AuthenticationCredentials credentials)
        {
            try
            {
                Debug.WriteLine($"Attempting authentication for identity: {credentials.Identity}");
                var request = new TokenRequest
                {
                    Identity = credentials.Identity,
                    Secret = credentials.Secret
                };

                Debug.WriteLine("Making POST request to api/tokens");
                var response = await _httpClient.PostAsJsonAsync("api/tokens", request);
                
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Authentication failed: {response.StatusCode} - {error}");
                    throw new System.Net.Http.HttpRequestException($"Authentication failed: {response.StatusCode} - {error}");
                }

                var result = await response.Content.ReadFromJsonAsync<TokenResponse>(_jsonOptions);
                _cachedToken = result.Token;
                _tokenExpiration = result.Expires;
                Debug.WriteLine($"Authentication successful, token obtained. Expires at: {_tokenExpiration}");
                return result.Token;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Authentication error: {ex}");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<string> GetValidTokenAsync(AuthenticationCredentials credentials)
        {
            if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow.Add(_refreshBuffer) < _tokenExpiration)
            {
                Debug.WriteLine($"Using cached token (expires at: {_tokenExpiration})");
                return _cachedToken;
            }

            Debug.WriteLine("Token expired or about to expire, authenticating...");
            return await AuthenticateAsync(credentials);
        }
    }
} 