using System;
using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Reports;
using NginxProxyManager.SDK.Resources.Interfaces;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for interacting with reports
    /// </summary>
    public class ReportsResource : IReportsResource
    {
        private readonly IReportsService _reportsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsResource"/> class.
        /// </summary>
        /// <param name="reportsService">The reports service</param>
        public ReportsResource(IReportsService reportsService)
        {
            _reportsService = reportsService ?? throw new ArgumentNullException(nameof(reportsService));
        }

        /// <inheritdoc/>
        public Task<OperationResult<HostStatistics>> GetHostStatisticsAsync(CancellationToken cancellationToken = default)
        {
            return _reportsService.GetHostStatisticsAsync(cancellationToken);
        }
    }
} 