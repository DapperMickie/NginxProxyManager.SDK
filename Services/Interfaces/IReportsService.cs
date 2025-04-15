using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Reports;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    /// <summary>
    /// Interface for the reports service
    /// </summary>
    public interface IReportsService
    {
        /// <summary>
        /// Gets host statistics
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the host statistics</returns>
        Task<OperationResult<HostStatistics>> GetHostStatisticsAsync(CancellationToken cancellationToken = default);
    }
} 