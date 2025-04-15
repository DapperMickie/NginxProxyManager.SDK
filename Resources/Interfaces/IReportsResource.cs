using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Reports;

namespace NginxProxyManager.SDK.Resources.Interfaces
{
    /// <summary>
    /// Interface for the reports resource
    /// </summary>
    public interface IReportsResource
    {
        /// <summary>
        /// Gets host statistics
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The operation result containing the host statistics</returns>
        Task<OperationResult<HostStatistics>> GetHostStatisticsAsync(CancellationToken cancellationToken = default);
    }
} 