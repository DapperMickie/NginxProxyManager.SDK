# Dead Hosts

The Dead Hosts resource provides functionality for managing and monitoring dead hosts in Nginx Proxy Manager. Dead hosts are proxy hosts that are currently unreachable or experiencing issues.

## Quick Start

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

// Get all dead hosts
var result = await client.DeadHosts.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var host in result.Data)
    {
        Console.WriteLine($"Dead Host: {host.DomainNames[0]} -> {host.ForwardHost}:{host.ForwardPort}");
        Console.WriteLine($"Last Check: {host.LastCheck}");
        Console.WriteLine($"Status: {host.Status}");
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
public class DeadHostController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public DeadHostController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _client.DeadHosts.GetAllAsync();
        if (result.IsSuccess)
        {
            return View(result.Data);
        }
        
        return BadRequest(result.Error);
    }
}
```

## Managing Dead Hosts

### Get All Dead Hosts

```csharp
var result = await client.DeadHosts.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var host in result.Data)
    {
        Console.WriteLine($"Dead Host: {host.DomainNames[0]}");
        Console.WriteLine($"  Forward Host: {host.ForwardHost}:{host.ForwardPort}");
        Console.WriteLine($"  Last Check: {host.LastCheck}");
        Console.WriteLine($"  Status: {host.Status}");
        Console.WriteLine($"  Error: {host.Error}");
    }
}
```

### Get Dead Host by ID

```csharp
var result = await client.DeadHosts.GetByIdAsync(1);
if (result.IsSuccess)
{
    var host = result.Data;
    Console.WriteLine($"Dead Host: {host.DomainNames[0]}");
    Console.WriteLine($"  Forward Host: {host.ForwardHost}:{host.ForwardPort}");
    Console.WriteLine($"  Last Check: {host.LastCheck}");
    Console.WriteLine($"  Status: {host.Status}");
    Console.WriteLine($"  Error: {host.Error}");
}
```

### Get Dead Hosts by Domain

```csharp
var result = await client.DeadHosts.GetByDomainAsync("example.com");
if (result.IsSuccess)
{
    foreach (var host in result.Data)
    {
        Console.WriteLine($"Dead Host: {host.DomainNames[0]}");
        Console.WriteLine($"  Forward Host: {host.ForwardHost}:{host.ForwardPort}");
        Console.WriteLine($"  Last Check: {host.LastCheck}");
        Console.WriteLine($"  Status: {host.Status}");
        Console.WriteLine($"  Error: {host.Error}");
    }
}
```

### Delete Dead Host

```csharp
var result = await client.DeadHosts.DeleteAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Dead host deleted successfully");
}
```

### Delete Dead Hosts by Domain

```csharp
var result = await client.DeadHosts.DeleteByDomainAsync("example.com");
if (result.IsSuccess)
{
    Console.WriteLine("Dead hosts deleted successfully");
}
```

## Monitoring Dead Hosts

### Check Dead Host Status

```csharp
var result = await client.DeadHosts.CheckStatusAsync(1);
if (result.IsSuccess)
{
    var status = result.Data;
    Console.WriteLine($"Status: {status.IsAlive}");
    Console.WriteLine($"Last Check: {status.LastCheck}");
    Console.WriteLine($"Error: {status.Error}");
}
```

### Check All Dead Hosts Status

```csharp
var result = await client.DeadHosts.CheckAllStatusAsync();
if (result.IsSuccess)
{
    foreach (var status in result.Data)
    {
        Console.WriteLine($"Host ID: {status.HostId}");
        Console.WriteLine($"Status: {status.IsAlive}");
        Console.WriteLine($"Last Check: {status.LastCheck}");
        Console.WriteLine($"Error: {status.Error}");
    }
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.DeadHosts.GetAllAsync();
if (result.IsSuccess)
{
    // Use the dead hosts
    var hosts = result.Data;
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

### Monitor Dead Hosts Continuously

```csharp
while (true)
{
    var result = await client.DeadHosts.GetAllAsync();
    if (result.IsSuccess)
    {
        var hosts = result.Data;
        foreach (var host in hosts)
        {
            Console.WriteLine($"[{DateTime.Now}] Dead Host: {host.DomainNames[0]}");
            Console.WriteLine($"  Forward Host: {host.ForwardHost}:{host.ForwardPort}");
            Console.WriteLine($"  Last Check: {host.LastCheck}");
            Console.WriteLine($"  Status: {host.Status}");
            Console.WriteLine($"  Error: {host.Error}");
        }
    }
    
    await Task.Delay(TimeSpan.FromMinutes(5));
}
```

### Export Dead Hosts to CSV

```csharp
var result = await client.DeadHosts.GetAllAsync();
if (result.IsSuccess)
{
    var hosts = result.Data;
    var csv = new StringBuilder();
    
    // Add headers
    csv.AppendLine("Domain,Forward Host,Forward Port,Last Check,Status,Error");
    
    // Add data
    foreach (var host in hosts)
    {
        csv.AppendLine($"{host.DomainNames[0]},{host.ForwardHost},{host.ForwardPort},{host.LastCheck},{host.Status},{host.Error}");
    }
    
    // Write to file
    await File.WriteAllTextAsync("dead_hosts.csv", csv.ToString());
    Console.WriteLine("Dead hosts exported to dead_hosts.csv");
}
```

### Batch Operations

```csharp
// Delete dead hosts for multiple domains
var domains = new[] { "example1.com", "example2.com", "example3.com" };

foreach (var domain in domains)
{
    var result = await client.DeadHosts.DeleteByDomainAsync(domain);
    if (result.IsSuccess)
    {
        Console.WriteLine($"Deleted dead hosts for domain: {domain}");
    }
    else
    {
        Console.WriteLine($"Failed to delete dead hosts for domain: {domain}");
        Console.WriteLine($"Error: {result.Error.Message}");
    }
}
``` 