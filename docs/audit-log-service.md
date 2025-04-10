# Audit Log Service Documentation

The Audit Log Service provides functionality to access and manage audit logs in your Nginx Proxy Manager instance.

## Table of Contents
- [Overview](#overview)
- [Models](#models)
- [Methods](#methods)
- [Examples](#examples)

## Overview

The `IAuditLogService` interface and its implementation `AuditLogService` provide methods to retrieve and manage audit logs. This service is useful for tracking changes and actions performed in your Nginx Proxy Manager instance.

## Models

### AuditLog
```csharp
public class AuditLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Action { get; set; }
    public string EntityType { get; set; }
    public int? EntityId { get; set; }
    public string EntityName { get; set; }
    public string Details { get; set; }
    public string IpAddress { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

## Methods

### GetAuditLogsAsync
```csharp
Task<AuditLog[]> GetAuditLogsAsync(CancellationToken cancellationToken = default)
```
Retrieves all audit logs.

### GetAuditLogAsync
```csharp
Task<AuditLog> GetAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default)
```
Retrieves a specific audit log by ID.

### GetAuditLogsByUserIdAsync
```csharp
Task<AuditLog[]> GetAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
```
Retrieves audit logs for a specific user.

### GetAuditLogsByActionAsync
```csharp
Task<AuditLog[]> GetAuditLogsByActionAsync(string action, CancellationToken cancellationToken = default)
```
Retrieves audit logs for a specific action.

### GetAuditLogsByDateRangeAsync
```csharp
Task<AuditLog[]> GetAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
```
Retrieves audit logs within a date range.

### DeleteAuditLogAsync
```csharp
Task DeleteAuditLogAsync(int auditLogId, CancellationToken cancellationToken = default)
```
Deletes a specific audit log.

### DeleteAuditLogsByUserIdAsync
```csharp
Task DeleteAuditLogsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
```
Deletes all audit logs for a specific user.

### DeleteAuditLogsByDateRangeAsync
```csharp
Task DeleteAuditLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
```
Deletes all audit logs within a date range.

## Examples

### Getting All Audit Logs
```csharp
var logs = await _auditLogService.GetAuditLogsAsync();
```

### Getting Audit Logs for a User
```csharp
var userLogs = await _auditLogService.GetAuditLogsByUserIdAsync(1);
```

### Getting Audit Logs for an Action
```csharp
var actionLogs = await _auditLogService.GetAuditLogsByActionAsync("create");
```

### Getting Audit Logs in a Date Range
```csharp
var startDate = DateTime.Now.AddDays(-7);
var endDate = DateTime.Now;
var dateRangeLogs = await _auditLogService.GetAuditLogsByDateRangeAsync(startDate, endDate);
```

### Getting a Specific Audit Log
```csharp
var log = await _auditLogService.GetAuditLogAsync(1);
```

### Deleting an Audit Log
```csharp
await _auditLogService.DeleteAuditLogAsync(1);
```

### Deleting All Audit Logs for a User
```csharp
await _auditLogService.DeleteAuditLogsByUserIdAsync(1);
```

### Deleting Audit Logs in a Date Range
```csharp
var startDate = DateTime.Now.AddDays(-30);
var endDate = DateTime.Now.AddDays(-7);
await _auditLogService.DeleteAuditLogsByDateRangeAsync(startDate, endDate);
```

### Monitoring Audit Logs
```csharp
public async Task MonitorAuditLogsAsync(TimeSpan interval)
{
    while (true)
    {
        var logs = await _auditLogService.GetAuditLogsAsync();
        foreach (var log in logs)
        {
            Console.WriteLine($"Log {log.Id}: {log.Action} by {log.UserName}");
            Console.WriteLine($"Entity: {log.EntityType} - {log.EntityName}");
            Console.WriteLine($"Time: {log.CreatedAt}");
            Console.WriteLine($"IP: {log.IpAddress}");
            Console.WriteLine("---");
        }
        await Task.Delay(interval);
    }
}
``` 