# Server Error Service Documentation

The Server Error Service provides functionality to monitor and manage server errors in your Nginx Proxy Manager instance.

## Table of Contents
- [Overview](#overview)
- [Models](#models)
- [Methods](#methods)
- [Examples](#examples)

## Overview

The `IServerErrorService` interface and its implementation `ServerErrorService` provide methods to retrieve and manage server errors. This service is useful for monitoring and debugging issues with your proxy hosts.

## Models

### ServerError
```csharp
public class ServerError
{
    public int Id { get; set; }
    public int HostId { get; set; }
    public string HostName { get; set; }
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public string RequestUrl { get; set; }
    public string RequestMethod { get; set; }
    public string RequestHeaders { get; set; }
    public string RequestBody { get; set; }
    public string ResponseHeaders { get; set; }
    public string ResponseBody { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

## Methods

### GetServerErrorsAsync
```csharp
Task<ServerError[]> GetServerErrorsAsync(CancellationToken cancellationToken = default)
```
Retrieves all server errors.

### GetServerErrorAsync
```csharp
Task<ServerError> GetServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default)
```
Retrieves a specific server error by ID.

### GetServerErrorsByHostIdAsync
```csharp
Task<ServerError[]> GetServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
```
Retrieves server errors for a specific host.

### DeleteServerErrorAsync
```csharp
Task DeleteServerErrorAsync(int serverErrorId, CancellationToken cancellationToken = default)
```
Deletes a specific server error.

### DeleteServerErrorsByHostIdAsync
```csharp
Task DeleteServerErrorsByHostIdAsync(int hostId, CancellationToken cancellationToken = default)
```
Deletes all server errors for a specific host.

## Examples

### Getting All Server Errors
```csharp
var errors = await _serverErrorService.GetServerErrorsAsync();
```

### Getting Server Errors for a Host
```csharp
var hostErrors = await _serverErrorService.GetServerErrorsByHostIdAsync(1);
```

### Getting a Specific Server Error
```csharp
var error = await _serverErrorService.GetServerErrorAsync(1);
```

### Deleting a Server Error
```csharp
await _serverErrorService.DeleteServerErrorAsync(1);
```

### Deleting All Server Errors for a Host
```csharp
await _serverErrorService.DeleteServerErrorsByHostIdAsync(1);
```

### Monitoring Server Errors
```csharp
public async Task MonitorServerErrorsAsync(int hostId, TimeSpan interval)
{
    while (true)
    {
        var errors = await _serverErrorService.GetServerErrorsByHostIdAsync(hostId);
        foreach (var error in errors)
        {
            Console.WriteLine($"Error {error.Id}: {error.ErrorCode} - {error.ErrorMessage}");
            Console.WriteLine($"URL: {error.RequestUrl}");
            Console.WriteLine($"Method: {error.RequestMethod}");
            Console.WriteLine($"Time: {error.CreatedAt}");
            Console.WriteLine("---");
        }
        await Task.Delay(interval);
    }
}
``` 