using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Reports;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Services
{
    /// <summary>
    /// Service for interacting with the reports API
    /// </summary>
    public class ReportsService : NPMServiceBase, IReportsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client</param>
        public ReportsService(HttpClient httpClient) : base(httpClient, "api/reports")
        {
        }

        /// <inheritdoc/>
        public async Task<OperationResult<HostStatistics>> GetHostStatisticsAsync(CancellationToken cancellationToken = default)
        {
            using var request = CreateRequest(HttpMethod.Get, "hosts");
            var result = await SendAsync<HostStatistics>(request, cancellationToken);
            return new OperationResult<HostStatistics>(result);
        }
    }
} 