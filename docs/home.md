# NginxProxyManager.SDK Documentation

Welcome to the NginxProxyManager.SDK documentation. This SDK provides a .NET client for interacting with the Nginx Proxy Manager API.

## Getting Started

To use this SDK, you need to:

1. Install the NuGet package
2. Configure the client with your Nginx Proxy Manager instance URL and credentials
3. Use the services to interact with the API

## Available Services

The SDK provides the following services:

- [Proxy Service](Proxy-Service) - Manage proxy hosts
- [Certificate Service](Certificate-Service) - Manage SSL certificates
- [Dead Host Service](Dead-Host-Service) - Manage dead hosts
- [Audit Log Service](Audit-Log-Service) - Access audit logs
- [Server Error Service](Server-Error-Service) - Handle server errors
- [Report Service](Report-Service) - Generate reports

## Installation

```bash
dotnet add package NginxProxyManager.SDK
```

## Basic Usage

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Services;

// Create a client
var client = new NginxProxyManagerClient("https://your-npm-instance.com", "your-api-key");

// Use services
var proxyService = client.ProxyService;
var certificates = await proxyService.GetProxyHostsAsync();
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details. 