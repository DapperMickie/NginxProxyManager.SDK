using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.AccessLists;
using NginxProxyManager.SDK.Services.Interfaces;
using System.Collections.Generic;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Implementation of the access list builder
    /// </summary>
    public class AccessListBuilder : IAccessListBuilder
    {
        private readonly IAccessListService _accessListService;
        private readonly AccessListCreateRequest _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessListBuilder"/> class.
        /// </summary>
        /// <param name="accessListService">The access list service</param>
        public AccessListBuilder(IAccessListService accessListService)
        {
            _accessListService = accessListService;
            _request = new AccessListCreateRequest();
        }

        /// <inheritdoc />
        public IAccessListBuilder WithName(string name)
        {
            _request.Name = name;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithDescription(string description)
        {
            _request.Description = description;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithEnabled(bool enabled = true)
        {
            _request.Enabled = enabled;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithSatisfy(string satisfy)
        {
            _request.Satisfy = satisfy;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithIpAddresses(string ipAddresses)
        {
            _request.IpAddresses = ipAddresses;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithBasicAuth(string basicAuth)
        {
            _request.BasicAuth = basicAuth;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithAction(string action)
        {
            _request.Action = action;
            return this;
        }

        /// <inheritdoc />
        public IAccessListBuilder WithMeta(object meta)
        {
            if (meta is Dictionary<string, object> dict)
            {
                _request.Meta = dict;
            }
            else
            {
                _request.Meta = new Dictionary<string, object> { { "data", meta } };
            }
            return this;
        }

        /// <inheritdoc />
        public AccessListCreateRequest Build()
        {
            return _request;
        }

        /// <inheritdoc />
        public async Task<OperationResult<AccessList>> BuildAndCreateAsync()
        {
            return await _accessListService.CreateAsync(_request);
        }
    }
} 