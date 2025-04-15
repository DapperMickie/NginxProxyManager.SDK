using System.Threading.Tasks;
using NginxProxyManager.SDK.Client;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Interface for authentication service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates with the API using the provided credentials
        /// </summary>
        /// <param name="credentials">The authentication credentials</param>
        /// <returns>The authentication token</returns>
        Task<string> AuthenticateAsync(AuthenticationCredentials credentials);

        /// <summary>
        /// Gets a valid authentication token, refreshing if necessary
        /// </summary>
        /// <param name="credentials">The authentication credentials</param>
        /// <returns>The authentication token</returns>
        Task<string> GetValidTokenAsync(AuthenticationCredentials credentials);
    }
} 