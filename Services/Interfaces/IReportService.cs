using System.Threading;
using System.Threading.Tasks;
using NgninxProxyManager.SDK.Models.Reports;

namespace NgninxProxyManager.SDK.Services.Interfaces
{
    public interface IReportService
    {
        Task<Report[]> GetReportsAsync(CancellationToken cancellationToken = default);
        Task<Report> GetReportAsync(int reportId, CancellationToken cancellationToken = default);
        Task<Report> CreateReportAsync(Report report, CancellationToken cancellationToken = default);
        Task<Report> UpdateReportAsync(int reportId, Report report, CancellationToken cancellationToken = default);
        Task DeleteReportAsync(int reportId, CancellationToken cancellationToken = default);
        Task<Report> RunReportAsync(int reportId, CancellationToken cancellationToken = default);
        Task<Report[]> GetReportsByTypeAsync(string reportType, CancellationToken cancellationToken = default);
    }
} 