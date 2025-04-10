# Report Service Documentation

The Report Service provides functionality to generate and manage reports in your Nginx Proxy Manager instance.

## Table of Contents
- [Overview](#overview)
- [Models](#models)
- [Methods](#methods)
- [Examples](#examples)

## Overview

The `IReportService` interface and its implementation `ReportService` provide methods to create, read, update, and delete reports. Reports can be used to generate various types of analytics and monitoring data.

## Models

### Report
```csharp
public class Report
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
    public string Schedule { get; set; }
    public DateTime? LastRun { get; set; }
    public DateTime? NextRun { get; set; }
    public string Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
```

## Methods

### GetReportsAsync
```csharp
Task<Report[]> GetReportsAsync(CancellationToken cancellationToken = default)
```
Retrieves all reports.

### GetReportAsync
```csharp
Task<Report> GetReportAsync(int reportId, CancellationToken cancellationToken = default)
```
Retrieves a specific report by ID.

### CreateReportAsync
```csharp
Task<Report> CreateReportAsync(Report report, CancellationToken cancellationToken = default)
```
Creates a new report.

### UpdateReportAsync
```csharp
Task<Report> UpdateReportAsync(int reportId, Report report, CancellationToken cancellationToken = default)
```
Updates an existing report.

### DeleteReportAsync
```csharp
Task DeleteReportAsync(int reportId, CancellationToken cancellationToken = default)
```
Deletes a report.

### RunReportAsync
```csharp
Task<Report> RunReportAsync(int reportId, CancellationToken cancellationToken = default)
```
Runs a report immediately.

### GetReportsByTypeAsync
```csharp
Task<Report[]> GetReportsByTypeAsync(string reportType, CancellationToken cancellationToken = default)
```
Retrieves reports by type.

## Examples

### Creating a Report
```csharp
var report = new Report
{
    Name = "Daily Traffic Report",
    Type = "traffic",
    Description = "Daily traffic statistics for all proxy hosts",
    Parameters = new Dictionary<string, string>
    {
        { "timeRange", "24h" },
        { "includeGraphs", "true" }
    },
    Schedule = "0 0 * * *", // Run daily at midnight
    Status = "active"
};

var createdReport = await _reportService.CreateReportAsync(report);
```

### Updating a Report
```csharp
var report = new Report
{
    Name = "Updated Traffic Report",
    Description = "Updated daily traffic statistics",
    Parameters = new Dictionary<string, string>
    {
        { "timeRange", "48h" },
        { "includeGraphs", "true" }
    }
};

var updatedReport = await _reportService.UpdateReportAsync(1, report);
```

### Running a Report
```csharp
var report = await _reportService.RunReportAsync(1);
```

### Getting Reports by Type
```csharp
var trafficReports = await _reportService.GetReportsByTypeAsync("traffic");
```

### Getting a Specific Report
```csharp
var report = await _reportService.GetReportAsync(1);
```

### Deleting a Report
```csharp
await _reportService.DeleteReportAsync(1);
```

### Managing Reports
```csharp
public async Task ManageReportsAsync()
{
    // Create a new report
    var report = new Report
    {
        Name = "Weekly Performance Report",
        Type = "performance",
        Description = "Weekly performance metrics for all proxy hosts",
        Parameters = new Dictionary<string, string>
        {
            { "timeRange", "7d" },
            { "metrics", "latency,throughput,errors" }
        },
        Schedule = "0 0 * * 0", // Run weekly on Sunday at midnight
        Status = "active"
    };
    var newReport = await _reportService.CreateReportAsync(report);

    // Run the report
    var runReport = await _reportService.RunReportAsync(newReport.Id);

    // Get all reports
    var allReports = await _reportService.GetReportsAsync();
    foreach (var r in allReports)
    {
        Console.WriteLine($"Report {r.Id}: {r.Name}");
        Console.WriteLine($"Type: {r.Type}");
        Console.WriteLine($"Description: {r.Description}");
        Console.WriteLine($"Schedule: {r.Schedule}");
        Console.WriteLine($"Last Run: {r.LastRun}");
        Console.WriteLine($"Next Run: {r.NextRun}");
        Console.WriteLine($"Status: {r.Status}");
        Console.WriteLine("---");
    }
}
``` 