# Streams

The Streams resource provides a complete API for managing TCP/UDP streams in Nginx Proxy Manager. This includes creating, reading, updating, and deleting streams.

## Quick Start

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

// List all streams
var result = await client.Streams.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var stream in result.Data)
    {
        Console.WriteLine($"Stream: {stream.IncomingPort} -> {stream.ForwardHost}:{stream.ForwardPort}");
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
public class StreamController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public StreamController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _client.Streams.GetAllAsync();
        if (result.IsSuccess)
        {
            return View(result.Data);
        }
        
        return BadRequest(result.Error);
    }
}
```

## Creating a Stream

### Basic TCP Stream

```csharp
// Create a basic TCP stream
var result = await client.Streams.CreateBuilder()
    .WithIncomingPort(3306)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(3306)
    .WithTcpForwarding(true)
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created TCP stream with ID: {result.Data.Id}");
}
```

### UDP Stream

```csharp
// Create a UDP stream
var result = await client.Streams.CreateBuilder()
    .WithIncomingPort(53)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(53)
    .WithUdpForwarding(true)
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created UDP stream with ID: {result.Data.Id}");
}
```

### TCP and UDP Stream

```csharp
// Create a TCP and UDP stream
var result = await client.Streams.CreateBuilder()
    .WithIncomingPort(53)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(53)
    .WithTcpForwarding(true)
    .WithUdpForwarding(true)
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created TCP/UDP stream with ID: {result.Data.Id}");
}
```

## Retrieving Streams

### Get All Streams

```csharp
var result = await client.Streams.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var stream in result.Data)
    {
        Console.WriteLine($"Stream: {stream.IncomingPort} -> {stream.ForwardHost}:{stream.ForwardPort}");
    }
}
```

### Get Stream by ID

```csharp
var result = await client.Streams.GetByIdAsync(1);
if (result.IsSuccess)
{
    var stream = result.Data;
    Console.WriteLine($"Stream: {stream.IncomingPort} -> {stream.ForwardHost}:{stream.ForwardPort}");
}
```

## Updating a Stream

```csharp
// Update the stream
var result = await client.Streams.CreateBuilder()
    .WithId(1)
    .WithForwardPort(3307)
    .WithEnabled(false)
    .Build()
    .UpdateAsync();

if (result.IsSuccess)
{
    Console.WriteLine("Stream updated successfully");
}
```

## Deleting a Stream

```csharp
var result = await client.Streams.DeleteAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Stream deleted successfully");
}
```

## Enabling and Disabling Streams

### Enable a Stream

```csharp
var result = await client.Streams.EnableAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Stream enabled successfully");
}
```

### Disable a Stream

```csharp
var result = await client.Streams.DisableAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Stream disabled successfully");
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.Streams.CreateAsync(stream);
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

### Create a Stream with All Options

```csharp
var result = await client.Streams.CreateBuilder()
    .WithIncomingPort(3306)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(3306)
    .WithTcpForwarding(true)
    .WithUdpForwarding(false)
    .WithEnabled(true)
    .WithCertificateId(1)
    .WithMeta(new Dictionary<string, string>
    {
        { "description", "MySQL database stream" },
        { "environment", "production" }
    })
    .Build()
    .CreateAsync();

if (result.IsSuccess)
{
    Console.WriteLine($"Created stream with ID: {result.Data.Id}");
}
```

### Batch Operations

```csharp
// Create multiple streams
var ports = new[]
{
    3306,
    53
};

foreach (var port in ports)
{
    var result = await client.Streams.CreateBuilder()
        .WithIncomingPort(port)
        .WithForwardHost("192.168.1.100")
        .WithForwardPort(port)
        .WithTcpForwarding(true)
        .Build()
        .CreateAsync();
        
    if (result.IsSuccess)
    {
        Console.WriteLine($"Created stream with ID: {result.Data.Id}");
    }
    else
    {
        Console.WriteLine($"Failed to create stream: {result.Error.Message}");
    }
}
``` 