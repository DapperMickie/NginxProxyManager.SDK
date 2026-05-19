using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Users;

namespace NginxProxyManager.SDK.Resources
{
    public interface IUsersResource
    {
        Task<OperationResult<User[]>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OperationResult<User>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<OperationResult<User>> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default);
        Task<OperationResult<User>> UpdateAsync(int id, UserUpdateRequest request, CancellationToken cancellationToken = default);
        Task<OperationResult<bool>> UpdatePasswordAsync(int id, UserPasswordUpdateRequest request, CancellationToken cancellationToken = default);
        Task<OperationResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
