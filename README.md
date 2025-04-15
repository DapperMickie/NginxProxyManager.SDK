# Nginx Proxy Manager SDK

A .NET SDK for interacting with the Nginx Proxy Manager API.

## Features

- Client-based approach for easy access to all resources
- Fluent builder pattern for creating requests
- Comprehensive error handling with OperationResult pattern
- Automatic token management and refresh
- Full support for all Nginx Proxy Manager API endpoints

## Installation

```bash
dotnet add package NginxProxyManager.SDK
```

## Quick Start

```csharp
// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", "admin@example.com", "your-password");

// List all proxy hosts
var result = await client.ProxyHosts.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var proxy in result.Data)
    {
        Console.WriteLine($"Proxy: {proxy.DomainNames[0]} -> {proxy.ForwardHost}:{proxy.ForwardPort}");
    }
}
```

## Configuration

### Using appsettings.json

```json
{
  "NginxProxyManager": {
    "BaseUrl": "http://your-npm-instance:81",
    "TimeoutSeconds": 30,
    "Email": "admin@example.com",
    "Password": "your-password"
  }
}
```

### Using Code

```csharp
var config = new NPMConfiguration
{
    BaseUrl = "http://your-npm-instance:81",
    TimeoutSeconds = 30,
    Email = "admin@example.com",
    Password = "your-password"
};

services.AddNginxProxyManager(config);
```

### Using Environment Variables

You can also configure the SDK using environment variables:

```bash
export NGINX_PROXY_MANAGER_BASE_URL="http://your-npm-instance:81"
export NGINX_PROXY_MANAGER_EMAIL="admin@example.com"
export NGINX_PROXY_MANAGER_PASSWORD="your-password"
export NGINX_PROXY_MANAGER_TIMEOUT_SECONDS="30"
```

Then in your code:

```csharp
services.AddNginxProxyManager(); // Will use environment variables
```

## Available Resources

The SDK provides access to all Nginx Proxy Manager resources through the client:

```csharp
// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", "admin@example.com", "your-password");

// Access resources
var proxyHosts = client.ProxyHosts;
var streams = client.Streams;
var certificates = client.Certificates;
var accessLists = client.AccessLists;
var serverErrors = client.ServerErrors;
var auditLogs = client.AuditLogs;
var reports = client.Reports;
var deadHosts = client.DeadHosts;
```

## Builder Pattern

The SDK uses a fluent builder pattern for creating requests:

```csharp
// Create a proxy host using the builder pattern
var proxy = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8080)
    .WithSsl(true)
    .Build();

var result = await client.ProxyHosts.CreateAsync(proxy);
```

## Error Handling

The SDK uses the `OperationResult<T>` pattern for error handling:

```csharp
var result = await client.ProxyHosts.CreateAsync(proxy);
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

## Documentation

For detailed documentation on each resource, see:

- [Proxies](docs/proxies.md) - Manage proxy hosts
- [Streams](docs/streams.md) - Manage TCP/UDP streams
- [Server Errors](docs/server-errors.md) - View and manage server errors
- [Certificates](docs/certificates.md) - Manage SSL certificates
- [Access Lists](docs/access-lists.md) - Manage access lists
- [Audit Logs](docs/audit-logs.md) - View audit logs
- [Reports](docs/reports.md) - Generate reports
- [Dead Hosts](docs/dead-hosts.md) - Manage dead hosts

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details. 