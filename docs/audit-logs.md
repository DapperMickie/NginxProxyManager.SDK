# Audit Logs

The Audit Logs resource provides a complete API for managing and retrieving audit logs in Nginx Proxy Manager. This includes retrieving logs, filtering logs, and managing log retention.

## Quick Start

```csharp
// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", "admin@example.com", "your-password");

// Get recent audit logs
var result = await client.AuditLogs.GetRecentAsync();
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.Action} by {log.User} at {log.Timestamp}");
    }
}
```

## Retrieving Audit Logs

### Get Recent Audit Logs

```csharp
var result = await client.AuditLogs.GetRecentAsync();
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.Action} by {log.User} at {log.Timestamp}");
    }
}
```

### Get Audit Logs by Date Range

```csharp
var startDate = DateTime.UtcNow.AddDays(-7);
var endDate = DateTime.UtcNow;

var result = await client.AuditLogs.GetByDateRangeAsync(startDate, endDate);
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.Action} by {log.User} at {log.Timestamp}");
    }
}
```

### Get Audit Logs by User

```csharp
var result = await client.AuditLogs.GetByUserAsync("admin@example.com");
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.Action} at {log.Timestamp}");
    }
}
```

### Get Audit Logs by Action

```csharp
var result = await client.AuditLogs.GetByActionAsync("create");
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.User} at {log.Timestamp}");
    }
}
```

## Filtering Audit Logs

### Filter by Multiple Criteria

```csharp
var filters = new AuditLogFilters
{
    StartDate = DateTime.UtcNow.AddDays(-7),
    EndDate = DateTime.UtcNow,
    User = "admin@example.com",
    Action = "create",
    ResourceType = "proxy_host"
};

var result = await client.AuditLogs.GetFilteredAsync(filters);
if (result.IsSuccess)
{
    foreach (var log in result.Data)
    {
        Console.WriteLine($"Audit Log: {log.Action} by {log.User} at {log.Timestamp}");
    }
}
```

## Managing Audit Logs

### Clear Audit Logs

```csharp
var result = await client.AuditLogs.ClearAsync();
if (result.IsSuccess)
{
    Console.WriteLine("Audit logs cleared successfully");
}
```

### Clear Audit Logs by Date Range

```csharp
var startDate = DateTime.UtcNow.AddDays(-30);
var endDate = DateTime.UtcNow;

var result = await client.AuditLogs.ClearByDateRangeAsync(startDate, endDate);
if (result.IsSuccess)
{
    Console.WriteLine("Audit logs cleared successfully");
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.AuditLogs.GetRecentAsync();
if (result.IsSuccess)
{
    // Use the logs
    var logs = result.Data;
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

### Export Audit Logs to CSV

```csharp
var result = await client.AuditLogs.GetRecentAsync();
if (result.IsSuccess)
{
    var logs = result.Data;
    var csv = new StringBuilder();
    
    // Add headers
    csv.AppendLine("Timestamp,User,Action,Resource Type,Resource ID,Details");
    
    // Add data
    foreach (var log in logs)
    {
        csv.AppendLine($"{log.Timestamp},{log.User},{log.Action},{log.ResourceType},{log.ResourceId},{log.Details}");
    }
    
    // Write to file
    await File.WriteAllTextAsync("audit_logs.csv", csv.ToString());
    Console.WriteLine("Audit logs exported to audit_logs.csv");
}
```

### Monitor Recent Activity

```csharp
while (true)
{
    var result = await client.AuditLogs.GetRecentAsync();
    if (result.IsSuccess)
    {
        var logs = result.Data;
        foreach (var log in logs)
        {
            Console.WriteLine($"[{log.Timestamp}] {log.User} {log.Action} {log.ResourceType} {log.ResourceId}");
        }
    }
    
    await Task.Delay(TimeSpan.FromMinutes(5));
}
```

### Batch Operations

```csharp
// Clear logs for multiple date ranges
var dateRanges = new[]
{
    (DateTime.UtcNow.AddDays(-90), DateTime.UtcNow.AddDays(-60)),
    (DateTime.UtcNow.AddDays(-60), DateTime.UtcNow.AddDays(-30)),
    (DateTime.UtcNow.AddDays(-30), DateTime.UtcNow)
};

foreach (var (startDate, endDate) in dateRanges)
{
    var result = await client.AuditLogs.ClearByDateRangeAsync(startDate, endDate);
    if (result.IsSuccess)
    {
        Console.WriteLine($"Cleared logs from {startDate} to {endDate}");
    }
    else
    {
        Console.WriteLine($"Failed to clear logs: {result.Error.Message}");
    }
}
``` 