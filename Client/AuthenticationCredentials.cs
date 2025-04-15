using System;

namespace NginxProxyManager.SDK.Client
{
    /// <summary>
    /// Authentication credentials for the Nginx Proxy Manager API
    /// </summary>
    public class AuthenticationCredentials
    {
        /// <summary>
        /// Gets the authentication type
        /// </summary>
        public AuthenticationType Type { get; }

        /// <summary>
        /// Gets the identity (email/username)
        /// </summary>
        public string Identity { get; }

        /// <summary>
        /// Gets the secret (password)
        /// </summary>
        public string Secret { get; }

        /// <summary>
        /// Gets the token (for token-based authentication)
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationCredentials"/> class for token-based authentication
        /// </summary>
        /// <param name="identity">The identity (email/username)</param>
        /// <param name="secret">The secret (password)</param>
        public AuthenticationCredentials(string identity, string secret)
        {
            Type = AuthenticationType.Token;
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
            Secret = secret ?? throw new ArgumentNullException(nameof(secret));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationCredentials"/> class with an existing token
        /// </summary>
        /// <param name="token">The authentication token</param>
        public AuthenticationCredentials(string token)
        {
            Type = AuthenticationType.Token;
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        /// <summary>
        /// Creates token-based authentication credentials
        /// </summary>
        /// <param name="identity">The identity (email/username)</param>
        /// <param name="secret">The secret (password)</param>
        /// <returns>The authentication credentials</returns>
        public static AuthenticationCredentials FromCredentials(string identity, string secret)
        {
            return new AuthenticationCredentials(identity, secret);
        }

        /// <summary>
        /// Creates token-based authentication credentials with an existing token
        /// </summary>
        /// <param name="token">The authentication token</param>
        /// <returns>The authentication credentials</returns>
        public static AuthenticationCredentials FromToken(string token)
        {
            return new AuthenticationCredentials(token);
        }
    }

    /// <summary>
    /// Authentication type for the Nginx Proxy Manager API
    /// </summary>
    public enum AuthenticationType
    {
        /// <summary>
        /// Token-based authentication
        /// </summary>
        Token
    }
} 