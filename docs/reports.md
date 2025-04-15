# Reports

The Reports resource provides functionality for generating and managing reports in Nginx Proxy Manager. This includes generating reports for various aspects of your proxy setup.

## Quick Start

```csharp
using NginxProxyManager.SDK;
using NginxProxyManager.SDK.Common;

// Create credentials
var credentials = AuthenticationCredentials.FromCredentials("admin@example.com", "your-password");

// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", credentials);

// Generate a report
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    Console.WriteLine($"Report generated: {report.Title}");
    Console.WriteLine($"Generated at: {report.GeneratedAt}");
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
public class ReportController : ControllerBase
{
    private readonly INginxProxyManagerClient _client;

    public ReportController(INginxProxyManagerClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> GenerateReport()
    {
        var result = await _client.Reports.GenerateAsync();
        if (result.IsSuccess)
        {
            return View(result.Data);
        }
        
        return BadRequest(result.Error);
    }
}
```

## Generating Reports

### Generate a Complete Report

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    Console.WriteLine($"Report Title: {report.Title}");
    Console.WriteLine($"Generated At: {report.GeneratedAt}");
    Console.WriteLine($"Proxy Hosts: {report.ProxyHosts.Count}");
    Console.WriteLine($"Certificates: {report.Certificates.Count}");
    Console.WriteLine($"Access Lists: {report.AccessLists.Count}");
    Console.WriteLine($"Streams: {report.Streams.Count}");
}
```

### Generate a Report for Specific Resources

```csharp
var options = new ReportOptions
{
    IncludeProxyHosts = true,
    IncludeCertificates = true,
    IncludeAccessLists = false,
    IncludeStreams = false
};

var result = await client.Reports.GenerateAsync(options);
if (result.IsSuccess)
{
    var report = result.Data;
    Console.WriteLine($"Report Title: {report.Title}");
    Console.WriteLine($"Generated At: {report.GeneratedAt}");
    Console.WriteLine($"Proxy Hosts: {report.ProxyHosts.Count}");
    Console.WriteLine($"Certificates: {report.Certificates.Count}");
}
```

## Report Content

### Proxy Hosts Section

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    foreach (var host in report.ProxyHosts)
    {
        Console.WriteLine($"Proxy Host: {host.DomainNames[0]}");
        Console.WriteLine($"  Forward Host: {host.ForwardHost}:{host.ForwardPort}");
        Console.WriteLine($"  SSL: {(host.Ssl ? "Enabled" : "Disabled")}");
        Console.WriteLine($"  Access Lists: {string.Join(", ", host.AccessListIds)}");
    }
}
```

### Certificates Section

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    foreach (var cert in report.Certificates)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames[0]}");
        Console.WriteLine($"  Provider: {cert.Provider}");
        Console.WriteLine($"  Expires: {cert.ExpiresOn}");
        Console.WriteLine($"  Status: {cert.Status}");
    }
}
```

### Access Lists Section

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    foreach (var list in report.AccessLists)
    {
        Console.WriteLine($"Access List: {list.Name}");
        Console.WriteLine($"  Satisfy: {list.Satisfy}");
        Console.WriteLine($"  Rules: {list.Rules.Count}");
        foreach (var rule in list.Rules)
        {
            Console.WriteLine($"    - {rule.Name}: {rule.Rule}");
        }
    }
}
```

### Streams Section

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    foreach (var stream in report.Streams)
    {
        Console.WriteLine($"Stream: {stream.IncomingPort}");
        Console.WriteLine($"  Forward: {stream.ForwardingHost}:{stream.ForwardingPort}");
        Console.WriteLine($"  TCP: {stream.TcpForwarding}");
        Console.WriteLine($"  UDP: {stream.UdpForwarding}");
    }
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    // Use the report
    var report = result.Data;
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

### Export Report to JSON

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    var json = JsonSerializer.Serialize(report, new JsonSerializerOptions
    {
        WriteIndented = true
    });
    
    await File.WriteAllTextAsync("report.json", json);
    Console.WriteLine("Report exported to report.json");
}
```

### Generate and Email Report

```csharp
var result = await client.Reports.GenerateAsync();
if (result.IsSuccess)
{
    var report = result.Data;
    var emailBody = new StringBuilder();
    
    emailBody.AppendLine($"Nginx Proxy Manager Report - {report.GeneratedAt}");
    emailBody.AppendLine($"Total Proxy Hosts: {report.ProxyHosts.Count}");
    emailBody.AppendLine($"Total Certificates: {report.Certificates.Count}");
    emailBody.AppendLine($"Total Access Lists: {report.AccessLists.Count}");
    emailBody.AppendLine($"Total Streams: {report.Streams.Count}");
    
    // Send email using your preferred email service
    await SendEmailAsync("admin@example.com", "Nginx Proxy Manager Report", emailBody.ToString());
    Console.WriteLine("Report emailed successfully");
}
```

### Schedule Regular Reports

```csharp
// Run every day at midnight
while (true)
{
    var now = DateTime.Now;
    var nextRun = now.Date.AddDays(1);
    var delay = nextRun - now;
    
    await Task.Delay(delay);
    
    var result = await client.Reports.GenerateAsync();
    if (result.IsSuccess)
    {
        var report = result.Data;
        Console.WriteLine($"Daily report generated: {report.Title}");
        // Process or store the report as needed
    }
}
``` 