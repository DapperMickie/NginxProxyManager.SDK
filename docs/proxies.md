# Proxies

The Proxies resource provides a complete API for managing proxy hosts in Nginx Proxy Manager. This includes creating, reading, updating, and deleting proxy hosts, as well as managing their SSL certificates and access lists.

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

## Creating a Proxy Host

### Basic Proxy Host

```csharp
// Create a basic proxy host
var proxy = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8080)
    .Build();

var result = await client.ProxyHosts.CreateAsync(proxy);
if (result.IsSuccess)
{
    Console.WriteLine($"Created proxy host with ID: {result.Data.Id}");
}
```

### Proxy Host with SSL

```csharp
// Create a proxy host with SSL
var proxy = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("secure.example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8443)
    .WithSsl(true)
    .WithHttp2(true)
    .WithHsts(true)
    .WithHstsIncludeSubdomains(true)
    .WithHstsPreload(true)
    .WithHstsMaxAge(31536000)
    .Build();

var result = await client.ProxyHosts.CreateAsync(proxy);
if (result.IsSuccess)
{
    Console.WriteLine($"Created secure proxy host with ID: {result.Data.Id}");
}
```

### Proxy Host with Access List

```csharp
// Create a proxy host with access list
var proxy = await client.ProxyHosts.CreateBuilder()
    .WithDomainNames("restricted.example.com")
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(8080)
    .WithAccessListId(1) // ID of an existing access list
    .Build();

var result = await client.ProxyHosts.CreateAsync(proxy);
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
// Get the proxy host
var getResult = await client.ProxyHosts.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var proxy = getResult.Data;
    
    // Update the proxy host
    proxy.ForwardPort = 9090;
    proxy.Enabled = false;
    
    var updateResult = await client.ProxyHosts.UpdateAsync(proxy);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Proxy host updated successfully");
    }
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
// Get the proxy host
var getResult = await client.ProxyHosts.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var proxy = getResult.Data;
    
    // Assign an SSL certificate
    proxy.Ssl = true;
    proxy.CertificateId = 1; // ID of an existing certificate
    
    var updateResult = await client.ProxyHosts.UpdateAsync(proxy);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("SSL certificate assigned successfully");
    }
}
```

### Remove an SSL Certificate

```csharp
// Get the proxy host
var getResult = await client.ProxyHosts.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var proxy = getResult.Data;
    
    // Remove the SSL certificate
    proxy.Ssl = false;
    proxy.CertificateId = null;
    
    var updateResult = await client.ProxyHosts.UpdateAsync(proxy);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("SSL certificate removed successfully");
    }
}
```

## Managing Access Lists

### Assign an Access List

```csharp
// Get the proxy host
var getResult = await client.ProxyHosts.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var proxy = getResult.Data;
    
    // Assign an access list
    proxy.AccessListId = 1; // ID of an existing access list
    
    var updateResult = await client.ProxyHosts.UpdateAsync(proxy);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Access list assigned successfully");
    }
}
```

### Remove an Access List

```csharp
// Get the proxy host
var getResult = await client.ProxyHosts.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var proxy = getResult.Data;
    
    // Remove the access list
    proxy.AccessListId = null;
    
    var updateResult = await client.ProxyHosts.UpdateAsync(proxy);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Access list removed successfully");
    }
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
var proxy = await client.ProxyHosts.CreateBuilder()
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
    .Build();

var result = await client.ProxyHosts.CreateAsync(proxy);
if (result.IsSuccess)
{
    Console.WriteLine($"Created proxy host with ID: {result.Data.Id}");
}
```

### Batch Operations

```csharp
// Create multiple proxy hosts
var proxies = new[]
{
    await client.ProxyHosts.CreateBuilder()
        .WithDomainNames("site1.example.com")
        .WithForwardHost("192.168.1.101")
        .WithForwardPort(8080)
        .Build(),
    await client.ProxyHosts.CreateBuilder()
        .WithDomainNames("site2.example.com")
        .WithForwardHost("192.168.1.102")
        .WithForwardPort(8080)
        .Build()
};

foreach (var proxy in proxies)
{
    var result = await client.ProxyHosts.CreateAsync(proxy);
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