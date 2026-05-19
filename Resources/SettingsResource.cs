using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Settings;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    public class SettingsResource : ISettingsResource
    {
        private readonly ISettingsService _service;
        public SettingsResource(ISettingsService service) => _service = service;
        public Task<OperationResult<Setting[]>> GetAllAsync(CancellationToken cancellationToken = default) => _service.GetAllAsync(cancellationToken);
        public Task<OperationResult<Setting>> GetByIdAsync(string id, CancellationToken cancellationToken = default) => _service.GetByIdAsync(id, cancellationToken);
        public Task<OperationResult<Setting>> UpdateAsync(string id, SettingUpdateRequest request, CancellationToken cancellationToken = default) => _service.UpdateAsync(id, request, cancellationToken);
    }
}
