# Certificates

The Certificates resource provides a complete API for managing SSL certificates in Nginx Proxy Manager. This includes creating, retrieving, updating, and deleting certificates, as well as managing certificate renewals.

## Quick Start

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

// List all certificates
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames}");
    }
}
```

## Using Dependency Injection

```csharp
// In your Program.cs or Startup.cs
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Configure services
builder.Services.AddNginxProxyManager(options =>
{
    options.BaseUrl = "http://your-npm-instance:81";
    options.Credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");
});

// In your controller or service
public class CertificateController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public CertificateController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _client.Certificates.GetAllAsync();
        if (result.IsSuccess)
        {
            return View(result.Data);
        }
        
        return BadRequest(result.Error);
    }
}
```

## Creating Certificates

### Create a Let's Encrypt Certificate

```csharp
var result = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com", "www.example.com")
    .WithEmail("admin@example.com")
    .WithProvider("letsencrypt")
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Certificate created: {result.Data.DomainNames}");
}
```

### Create a Custom Certificate

```csharp
var result = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com")
    .WithProvider("custom")
    .WithCertificate("-----BEGIN CERTIFICATE-----...")
    .WithKey("-----BEGIN PRIVATE KEY-----...")
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Certificate created: {result.Data.DomainNames}");
}
```

## Retrieving Certificates

### Get All Certificates

```csharp
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames}");
    }
}
```

### Get Certificate by ID

```csharp
var result = await client.Certificates.GetByIdAsync(1);
if (result.IsSuccess)
{
    var cert = result.Data;
    Console.WriteLine($"Certificate: {cert.DomainNames}");
}
```

## Updating Certificates

### Update Certificate

```csharp
var result = await client.Certificates.CreateBuilder()
    .WithId(1)
    .WithDomainNames("example.com", "www.example.com", "api.example.com")
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Certificate updated: {result.Data.DomainNames}");
}
```

### Renew Certificate

```csharp
var result = await client.Certificates.RenewAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Certificate renewed successfully");
}
```

## Deleting Certificates

### Delete Certificate

```csharp
var result = await client.Certificates.DeleteAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Certificate deleted successfully");
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    // Use the certificates
    var certificates = result.Data;
}
else
{
    // Handle the error
    var error = result.Error;
    Console.WriteLine($"Error: {error.Message}");
    Console.WriteLine($"Details: {error.Details}");
}
```

## Advanced Examples

### Create and Apply Certificate

```csharp
// Create certificate
var createResult = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com")
    .WithEmail("admin@example.com")
    .WithProvider("letsencrypt")
    .Build()
    .CreateAsync();

if (createResult.IsSuccess)
{
    var cert = createResult.Data;
    
    // Apply to proxy host
    var proxyResult = await client.ProxyHosts.CreateBuilder()
        .WithDomainNames("example.com")
        .WithForwardingHost("192.168.1.100")
        .WithForwardingPort(80)
        .WithCertificateId(cert.Id)
        .Build()
        .CreateAsync();
        
    if (proxyResult.IsSuccess)
    {
        Console.WriteLine("Certificate created and applied successfully");
    }
}
```

### Monitor Certificate Expiration

```csharp
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        var daysUntilExpiration = (cert.ExpiresAt - DateTime.UtcNow).TotalDays;
        Console.WriteLine($"Certificate {cert.DomainNames} expires in {daysUntilExpiration} days");
        
        if (daysUntilExpiration < 30)
        {
            Console.WriteLine("Certificate needs renewal soon!");
        }
    }
}
```

### Batch Operations

```csharp
// Create multiple certificates
var domains = new[]
{
    "example1.com",
    "example2.com",
    "example3.com"
};

foreach (var domain in domains)
{
    var result = await client.Certificates.CreateBuilder()
        .WithDomainNames(domain)
        .WithEmail("admin@example.com")
        .WithProvider("letsencrypt")
        .Build()
        .CreateAsync();
        
    if (result.IsSuccess)
    {
        Console.WriteLine($"Certificate created for {domain}");
    }
    else
    {
        Console.WriteLine($"Failed to create certificate for {domain}: {result.Error.Message}");
    }
}
``` 