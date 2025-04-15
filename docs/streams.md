# Streams

The Streams resource provides a complete API for managing TCP/UDP streams in Nginx Proxy Manager. This includes creating, reading, updating, and deleting streams.

## Quick Start

```csharp
// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", "admin@example.com", "your-password");

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

## Creating a Stream

### Basic TCP Stream

```csharp
// Create a basic TCP stream
var stream = await client.Streams.CreateBuilder()
    .WithIncomingPort(3306)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(3306)
    .WithTcpForwarding(true)
    .Build();

var result = await client.Streams.CreateAsync(stream);
if (result.IsSuccess)
{
    Console.WriteLine($"Created TCP stream with ID: {result.Data.Id}");
}
```

### UDP Stream

```csharp
// Create a UDP stream
var stream = await client.Streams.CreateBuilder()
    .WithIncomingPort(53)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(53)
    .WithUdpForwarding(true)
    .Build();

var result = await client.Streams.CreateAsync(stream);
if (result.IsSuccess)
{
    Console.WriteLine($"Created UDP stream with ID: {result.Data.Id}");
}
```

### TCP and UDP Stream

```csharp
// Create a TCP and UDP stream
var stream = await client.Streams.CreateBuilder()
    .WithIncomingPort(53)
    .WithForwardHost("192.168.1.100")
    .WithForwardPort(53)
    .WithTcpForwarding(true)
    .WithUdpForwarding(true)
    .Build();

var result = await client.Streams.CreateAsync(stream);
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
// Get the stream
var getResult = await client.Streams.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var stream = getResult.Data;
    
    // Update the stream
    stream.ForwardPort = 3307;
    stream.Enabled = false;
    
    var updateResult = await client.Streams.UpdateAsync(stream);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Stream updated successfully");
    }
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
var stream = await client.Streams.CreateBuilder()
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
    .Build();

var result = await client.Streams.CreateAsync(stream);
if (result.IsSuccess)
{
    Console.WriteLine($"Created stream with ID: {result.Data.Id}");
}
```

### Batch Operations

```csharp
// Create multiple streams
var streams = new[]
{
    await client.Streams.CreateBuilder()
        .WithIncomingPort(3306)
        .WithForwardHost("192.168.1.101")
        .WithForwardPort(3306)
        .WithTcpForwarding(true)
        .Build(),
    await client.Streams.CreateBuilder()
        .WithIncomingPort(53)
        .WithForwardHost("192.168.1.102")
        .WithForwardPort(53)
        .WithUdpForwarding(true)
        .Build()
};

foreach (var stream in streams)
{
    var result = await client.Streams.CreateAsync(stream);
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