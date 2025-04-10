# Nginx Proxy Manager SDK

A .NET SDK for interacting with the Nginx Proxy Manager API. This SDK provides a type-safe and intuitive way to manage your Nginx Proxy Manager instance programmatically.

## Features

- Full support for all Nginx Proxy Manager API endpoints
- Type-safe models and requests
- Dependency injection support
- Async/await pattern
- Comprehensive error handling
- Configuration through appsettings.json or code

## Installation

```bash
dotnet add package NgninxProxyManager.SDK
```

## Quick Start

1. Add the SDK to your service collection:

```csharp
// Using configuration from appsettings.json
services.AddNginxProxyManager();

// Or using code configuration
services.AddNginxProxyManager(new NPMConfiguration
{
    BaseUrl = "http://your-npm-instance:81",
    TimeoutSeconds = 30
});
```

2. Inject and use the services:

```csharp
public class YourService
{
    private readonly IProxyService _proxyService;
    private readonly ICertificateService _certificateService;

    public YourService(IProxyService proxyService, ICertificateService certificateService)
    {
        _proxyService = proxyService;
        _certificateService = certificateService;
    }

    public async Task CreateProxyHostAsync()
    {
        var request = new CreateProxyRequest
        {
            DomainName = "example.com",
            ForwardHost = "192.168.1.100",
            ForwardPort = 8080
        };

        var proxy = await _proxyService.CreateProxyAsync(request);
    }
}
```

## Configuration

### Using appsettings.json

```json
{
  "NginxProxyManager": {
    "BaseUrl": "http://your-npm-instance:81",
    "TimeoutSeconds": 30
  }
}
```

### Using Code

```csharp
var config = new NPMConfiguration
{
    BaseUrl = "http://your-npm-instance:81",
    TimeoutSeconds = 30
};

services.AddNginxProxyManager(config);
```

## Available Services

- `IProxyService` - Manage proxy hosts
- `ICertificateService` - Manage SSL certificates
- `IAccessListService` - Manage access lists
- `IRedirectionService` - Manage redirections
- `IStreamService` - Manage stream configurations
- `IServerErrorService` - Monitor server errors
- `IAuditLogService` - Access audit logs
- `IDeadHostService` - Manage dead hosts
- `IReportService` - Generate and manage reports

## Documentation

Detailed documentation for each service is available in the `docs` directory:

- [Proxy Service Documentation](docs/proxy-service.md)
- [Certificate Service Documentation](docs/certificate-service.md)
- [Access List Service Documentation](docs/access-list-service.md)
- [Redirection Service Documentation](docs/redirection-service.md)
- [Stream Service Documentation](docs/stream-service.md)
- [Server Error Service Documentation](docs/server-error-service.md)
- [Audit Log Service Documentation](docs/audit-log-service.md)
- [Dead Host Service Documentation](docs/dead-host-service.md)
- [Report Service Documentation](docs/report-service.md)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details. 