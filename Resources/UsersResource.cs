using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Users;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    public class UsersResource : IUsersResource
    {
        private readonly IUserService _service;
        public UsersResource(IUserService service) => _service = service;
        public Task<OperationResult<User[]>> GetAllAsync(CancellationToken cancellationToken = default) => _service.GetAllAsync(cancellationToken);
        public Task<OperationResult<User>> GetByIdAsync(int id, CancellationToken cancellationToken = default) => _service.GetByIdAsync(id, cancellationToken);
        public Task<OperationResult<User>> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default) => _service.CreateAsync(request, cancellationToken);
        public Task<OperationResult<User>> UpdateAsync(int id, UserUpdateRequest request, CancellationToken cancellationToken = default) => _service.UpdateAsync(id, request, cancellationToken);
        public Task<OperationResult<bool>> UpdatePasswordAsync(int id, UserPasswordUpdateRequest request, CancellationToken cancellationToken = default) => _service.UpdatePasswordAsync(id, request, cancellationToken);
        public Task<OperationResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default) => _service.DeleteAsync(id, cancellationToken);
    }
}
