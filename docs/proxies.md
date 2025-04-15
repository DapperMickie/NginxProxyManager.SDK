# Proxies

The Proxies resource provides a complete API for managing proxy hosts in Nginx Proxy Manager. This includes creating, reading, updating, and deleting proxy hosts, as well as managing their SSL certificates and access lists.

## Quick Start

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

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
public class ProxyController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public ProxyController(INginxProxyManagerClient client)
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

## Creating a Proxy Host

### Basic Proxy Host

```csharp
// Create a basic proxy host
var result = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8080)
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created proxy host with ID: {result.Data.Id}");
}
```

### Proxy Host with SSL

```csharp
// Create a proxy host with SSL
var result = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("secure.example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8443)
    .WithSsl(true)
    .WithHttp2(true)
    .WithHsts(true)
    .WithHstsIncludeSubdomains(true)
    .WithHstsPreload(true)
    .WithHstsMaxAge(31536000)
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created secure proxy host with ID: {result.Data.Id}");
}
```

### Proxy Host with Access List

```csharp
// Create a proxy host with access list
var result = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("restricted.example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8080)
    .WithAccessListId(1) // ID of an existing access list
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created restricted proxy host with ID: {result.Data.Id}");
}
```

## Retrieving Proxy Hosts

### Get All Proxy Hosts

```csharp
var result = await client.ProxyHosts.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var proxy in result.Data)
    {
        Console.WriteLine($"Proxy: {proxy.DomainNames[0]} -> {proxy.ForwardHost}:{proxy.ForwardPort}");
    }
}
```

### Get Proxy Host by ID

```csharp
var result = await client.ProxyHosts.GetByIdAsync(1);
if (result.IsSuccess)
{
    var proxy = result.Data;
    Console.WriteLine($"Proxy: {proxy.DomainNames[0]} -> {proxy.ForwardHost}:{proxy.ForwardPort}");
}
```

### Get Proxy Hosts by Domain

```csharp
var result = await client.ProxyHosts.GetByDomainAsync("example.com");
if (result.IsSuccess)
{
    foreach (var proxy in result.Data)
    {
        Console.WriteLine($"Proxy: {proxy.DomainNames[0]} -> {proxy.ForwardHost}:{proxy.ForwardPort}");
    }
}
```

## Updating a Proxy Host

```csharp
// Update the proxy host
var result = await client.ProxyHosts.CreateBuilder()
    .WithId(1)
    .WithForwardPort(9090)
    .WithEnabled(false)
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine("Proxy host updated successfully");
}
```

## Deleting a Proxy Host

```csharp
var result = await client.ProxyHosts.DeleteAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Proxy host deleted successfully");
}
```

## Managing SSL Certificates

### Assign an SSL Certificate

```csharp
// Assign an SSL certificate
var result = await client.ProxyHosts.CreateBuilder()
    .WithId(1)
    .WithSsl(true)
    .WithCertificateId(1) // ID of an existing certificate
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine("SSL certificate assigned successfully");
}
```

### Remove an SSL Certificate

```csharp
// Remove the SSL certificate
var result = await client.ProxyHosts.CreateBuilder()
    .WithId(1)
    .WithSsl(false)
    .WithCertificateId(null)
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine("SSL certificate removed successfully");
}
```

## Managing Access Lists

### Assign an Access List

```csharp
// Assign an access list
var result = await client.ProxyHosts.CreateBuilder()
    .WithId(1)
    .WithAccessListId(1) // ID of an existing access list
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine("Access list assigned successfully");
}
```

### Remove an Access List

```csharp
// Remove the access list
var result = await client.ProxyHosts.CreateBuilder()
    .WithId(1)
    .WithAccessListId(null)
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine("Access list removed successfully");
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

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

## Advanced Examples

### Create a Proxy Host with All Options

```csharp
var result = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("example.com", "www.example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8080)
    .WithSsl(true)
    .WithHttp2(true)
    .WithHsts(true)
    .WithHstsIncludeSubdomains(true)
    .WithHstsPreload(true)
    .WithHstsMaxAge(31536000)
    .WithAccessListId(1)
    .WithCertificateId(1)
    .WithBlockCommonExploits(true)
    .WithWebsocketSupport(true)
    .WithHttp3Support(true)
    .WithForceSsl(true)
    .WithEnabled(true)
    .WithMeta(new Dictionary<string, string>
    {
        { "description", "Example proxy host" },
        { "environment", "production" }
    })
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created proxy host with ID: {result.Data.Id}");
}
```

### Batch Operations

```csharp
// Create multiple proxy hosts
var domains = new[]
{
    "site1.example.com",
    "site2.example.com"
};

foreach (var domain in domains)
{
    var result = await client.ProxyHosts.CreateBuilder()
        .WithDomainNames(domain)
        .WithForwardHost("192.168.1.100")
        .WithForwardPort(8080)
        .Build()
        .CreateAsync();
        
    if (result.IsSuccess)
    {
        Console.WriteLine($"Created proxy host with ID: {result.Data.Id}");
    }
    else
    {
        Console.WriteLine($"Failed to create proxy host: {result.Error.Message}");
    }
}
``` 