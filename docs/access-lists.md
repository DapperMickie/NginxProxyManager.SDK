# Access Lists

The Access Lists resource provides a complete API for managing access lists in Nginx Proxy Manager. This includes creating, reading, updating, and deleting access lists, as well as managing their rules and metadata.

## Quick Start

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

// List all access lists
var result = await client.AccessLists.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var list in result.Data)
    {
        Console.WriteLine($"Access List: {list.Name} ({list.Rules.Count} rules)");
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
public class AccessListController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public AccessListController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _client.AccessLists.GetAllAsync();
        if (result.IsSuccess)
        {
            return View(result.Data);
        }
        
        return BadRequest(result.Error);
    }
}
```

## Creating an Access List

### Basic Access List

```csharp
// Create a basic access list
var list = await client.AccessLists.CreateBuilder()
    .WithName("Basic Access List")
    .WithSatisfy("any")
    .WithRules(new[]
    {
        new AccessListRule
        {
            Name = "Allow Local Network",
            Rule = "allow 192.168.1.0/24"
        }
    })
    .Build();

var result = await client.AccessLists.CreateAsync(list);
if (result.IsSuccess)
{
    Console.WriteLine($"Created access list with ID: {result.Data.Id}");
}
```

### Access List with Multiple Rules

```csharp
// Create an access list with multiple rules
var list = await client.AccessLists.CreateBuilder()
    .WithName("Complex Access List")
    .WithSatisfy("all")
    .WithRules(new[]
    {
        new AccessListRule
        {
            Name = "Allow Local Network",
            Rule = "allow 192.168.1.0/24"
        },
        new AccessListRule
        {
            Name = "Allow VPN Network",
            Rule = "allow 10.0.0.0/8"
        },
        new AccessListRule
        {
            Name = "Deny All",
            Rule = "deny all"
        }
    })
    .Build();

var result = await client.AccessLists.CreateAsync(list);
if (result.IsSuccess)
{
    Console.WriteLine($"Created access list with ID: {result.Data.Id}");
}
```

## Retrieving Access Lists

### Get All Access Lists

```csharp
var result = await client.AccessLists.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var list in result.Data)
    {
        Console.WriteLine($"Access List: {list.Name} ({list.Rules.Count} rules)");
    }
}
```

### Get Access List by ID

```csharp
var result = await client.AccessLists.GetByIdAsync(1);
if (result.IsSuccess)
{
    var list = result.Data;
    Console.WriteLine($"Access List: {list.Name} ({list.Rules.Count} rules)");
}
```

## Updating an Access List

```csharp
// Get the access list
var getResult = await client.AccessLists.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var list = getResult.Data;
    
    // Update the access list
    list.Rules.Add(new AccessListRule
    {
        Name = "Allow Additional Network",
        Rule = "allow 172.16.0.0/12"
    });
    
    var updateResult = await client.AccessLists.UpdateAsync(list);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Access list updated successfully");
    }
}
```

## Deleting an Access List

```csharp
var result = await client.AccessLists.DeleteAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Access list deleted successfully");
}
```

## Managing Access List Rules

### Add a Rule

```csharp
// Get the access list
var getResult = await client.AccessLists.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var list = getResult.Data;
    
    // Add a rule
    list.Rules.Add(new AccessListRule
    {
        Name = "Allow New Network",
        Rule = "allow 172.16.0.0/12"
    });
    
    var updateResult = await client.AccessLists.UpdateAsync(list);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Rule added successfully");
    }
}
```

### Remove a Rule

```csharp
// Get the access list
var getResult = await client.AccessLists.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var list = getResult.Data;
    
    // Remove a rule
    list.Rules.RemoveAll(r => r.Name == "Allow Old Network");
    
    var updateResult = await client.AccessLists.UpdateAsync(list);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Rule removed successfully");
    }
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.AccessLists.CreateAsync(list);
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

### Create an Access List with All Options

```csharp
var list = await client.AccessLists.CreateBuilder()
    .WithName("Production Access List")
    .WithSatisfy("all")
    .WithRules(new[]
    {
        new AccessListRule
        {
            Name = "Allow Local Network",
            Rule = "allow 192.168.1.0/24"
        },
        new AccessListRule
        {
            Name = "Allow VPN Network",
            Rule = "allow 10.0.0.0/8"
        },
        new AccessListRule
        {
            Name = "Allow Specific IPs",
            Rule = "allow 203.0.113.1"
        },
        new AccessListRule
        {
            Name = "Deny All",
            Rule = "deny all"
        }
    })
    .WithMeta(new Dictionary<string, string>
    {
        { "description", "Production access list" },
        { "environment", "production" }
    })
    .Build();

var result = await client.AccessLists.CreateAsync(list);
if (result.IsSuccess)
{
    Console.WriteLine($"Created access list with ID: {result.Data.Id}");
}
```

### Batch Operations

```csharp
// Create multiple access lists
var lists = new[]
{
    await client.AccessLists.CreateBuilder()
        .WithName("Development Access List")
        .WithSatisfy("any")
        .WithRules(new[]
        {
            new AccessListRule
            {
                Name = "Allow All",
                Rule = "allow all"
            }
        })
        .Build(),
    await client.AccessLists.CreateBuilder()
        .WithName("Staging Access List")
        .WithSatisfy("all")
        .WithRules(new[]
        {
            new AccessListRule
            {
                Name = "Allow VPN",
                Rule = "allow 10.0.0.0/8"
            },
            new AccessListRule
            {
                Name = "Deny All",
                Rule = "deny all"
            }
        })
        .Build()
};

foreach (var list in lists)
{
    var result = await client.AccessLists.CreateAsync(list);
    if (result.IsSuccess)
    {
        Console.WriteLine($"Created access list with ID: {result.Data.Id}");
    }
    else
    {
        Console.WriteLine($"Failed to create access list: {result.Error.Message}");
    }
}
``` 