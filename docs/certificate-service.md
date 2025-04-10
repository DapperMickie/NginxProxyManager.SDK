# Certificate Service Documentation

The Certificate Service provides functionality to manage SSL certificates in your Nginx Proxy Manager instance.

## Table of Contents
- [Overview](#overview)
- [Models](#models)
- [Methods](#methods)
- [Examples](#examples)

## Overview

The `ICertificateService` interface and its implementation `CertificateService` provide methods to create, read, update, and delete SSL certificates. It supports both Let's Encrypt certificates and custom certificates.

## Models

### CertificateModel
```csharp
public class CertificateModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Domain { get; set; }
    public string Certificate { get; set; }
    public string CertificateKey { get; set; }
    public string IntermediateCertificate { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public string Provider { get; set; }
    public bool IsWildcard { get; set; }
    public string[] Domains { get; set; }
    public string Email { get; set; }
    public bool AutoRenew { get; set; }
}
```

### CertificateCreateRequest
```csharp
public class CertificateCreateRequest
{
    public string Name { get; set; }
    public string Domain { get; set; }
    public string Certificate { get; set; }
    public string CertificateKey { get; set; }
    public string IntermediateCertificate { get; set; }
    public string Provider { get; set; }
    public bool IsWildcard { get; set; }
    public string[] Domains { get; set; }
    public string Email { get; set; }
    public bool AutoRenew { get; set; }
}
```

### CertificateUpdateRequest
```csharp
public class CertificateUpdateRequest
{
    public string Name { get; set; }
    public string Domain { get; set; }
    public string Certificate { get; set; }
    public string CertificateKey { get; set; }
    public string IntermediateCertificate { get; set; }
    public string Provider { get; set; }
    public bool IsWildcard { get; set; }
    public string[] Domains { get; set; }
    public string Email { get; set; }
    public bool AutoRenew { get; set; }
}
```

## Methods

### GetCertificatesAsync
```csharp
Task<CertificateModel[]> GetCertificatesAsync(CancellationToken cancellationToken = default)
```
Retrieves all certificates.

### GetCertificateAsync
```csharp
Task<CertificateModel> GetCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
```
Retrieves a specific certificate by ID.

### CreateCertificateAsync
```csharp
Task<CertificateModel> CreateCertificateAsync(CertificateCreateRequest request, CancellationToken cancellationToken = default)
```
Creates a new certificate.

### UpdateCertificateAsync
```csharp
Task<CertificateModel> UpdateCertificateAsync(int certificateId, CertificateUpdateRequest request, CancellationToken cancellationToken = default)
```
Updates an existing certificate.

### DeleteCertificateAsync
```csharp
Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
```
Deletes a certificate.

### RenewCertificateAsync
```csharp
Task<CertificateModel> RenewCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
```
Renews a Let's Encrypt certificate.

## Examples

### Creating a Let's Encrypt Certificate
```csharp
var request = new CertificateCreateRequest
{
    Name = "Example Certificate",
    Domain = "example.com",
    Provider = "letsencrypt",
    Email = "admin@example.com",
    AutoRenew = true
};

var certificate = await _certificateService.CreateCertificateAsync(request);
```

### Creating a Custom Certificate
```csharp
var request = new CertificateCreateRequest
{
    Name = "Custom Certificate",
    Domain = "example.com",
    Certificate = "-----BEGIN CERTIFICATE-----\n...",
    CertificateKey = "-----BEGIN PRIVATE KEY-----\n...",
    IntermediateCertificate = "-----BEGIN CERTIFICATE-----\n..."
};

var certificate = await _certificateService.CreateCertificateAsync(request);
```

### Updating a Certificate
```csharp
var request = new CertificateUpdateRequest
{
    Name = "Updated Certificate",
    Domain = "example.com",
    AutoRenew = true
};

var updatedCertificate = await _certificateService.UpdateCertificateAsync(1, request);
```

### Renewing a Certificate
```csharp
var renewedCertificate = await _certificateService.RenewCertificateAsync(1);
```

### Deleting a Certificate
```csharp
await _certificateService.DeleteCertificateAsync(1);
``` 