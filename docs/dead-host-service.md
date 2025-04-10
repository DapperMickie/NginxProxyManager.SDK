# Dead Host Service Documentation

The Dead Host Service provides functionality to manage 404 hosts in your Nginx Proxy Manager instance.

## Table of Contents
- [Overview](#overview)
- [Models](#models)
- [Methods](#methods)
- [Examples](#examples)

## Overview

The `IDeadHostService` interface and its implementation `DeadHostService` provide methods to create, read, update, and delete 404 hosts. These hosts are used to handle requests to non-existent domains.

## Models

### DeadHost
```csharp
public class DeadHost
{
    public int Id { get; set; }
    public string DomainName { get; set; }
    public string ForwardHost { get; set; }
    public string ForwardScheme { get; set; }
    public bool Enabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
```

### CreateDeadHostRequest
```csharp
public class CreateDeadHostRequest
{
    public string DomainName { get; set; }
    public string ForwardHost { get; set; }
    public string ForwardScheme { get; set; }
}
```

### UpdateDeadHostRequest
```csharp
public class UpdateDeadHostRequest
{
    public string DomainName { get; set; }
    public string ForwardHost { get; set; }
    public string ForwardScheme { get; set; }
}
```

## Methods

### GetDeadHostsAsync
```csharp
Task<DeadHost[]> GetDeadHostsAsync(CancellationToken cancellationToken = default)
```
Retrieves all dead hosts.

### GetDeadHostAsync
```csharp
Task<DeadHost> GetDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default)
```
Retrieves a specific dead host by ID.

### CreateDeadHostAsync
```csharp
Task<DeadHost> CreateDeadHostAsync(CreateDeadHostRequest request, CancellationToken cancellationToken = default)
```
Creates a new dead host.

### UpdateDeadHostAsync
```csharp
Task<DeadHost> UpdateDeadHostAsync(int deadHostId, UpdateDeadHostRequest request, CancellationToken cancellationToken = default)
```
Updates an existing dead host.

### DeleteDeadHostAsync
```csharp
Task DeleteDeadHostAsync(int deadHostId, CancellationToken cancellationToken = default)
```
Deletes a dead host.

### GetDeadHostsByDomainAsync
```csharp
Task<DeadHost[]> GetDeadHostsByDomainAsync(string domainName, CancellationToken cancellationToken = default)
```
Retrieves dead hosts by domain name.

### GetDeadHostsByForwardHostAsync
```csharp
Task<DeadHost[]> GetDeadHostsByForwardHostAsync(string forwardHost, CancellationToken cancellationToken = default)
```
Retrieves dead hosts by forward host.

## Examples

### Creating a Dead Host
```csharp
var request = new CreateDeadHostRequest
{
    DomainName = "*.example.com",
    ForwardHost = "https://404.example.com",
    ForwardScheme = "https"
};

var deadHost = await _deadHostService.CreateDeadHostAsync(request);
```

### Updating a Dead Host
```csharp
var request = new UpdateDeadHostRequest
{
    DomainName = "*.example.com",
    ForwardHost = "https://new-404.example.com",
    ForwardScheme = "https"
};

var updatedDeadHost = await _deadHostService.UpdateDeadHostAsync(1, request);
```

### Getting Dead Hosts by Domain
```csharp
var deadHosts = await _deadHostService.GetDeadHostsByDomainAsync("*.example.com");
```

### Getting Dead Hosts by Forward Host
```csharp
var deadHosts = await _deadHostService.GetDeadHostsByForwardHostAsync("https://404.example.com");
```

### Getting a Specific Dead Host
```csharp
var deadHost = await _deadHostService.GetDeadHostAsync(1);
```

### Deleting a Dead Host
```csharp
await _deadHostService.DeleteDeadHostAsync(1);
```

### Managing Dead Hosts
```csharp
public async Task ManageDeadHostsAsync()
{
    // Create a new dead host
    var createRequest = new CreateDeadHostRequest
    {
        DomainName = "*.example.com",
        ForwardHost = "https://404.example.com",
        ForwardScheme = "https"
    };
    var newDeadHost = await _deadHostService.CreateDeadHostAsync(createRequest);

    // Update the dead host
    var updateRequest = new UpdateDeadHostRequest
    {
        DomainName = "*.example.com",
        ForwardHost = "https://new-404.example.com",
        ForwardScheme = "https"
    };
    var updatedDeadHost = await _deadHostService.UpdateDeadHostAsync(newDeadHost.Id, updateRequest);

    // Get all dead hosts
    var allDeadHosts = await _deadHostService.GetDeadHostsAsync();
    foreach (var deadHost in allDeadHosts)
    {
        Console.WriteLine($"Dead Host {deadHost.Id}: {deadHost.DomainName}");
        Console.WriteLine($"Forward Host: {deadHost.ForwardHost}");
        Console.WriteLine($"Forward Scheme: {deadHost.ForwardScheme}");
        Console.WriteLine($"Created At: {deadHost.CreatedAt}");
        Console.WriteLine("---");
    }
}
``` 