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

## Installation

```bash
dotnet add package NginxProxyManager.SDK
```

## Basic Usage

```csharp
using NginxProxyManager.SDK;

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", "admin@example.com", "your-password");

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