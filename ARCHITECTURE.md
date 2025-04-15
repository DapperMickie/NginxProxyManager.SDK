# Nginx Proxy Manager SDK Architecture

## Overview

The SDK follows a layered architecture that separates the public API from the internal implementation details. This document explains how the components interact and their responsibilities.

## Architecture Diagram

```
┌─────────────────────────────────────────────────────┐
│                  Public SDK Interface               │
│                                                     │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  │
│  │ ProxyHosts  │  │ Redirection │  │   Streams   │  |
│  │  Resource   │  │   Hosts     │  │  Resource   │  │
│  └──────┬──────┘  └──────┬──────┘  └──────┬──────┘  │
└─────────┼────────────────┼────────────────┼─────────┘
          │                │                │
          ▼                ▼                ▼
┌─────────────────────────────────────────────────────┐
│                Internal Service Layer               │
│                                                     │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  │
│  │  ProxyHost  │  │ Redirection │  │   Stream    │  │
│  │   Service   │  │   Service   │  │   Service   │  │
│  └──────┬──────┘  └──────┬──────┘  └──────┬──────┘  │
└─────────┼────────────────┼────────────────┼─────────┘
          │                │                │
          ▼                ▼                ▼
┌─────────────────────────────────────────────────────┐
│                HTTP Client Layer                    │
│                                                     │
│  ┌───────────────────────────────────────────────┐  │
│  │             HttpClientWrapper                 │  │
│  └───────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────┘
```

## Component Responsibilities

### 1. Public SDK Interface

The public interface is what users of the SDK interact with. It provides:

- **Resource-Based Access**: Properties like `ProxyHosts`, `RedirectionHosts`, etc.
- **Fluent Builders**: Chainable methods for configuration
- **Rich Operation Results**: Context and capabilities beyond raw data
- **Resource Collections**: Filtering, sorting, and pagination

Example:
```csharp
var client = new NginxProxyManagerClient(config);
var proxy = await client.ProxyHosts.GetAsync(1);
await proxy.EnableSslAsync();
```

### 2. Internal Service Layer

The service layer handles the technical details of communicating with the Nginx Proxy Manager API:

- **HTTP Communication**: Making API calls
- **Request/Response Handling**: Serialization/deserialization
- **Error Handling**: Processing API errors
- **Authentication**: Managing tokens and credentials

Example:
```csharp
// Internal service method
public async Task<ProxyHost> GetProxyHostAsync(int id)
{
    var response = await _httpClient.GetAsync($"/api/proxy-hosts/{id}");
    // Process response...
}
```

### 3. HTTP Client Layer

The HTTP client layer provides the foundation for all API communication:

- **HTTP Request Execution**: Sending requests to the server
- **Response Processing**: Handling HTTP responses
- **Retry Logic**: Implementing retry policies
- **Logging**: Recording request/response details

## Data Flow

When a user calls a method on the public API:

1. The resource interface receives the request
2. It calls the corresponding internal service method
3. The service makes the HTTP request via the client wrapper
4. The response flows back through the service to the resource
5. The resource wraps the response in a rich operation result
6. The user receives the result with additional context

Example flow:
```csharp
// User code
var result = await client.ProxyHosts.GetAsync(1);

// Internal flow
public class ProxyHostsResource
{
    private readonly ProxyHostService _service;
    
    public async Task<OperationResult<ProxyHost>> GetAsync(int id)
    {
        var proxy = await _service.GetProxyHostAsync(id);
        return new OperationResult<ProxyHost>(proxy);
    }
}
```

## Benefits

1. **Separation of Concerns**
   - Public API focuses on usability
   - Internal services handle technical details

2. **Maintainability**
   - API changes don't affect HTTP layer
   - Services can be refactored independently

3. **Testability**
   - Services can be mocked for API testing
   - Components can be tested in isolation

4. **Flexibility**
   - New API features can be added without changing services
   - Services can be refactored without affecting the API

## Implementation Notes

- Keep services internal (use `internal` access modifier)
- Document public API thoroughly
- Use interfaces for services to enable mocking
- Implement proper error handling at each layer
- Use dependency injection for services
- Follow consistent naming conventions 