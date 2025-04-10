# Installation Guide for NginxProxyManager.SDK

This guide will help you install and use the NginxProxyManager.SDK package from NuGet.

## Installation

### Using the .NET CLI

```bash
dotnet add package NginxProxyManager.SDK
```

### Using the Package Manager Console

```powershell
Install-Package NginxProxyManager.SDK
```

### Using Visual Studio

1. Right-click on your project in Solution Explorer
2. Select "Manage NuGet Packages..."
3. Search for "NginxProxyManager.SDK"
4. Click "Install"

## Basic Usage

### Creating a Client

```csharp
using NginxProxyManager.SDK;

// Create a client with your Nginx Proxy Manager instance URL and API key
var client = new NginxProxyManagerClient("https://your-npm-instance.com", "your-api-key");
```

### Using Services

The SDK provides several services for interacting with the Nginx Proxy Manager API:

#### Proxy Service

```csharp
// Get all proxy hosts
var proxyService = client.ProxyService;
var proxyHosts = await proxyService.GetProxyHostsAsync();

// Get a specific proxy host
var proxyHost = await proxyService.GetProxyHostAsync(1);

// Create a new proxy host
var createRequest = new ProxyHostCreateRequest
{
    DomainNames = new[] { "example.com" },
    ForwardHost = "192.168.1.100",
    ForwardPort = 80,
    ForwardScheme = "http"
};
var newProxyHost = await proxyService.CreateProxyHostAsync(createRequest);
```

#### Certificate Service

```csharp
// Get all certificates
var certificateService = client.CertificateService;
var certificates = await certificateService.GetCertificatesAsync();

// Get a specific certificate
var certificate = await certificateService.GetCertificateAsync(1);

// Create a new certificate
var createRequest = new CertificateCreateRequest
{
    DomainNames = new[] { "example.com" },
    Email = "admin@example.com",
    Provider = "letsencrypt"
};
var newCertificate = await certificateService.CreateCertificateAsync(createRequest);
```

#### Dead Host Service

```csharp
// Get all dead hosts
var deadHostService = client.DeadHostService;
var deadHosts = await deadHostService.GetDeadHostsAsync();

// Get dead hosts by domain
var deadHostsByDomain = await deadHostService.GetDeadHostsByDomainAsync("example.com");
```

#### Audit Log Service

```csharp
// Get all audit logs
var auditLogService = client.AuditLogService;
var auditLogs = await auditLogService.GetAuditLogsAsync();

// Get audit logs by user
var auditLogsByUser = await auditLogService.GetAuditLogsByUserIdAsync(1);
```

## Advanced Configuration

### Dependency Injection

You can register the client with dependency injection:

```csharp
// In your Startup.cs or Program.cs
services.AddNginxProxyManager(options =>
{
    options.BaseUrl = "https://your-npm-instance.com";
    options.ApiKey = "your-api-key";
});

// In your controller or service
public class MyController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public MyController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    // Use the client
}
```

### Custom HTTP Client

You can provide a custom HTTP client:

```csharp
var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "value");

var client = new NginxProxyManagerClient(httpClient, "https://your-npm-instance.com", "your-api-key");
```

## Troubleshooting

### Common Issues

- **Connection Errors**: Make sure your Nginx Proxy Manager instance is accessible
- **Authentication Errors**: Verify your API key is correct
- **Serialization Errors**: Check that your request objects match the expected format

### Getting Help

If you encounter issues not covered here, you can:

1. Check the [GitHub repository](https://github.com/yourusername/NginxProxyManagerSdk) for updates
2. Open an issue on GitHub
3. Contact the package maintainer 