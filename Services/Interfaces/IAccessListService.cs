using System.Threading;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Models.AccessLists;

namespace NginxProxyManager.SDK.Services.Interfaces
{
    public interface IAccessListService
    {
        Task<AccessList[]> GetAccessListsAsync(CancellationToken cancellationToken = default);
        Task<AccessListFull> GetAccessListAsync(int accessListId, CancellationToken cancellationToken = default);
        Task<AccessList> CreateAccessListAsync(AccessListCreateRequest request, CancellationToken cancellationToken = default);
        Task<AccessList> UpdateAccessListAsync(int accessListId, AccessListUpdateRequest request, CancellationToken cancellationToken = default);
        Task DeleteAccessListAsync(int accessListId, CancellationToken cancellationToken = default);
    }
} 