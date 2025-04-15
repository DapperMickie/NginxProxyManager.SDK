# Nginx Proxy Manager SDK Design

## Goals

The SDK aims to provide a rich, intuitive interface for interacting with Nginx Proxy Manager, following modern SDK design patterns and best practices. The focus is on making the SDK feel natural and developer-friendly, rather than just being an HTTP client wrapper.

## Core Design Principles

1. **Resource-Based Client Structure**
   - Main client class providing access to different resources through properties
   - Intuitive and discoverable API
   - Example:
     ```csharp
     var client = new NginxProxyManagerClient(config);
     var proxy = await client.ProxyHosts.GetAsync(1);
     ```

2. **Fluent Builder Patterns**
   - Rich builders for complex operations
   - Chainable methods for configuration
   - Example:
     ```csharp
     await client.ProxyHosts
         .CreateBuilder()
         .WithDomains("example.com")
         .ForwardTo("localhost", 8080)
         .WithSslEnabled()
         .WithHstsEnabled()
         .BuildAndCreateAsync();
     ```

3. **Operation Results**
   - Rich operation results providing additional context
   - Resource-specific operations
   - Example:
     ```csharp
     var proxyResult = await client.ProxyHosts.GetAsync(1);
     if (proxyResult.IsSuccess)
     {
         await proxyResult.Resource.EnableSslAsync();
         await proxyResult.Resource.UpdateForwardingAsync("newhost", 8081);
         await proxyResult.Resource.DeleteAsync();
     }
     ```

4. **Resource Collections**
   - Rich collection interfaces for listing and querying
   - Support for filtering and pagination
   - Example:
     ```csharp
     var collection = client.ProxyHosts;
     var activeProxies = await collection
         .Where(p => p.IsEnabled)
         .WithSsl()
         .OrderByCreationTime()
         .GetPageAsync(1, 20);
     ```

5. **Resource Management**
   - First-class resource objects with their own methods
   - Resource-specific operations
   - Example:
     ```csharp
     var proxy = await client.ProxyHosts.GetAsync(1);
     await proxy.EnableSslAsync();
     await proxy.RedirectToHttpsAsync();
     await proxy.AddDomainAsync("new.example.com");
     await proxy.RemoveDomainAsync("old.example.com");
     ```

8. **Configuration Management**
   - Rich configuration interface
   - Flexible authentication options
   - Example:
     ```csharp
     var config = new NginxProxyManagerClientConfig()
         .WithEndpoint("https://npm.example.com")
         .WithAuthentication(credentials)
         .WithRetryPolicy(RetryPolicy.ExponentialBackoff)
         .WithTimeout(TimeSpan.FromSeconds(30))
         .WithLogging(logger);

     var client = new NginxProxyManagerClient(config);
     ```

## Implementation Plan

1. **Phase 1: Core Structure**
   - Create main client class
   - Implement configuration system
   - Set up resource interfaces

2. **Phase 2: Resource Implementation**
   - Implement ProxyHosts resource
   - Implement RedirectionHosts resource
   - Implement DeadHosts resource
   - Implement Streams resource
   - Implement Reports resource

3. **Phase 3: Builder Patterns**
   - Implement fluent builders for each resource
   - Add validation and error handling
   - Implement operation results

4. **Phase 4: Collection Support**
   - Implement collection interfaces
   - Add filtering and pagination
   - Add sorting capabilities

5. **Phase 5: Resource Management**
   - Implement resource-specific operations
   - Add relationship handling
   - Implement monitoring capabilities

## Notes

- Focus on making the SDK intuitive and discoverable
- Ensure strong type safety
- Provide comprehensive documentation
- Follow modern C# conventions
- Make common operations easier
- Ensure maintainability 