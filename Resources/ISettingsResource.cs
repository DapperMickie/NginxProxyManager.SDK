using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Settings;

namespace NginxProxyManager.SDK.Resources
{
    public interface ISettingsResource
    {
        Task<OperationResult<Setting[]>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OperationResult<Setting>> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<OperationResult<Setting>> UpdateAsync(string id, SettingUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
