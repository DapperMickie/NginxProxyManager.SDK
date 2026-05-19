using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NginxProxyManager.SDK.Common;
using NginxProxyManager.SDK.Models.Certificates;
using NginxProxyManager.SDK.Services.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Implementation of the certificate builder.
    /// </summary>
    public class CertificateBuilder : ICertificateBuilder
    {
        private readonly ICertificateService _certificateService;
        private readonly CertificateCreateRequest _request = new CertificateCreateRequest();
        private int? _id;

        public CertificateBuilder(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public ICertificateBuilder WithId(int id) { _id = id; return this; }
        public ICertificateBuilder WithProvider(string provider) { _request.Provider = provider; return this; }
        public ICertificateBuilder WithNiceName(string niceName) { _request.NiceName = niceName; return this; }
        public ICertificateBuilder WithDomainNames(params string[] domainNames) { _request.DomainNames = domainNames; return this; }
        public ICertificateBuilder WithMeta(Dictionary<string, object> meta) { _request.Meta = meta; return this; }
        public ICertificateBuilder WithCertificate(string certificate) { _request.Certificate = certificate; return this; }
        public ICertificateBuilder WithKey(string key) { _request.CertificateKey = key; return this; }
        public ICertificateBuilder WithIntermediateCertificate(string intermediateCertificate) { _request.IntermediateCertificate = intermediateCertificate; return this; }
        public CertificateCreateRequest Build() => _request;

        public async Task<OperationResult<CertificateModel>> BuildAndCreateAsync()
        {
            try { return new OperationResult<CertificateModel>(await _certificateService.CreateCertificateAsync(_request)); }
            catch (Exception ex) { return new OperationResult<CertificateModel>(ex); }
        }

        public async Task<OperationResult<CertificateModel>> BuildAndUpdateAsync()
        {
            if (!_id.HasValue) return new OperationResult<CertificateModel>(new InvalidOperationException("Certificate ID is required for update."));
            var updateRequest = new CertificateUpdateRequest
            {
                NiceName = _request.NiceName,
                DomainNames = _request.DomainNames,
                Meta = _request.Meta,
                Certificate = _request.Certificate,
                CertificateKey = _request.CertificateKey,
                IntermediateCertificate = _request.IntermediateCertificate
            };
            try { return new OperationResult<CertificateModel>(await _certificateService.UpdateCertificateAsync(_id.Value, updateRequest)); }
            catch (Exception ex) { return new OperationResult<CertificateModel>(ex); }
        }
    }
}
