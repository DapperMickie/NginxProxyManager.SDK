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
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client with your Nginx Proxy Manager instance URL and credentials
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);
```

### Using Resources

The SDK provides several resources for interacting with the Nginx Proxy Manager API:

#### Proxy Hosts

```csharp
// Get all proxy hosts
var result = await client.ProxyHosts.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var host in result.Data)
    {
        Console.WriteLine($"Proxy Host: {host.DomainNames[0]} -> {host.ForwardHost}:{host.ForwardPort}");
    }
}

// Create a new proxy host using the builder pattern
var proxyHost = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(80)
    .WithForwardScheme("http")
    .Build();

var createResult = await client.ProxyHosts.CreateAsync(proxyHost);
if (createResult.IsSuccess)
{
    Console.WriteLine($"Created proxy host with ID: {createResult.Data.Id}");
}
```

#### Certificates

```csharp
// Get all certificates
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames[0]} (Expires: {cert.ExpiresOn})");
    }
}

// Create a new certificate using the builder pattern
var certificate = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com")
    .WithEmail("admin@example.com")
    .WithProvider("letsencrypt")
    .Build();

var createResult = await client.Certificates.CreateAsync(certificate);
if (createResult.IsSuccess)
{
    Console.WriteLine($"Created certificate with ID: {createResult.Data.Id}");
}
```

#### Access Lists

```csharp
// Get all access lists
var result = await client.AccessLists.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var list in result.Data)
    {
        Console.WriteLine($"Access List: {list.Name} ({list.Rules.Count} rules)");
    }
}

// Create a new access list using the builder pattern
var accessList = await client.AccessLists.CreateBuilder()
    .WithName("Basic Access List")
    .WithSatisfy("any")
    .WithRules(new[]
    {
        new AccessListRule
        {
            Name = "Allow Local Network",
            Rule = "allow 192.168.1.0/24"
        }
    })
    .Build();

var createResult = await client.AccessLists.CreateAsync(accessList);
if (createResult.IsSuccess)
{
    Console.WriteLine($"Created access list with ID: {createResult.Data.Id}");
}
```

#### Streams

```csharp
// Get all streams
var result = await client.Streams.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var stream in result.Data)
    {
        Console.WriteLine($"Stream: {stream.IncomingPort} -> {stream.ForwardingHost}:{stream.ForwardingPort}");
    }
}

// Create a new stream using the builder pattern
var stream = await client.Streams.CreateBuilder()
    .WithIncomingPort(8080)
    .WithForwardingHost("192.168.1.100")
    .WithForwardingPort(80)
    .WithTcpForwarding(true)
    .Build();

var createResult = await client.Streams.CreateAsync(stream);
if (createResult.IsSuccess)
{
    Console.WriteLine($"Created stream with ID: {createResult.Data.Id}");
}
```

#### Audit Logs

```csharp
// Get recent audit logs
var result = await client.AuditLogs.GetRecentAsync();
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.Action} by {log.User} at {log.Timestamp}");
    }
}
```

#### Server Errors

```csharp
// Get all server errors
var result = await client.ServerErrors.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var error in result.Data)
    {
        Console.WriteLine($"Server Error: {error.Message} for host {error.HostId}");
    }
}
```

## Advanced Configuration

### Dependency Injection

You can register the client with dependency injection:

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
public class MyController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public MyController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _client.ProxyHosts.GetAllAsync();
        if (result.IsSuccess)
        {
            return View(result.Data);
        }
        
        return BadRequest(result.Error);
    }
}
```

### Custom HTTP Client

You can provide a custom HTTP client:

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "value");

var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");
var client = new NginxProxyManagerClient(httpClient, "http://your-npm-instance:81", credentials);
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.ProxyHosts.CreateAsync(proxyHost);
if (result.IsSuccess)
{
    // Use the created item
    var item = result.Data;
}
else
{
    // Handle the error
    var error = result.Error;
    Console.WriteLine($"Error: {error.Message}");
    Console.WriteLine($"Details: {error.Details}");
}
```

## Troubleshooting

### Common Issues

- **Connection Errors**: Make sure your Nginx Proxy Manager instance is accessible
- **Authentication Errors**: Verify your credentials are correct
- **Serialization Errors**: Check that your request objects match the expected format

### Getting Help

If you encounter issues not covered here, you can:

1. Check the [GitHub repository](https://github.com/yourusername/NginxProxyManagerSdk) for updates
2. Open an issue on GitHub
3. Contact the package maintainer 