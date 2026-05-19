using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Certificates;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Resource for managing certificates.
    /// </summary>
    public class CertificatesResource : ICertificatesResource
    {
        private readonly ICertificateService _certificateService;

        public CertificatesResource(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public ICertificateBuilder CreateBuilder() => new CertificateBuilder(_certificateService);

        public async Task<OperationResult<CertificateModel>> GetAsync(int id) => await GetByIdAsync(id);

        public async Task<OperationResult<CertificateModel>> GetByIdAsync(int id)
        {
            try { return new OperationResult<CertificateModel>(await _certificateService.GetCertificateAsync(id)); }
            catch (Exception ex) { return new OperationResult<CertificateModel>(ex); }
        }

        public async Task<OperationResult<IEnumerable<CertificateModel>>> GetAllAsync()
        {
            try { return new OperationResult<IEnumerable<CertificateModel>>(await _certificateService.GetCertificatesAsync()); }
            catch (Exception ex) { return new OperationResult<IEnumerable<CertificateModel>>(ex); }
        }

        public Task<OperationResult<IEnumerable<CertificateModel>>> GetPageAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CertificateModel>> CreateAsync(CertificateModel resource)
        {
            throw new NotImplementedException("Use CreateAsync(CertificateCreateRequest) instead.");
        }

        public async Task<OperationResult<CertificateModel>> CreateAsync(CertificateCreateRequest certificate)
        {
            try { return new OperationResult<CertificateModel>(await _certificateService.CreateCertificateAsync(certificate)); }
            catch (Exception ex) { return new OperationResult<CertificateModel>(ex); }
        }

        public Task<OperationResult<CertificateModel>> UpdateAsync(int id, CertificateModel resource)
        {
            throw new NotImplementedException("Use UpdateAsync(int, CertificateUpdateRequest) instead.");
        }

        public async Task<OperationResult<CertificateModel>> UpdateAsync(int id, CertificateUpdateRequest certificate)
        {
            try { return new OperationResult<CertificateModel>(await _certificateService.UpdateCertificateAsync(id, certificate)); }
            catch (Exception ex) { return new OperationResult<CertificateModel>(ex); }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            try { await _certificateService.DeleteCertificateAsync(id); return new OperationResult<bool>(true); }
            catch (Exception ex) { return new OperationResult<bool>(ex); }
        }

        public async Task<OperationResult<CertificateModel>> RenewAsync(int id)
        {
            try { return new OperationResult<CertificateModel>(await _certificateService.RenewCertificateAsync(id)); }
            catch (Exception ex) { return new OperationResult<CertificateModel>(ex); }
        }
    }
}
