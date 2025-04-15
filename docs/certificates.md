# Certificates

The Certificates resource provides a complete API for managing SSL certificates in Nginx Proxy Manager. This includes creating, reading, updating, and deleting certificates, as well as managing their domains and metadata.

## Quick Start

```csharp
// Create a client
var client = new NginxProxyManagerClient("http://your-npm-instance:81", "admin@example.com", "your-password");

// List all certificates
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames[0]} (Expires: {cert.ExpiresOn})");
    }
}
```

## Creating a Certificate

### Basic Certificate

```csharp
// Create a basic certificate
var cert = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com")
    .WithEmail("admin@example.com")
    .WithProvider("letsencrypt")
    .Build();

var result = await client.Certificates.CreateAsync(cert);
if (result.IsSuccess)
{
    Console.WriteLine($"Created certificate with ID: {result.Data.Id}");
}
```

### Certificate with Multiple Domains

```csharp
// Create a certificate with multiple domains
var cert = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com", "www.example.com", "api.example.com")
    .WithEmail("admin@example.com")
    .WithProvider("letsencrypt")
    .Build();

var result = await client.Certificates.CreateAsync(cert);
if (result.IsSuccess)
{
    Console.WriteLine($"Created certificate with ID: {result.Data.Id}");
}
```

### Custom Certificate

```csharp
// Create a custom certificate
var cert = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com")
    .WithProvider("custom")
    .WithCertificate("-----BEGIN CERTIFICATE-----\n...\n-----END CERTIFICATE-----")
    .WithKey("-----BEGIN PRIVATE KEY-----\n...\n-----END PRIVATE KEY-----")
    .Build();

var result = await client.Certificates.CreateAsync(cert);
if (result.IsSuccess)
{
    Console.WriteLine($"Created custom certificate with ID: {result.Data.Id}");
}
```

## Retrieving Certificates

### Get All Certificates

```csharp
var result = await client.Certificates.GetAllAsync();
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames[0]} (Expires: {cert.ExpiresOn})");
    }
}
```

### Get Certificate by ID

```csharp
var result = await client.Certificates.GetByIdAsync(1);
if (result.IsSuccess)
{
    var cert = result.Data;
    Console.WriteLine($"Certificate: {cert.DomainNames[0]} (Expires: {cert.ExpiresOn})");
}
```

### Get Certificates by Domain

```csharp
var result = await client.Certificates.GetByDomainAsync("example.com");
if (result.IsSuccess)
{
    foreach (var cert in result.Data)
    {
        Console.WriteLine($"Certificate: {cert.DomainNames[0]} (Expires: {cert.ExpiresOn})");
    }
}
```

## Updating a Certificate

```csharp
// Get the certificate
var getResult = await client.Certificates.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var cert = getResult.Data;
    
    // Update the certificate
    cert.DomainNames.Add("new.example.com");
    
    var updateResult = await client.Certificates.UpdateAsync(cert);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Certificate updated successfully");
    }
}
```

## Deleting a Certificate

```csharp
var result = await client.Certificates.DeleteAsync(1);
if (result.IsSuccess)
{
    Console.WriteLine("Certificate deleted successfully");
}
```

## Managing Certificate Domains

### Add a Domain

```csharp
// Get the certificate
var getResult = await client.Certificates.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var cert = getResult.Data;
    
    // Add a domain
    cert.DomainNames.Add("new.example.com");
    
    var updateResult = await client.Certificates.UpdateAsync(cert);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Domain added successfully");
    }
}
```

### Remove a Domain

```csharp
// Get the certificate
var getResult = await client.Certificates.GetByIdAsync(1);
if (getResult.IsSuccess)
{
    var cert = getResult.Data;
    
    // Remove a domain
    cert.DomainNames.Remove("old.example.com");
    
    var updateResult = await client.Certificates.UpdateAsync(cert);
    if (updateResult.IsSuccess)
    {
        Console.WriteLine("Domain removed successfully");
    }
}
```

## Error Handling

All operations return an `OperationResult<T>` that contains the result of the operation and any error information:

```csharp
var result = await client.Certificates.CreateAsync(cert);
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

### Create a Certificate with All Options

```csharp
var cert = await client.Certificates.CreateBuilder()
    .WithDomainNames("example.com", "www.example.com", "api.example.com")
    .WithEmail("admin@example.com")
    .WithProvider("letsencrypt")
    .WithDnsProvider("cloudflare")
    .WithDnsProviderCredentials(new Dictionary<string, string>
    {
        { "CF_API_EMAIL", "admin@example.com" },
        { "CF_API_KEY", "your-api-key" }
    })
    .WithMeta(new Dictionary<string, string>
    {
        { "description", "Example certificate" },
        { "environment", "production" }
    })
    .Build();

var result = await client.Certificates.CreateAsync(cert);
if (result.IsSuccess)
{
    Console.WriteLine($"Created certificate with ID: {result.Data.Id}");
}
```

### Batch Operations

```csharp
// Create multiple certificates
var certificates = new[]
{
    await client.Certificates.CreateBuilder()
        .WithDomainNames("site1.example.com")
        .WithEmail("admin@example.com")
        .WithProvider("letsencrypt")
        .Build(),
    await client.Certificates.CreateBuilder()
        .WithDomainNames("site2.example.com")
        .WithEmail("admin@example.com")
        .WithProvider("letsencrypt")
        .Build()
};

foreach (var cert in certificates)
{
    var result = await client.Certificates.CreateAsync(cert);
    if (result.IsSuccess)
    {
        Console.WriteLine($"Created certificate with ID: {result.Data.Id}");
    }
    else
    {
        Console.WriteLine($"Failed to create certificate: {result.Error.Message}");
    }
}
``` 