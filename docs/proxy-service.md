# Proxy Service Documentation

The Proxy Service provides functionality to manage proxy hosts in your Nginx Proxy Manager instance.

## Table of Contents
- [Overview](#overview)
- [Models](#models)
- [Methods](#methods)
- [Examples](#examples)

## Overview

The `IProxyService` interface and its implementation `ProxyService` provide methods to create, read, update, and delete proxy hosts. It also supports advanced features like SSL certificate management and access list configuration.

## Models

### ProxyHost
```csharp
public class ProxyHost
{
    public int Id { get; set; }
    public string DomainName { get; set; }
    public string ForwardHost { get; set; }
    public int ForwardPort { get; set; }
    public bool ForceSsl { get; set; }
    public bool HstsEnabled { get; set; }
    public bool HstsSubdomains { get; set; }
    public bool HstsPreload { get; set; }
    public int HstsMaxAge { get; set; }
    public bool WebsocketSupport { get; set; }
    public string[] AccessListIds { get; set; }
    public int? CertificateId { get; set; }
    public bool BlockCommonExploits { get; set; }
    public bool Http2Support { get; set; }
    public Dictionary<string, string> CustomNginxConfig { get; set; }
}
```

### CreateProxyRequest
```csharp
public class CreateProxyRequest
{
    public string DomainName { get; set; }
    public string ForwardHost { get; set; }
    public int ForwardPort { get; set; }
    public bool ForceSsl { get; set; }
    public bool HstsEnabled { get; set; }
    public bool HstsSubdomains { get; set; }
    public bool HstsPreload { get; set; }
    public int HstsMaxAge { get; set; }
    public bool WebsocketSupport { get; set; }
    public string[] AccessListIds { get; set; }
    public int? CertificateId { get; set; }
    public bool BlockCommonExploits { get; set; }
    public bool Http2Support { get; set; }
    public Dictionary<string, string> CustomNginxConfig { get; set; }
}
```

### UpdateProxyRequest
```csharp
public class UpdateProxyRequest
{
    public string DomainName { get; set; }
    public string ForwardHost { get; set; }
    public int ForwardPort { get; set; }
    public bool ForceSsl { get; set; }
    public bool HstsEnabled { get; set; }
    public bool HstsSubdomains { get; set; }
    public bool HstsPreload { get; set; }
    public int HstsMaxAge { get; set; }
    public bool WebsocketSupport { get; set; }
    public string[] AccessListIds { get; set; }
    public int? CertificateId { get; set; }
    public bool BlockCommonExploits { get; set; }
    public bool Http2Support { get; set; }
    public Dictionary<string, string> CustomNginxConfig { get; set; }
}
```

## Methods

### GetProxyHostsAsync
```csharp
Task<ProxyHost[]> GetProxyHostsAsync(CancellationToken cancellationToken = default)
```
Retrieves all proxy hosts.

### GetProxyHostAsync
```csharp
Task<ProxyHost> GetProxyHostAsync(int proxyId, CancellationToken cancellationToken = default)
```
Retrieves a specific proxy host by ID.

### CreateProxyHostAsync
```csharp
Task<ProxyHost> CreateProxyHostAsync(CreateProxyRequest request, CancellationToken cancellationToken = default)
```
Creates a new proxy host.

### UpdateProxyHostAsync
```csharp
Task<ProxyHost> UpdateProxyHostAsync(int proxyId, UpdateProxyRequest request, CancellationToken cancellationToken = default)
```
Updates an existing proxy host.

### DeleteProxyHostAsync
```csharp
Task DeleteProxyHostAsync(int proxyId, CancellationToken cancellationToken = default)
```
Deletes a proxy host.

### GetProxyHostsByDomainAsync
```csharp
Task<ProxyHost[]> GetProxyHostsByDomainAsync(string domainName, CancellationToken cancellationToken = default)
```
Retrieves proxy hosts by domain name.

### GetProxyHostsByForwardHostAsync
```csharp
Task<ProxyHost[]> GetProxyHostsByForwardHostAsync(string forwardHost, CancellationToken cancellationToken = default)
```
Retrieves proxy hosts by forward host.

## Examples

### Creating a Proxy Host
```csharp
var request = new CreateProxyRequest
{
    DomainName = "example.com",
    ForwardHost = "192.168.1.100",
    ForwardPort = 8080,
    ForceSsl = true,
    WebsocketSupport = true,
    Http2Support = true
};

var proxy = await _proxyService.CreateProxyHostAsync(request);
```

### Updating a Proxy Host
```csharp
var request = new UpdateProxyRequest
{
    DomainName = "example.com",
    ForwardHost = "192.168.1.101",
    ForwardPort = 8081,
    ForceSsl = true,
    WebsocketSupport = true,
    Http2Support = true
};

var updatedProxy = await _proxyService.UpdateProxyHostAsync(1, request);
```

### Getting Proxy Hosts by Domain
```csharp
var proxies = await _proxyService.GetProxyHostsByDomainAsync("example.com");
```

### Deleting a Proxy Host
```csharp
await _proxyService.DeleteProxyHostAsync(1);
``` 