using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Redirections;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Threading;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for managing redirections
    /// </summary>
    public class RedirectionsResource : IRedirectionsResource
    {
        private readonly IRedirectionService _redirectionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectionsResource"/> class.
        /// </summary>
        /// <param name="redirectionService">The redirection service</param>
        public RedirectionsResource(IRedirectionService redirectionService)
        {
            _redirectionService = redirectionService;
        }

        /// <inheritdoc />
        public Task<OperationResult<bool>> DeleteAsync(int id)
        {
            return _redirectionService.DeleteAsync(id);
        }

        /// <inheritdoc />
        public Task<OperationResult<bool>> EnableAsync(int id)
        {
            return _redirectionService.EnableRedirectionAsync(id);
        }

        /// <inheritdoc />
        public Task<OperationResult<bool>> DisableAsync(int id)
        {
            return _redirectionService.DisableRedirectionAsync(id);
        }

        /// <inheritdoc />
        public Task<OperationResult<Redirection>> GetByIdAsync(int id)
        {
            return _redirectionService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public Task<OperationResult<Redirection>> CreateAsync(RedirectionCreateRequest resource)
        {
            return _redirectionService.CreateAsync(resource);
        }

        /// <inheritdoc />
        public Task<OperationResult<Redirection>> UpdateAsync(int id, RedirectionUpdateRequest resource)
        {
            return _redirectionService.UpdateAsync(id, resource);
        }

        /// <inheritdoc />
        public IRedirectionBuilder CreateBuilder()
        {
            return new RedirectionBuilder(_redirectionService);
        }

        /// <inheritdoc />
        public Task<OperationResult<Redirection>> GetAsync(int id)
        {
            return _redirectionService.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public Task<OperationResult<IEnumerable<Redirection>>> GetAllAsync()
        {
            return _redirectionService.GetAllAsync();
        }

        /// <inheritdoc />
        public Task<OperationResult<IEnumerable<Redirection>>> GetPageAsync(int page, int pageSize)
        {
            return _redirectionService.GetPageAsync(page, pageSize);
        }

        /// <inheritdoc />
        public Task<OperationResult<Redirection>> CreateAsync(Redirection resource)
        {
            // This method is not applicable for Redirections as they require a CreateRequest
            throw new System.NotImplementedException("Use CreateAsync(RedirectionCreateRequest) instead");
        }

        /// <inheritdoc />
        public Task<OperationResult<Redirection>> UpdateAsync(int id, Redirection resource)
        {
            // This method is not applicable for Redirections as they require an UpdateRequest
            throw new System.NotImplementedException("Use UpdateAsync(int, RedirectionUpdateRequest) instead");
        }
    }
}