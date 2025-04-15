# NginxProxyManager.SDK Documentation

Welcome to the NginxProxyManager.SDK documentation. This SDK provides a .NET client for interacting with the Nginx Proxy Manager API.

## Getting Started

To use this SDK, you need to:

1. Install the NuGet package
2. Configure the client with your Nginx Proxy Manager instance URL and credentials
3. Use the resources to interact with the API

## Available Resources

The SDK provides the following resources:

- [Proxy Hosts](proxy-hosts.md) - Manage proxy hosts
- [Certificates](certificates.md) - Manage SSL certificates
- [Access Lists](access-lists.md) - Manage access lists
- [Streams](streams.md) - Manage TCP/UDP streams
- [Audit Logs](audit-logs.md) - Access audit logs
- [Server Errors](server-errors.md) - Handle server errors
- [Reports](reports.md) - Generate reports
- [Dead Hosts](dead-hosts.md) - Manage dead hosts

## Installation

```bash
dotnet add package NginxProxyManager.SDK
```

## Basic Usage

### Direct Client Instantiation

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

// Use resources
var result = await client.ProxyHosts.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var host in result.Data)
    {
        Console.WriteLine($"Proxy Host: {host.DomainNames[0]} -> {host.ForwardHost}:{host.ForwardPort}");
    }
}
```

### Using Dependency Injection

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

## Features

- **Client-Based Approach**: Access all resources through a single client instance
- **Fluent Builder Pattern**: Create resources using a fluent builder pattern
- **Operation Result Pattern**: Consistent error handling across all operations
- **Async/Await Support**: All operations are asynchronous
- **Dependency Injection**: Easy integration with .NET dependency injection
- **Comprehensive Documentation**: Detailed documentation for all resources

## Quick Links

- [Installation Guide](installation-guide.md)
- [Configuration](configuration.md)
- [Error Handling](error-handling.md)
- [Best Practices](best-practices.md)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details. 