using System.Net;
using System.Text.Json;
using NginxProxyManager.SDK.Models.Proxies;
using NginxProxyManager.SDK.Services;
using Xunit;

namespace NginxProxyManager.SDK.Tests;

public class ProxyHostServiceTests
{
    [Fact]
    public async Task CreateAsync_PostsToProxyHostsWithExpectedJsonFields()
    {
        var handler = new RecordingHttpMessageHandler(_ => JsonResponse("{\"id\":42}"));
        var service = new ProxyHostService(new HttpClient(handler) { BaseAddress = new Uri("https://npm.example/") });

        var result = await service.CreateAsync(new ProxyHostCreateRequest
        {
            DomainNames = new[] { "app.example.com" },
            ForwardHost = "10.0.0.10",
            ForwardPort = 8080,
            ForwardScheme = "http",
            CertificateId = 1,
            SslEnabled = true,
            AdvancedConfig = string.Empty
        });

        Assert.True(result.IsSuccess);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("https://npm.example/api/nginx/proxy-hosts", request.RequestUri!.ToString());

        using var body = JsonDocument.Parse(Assert.Single(handler.RequestBodies)!);
        Assert.True(body.RootElement.TryGetProperty("domain_names", out _));
        Assert.True(body.RootElement.TryGetProperty("forward_host", out _));
        Assert.True(body.RootElement.TryGetProperty("forward_port", out _));
        Assert.True(body.RootElement.TryGetProperty("forward_scheme", out _));
        Assert.True(body.RootElement.TryGetProperty("certificate_id", out _));
        Assert.True(body.RootElement.TryGetProperty("ssl_forced", out _));
    }

    [Fact]
    public async Task DeleteAsync_UsesProxyHostIdRoute()
    {
        var handler = new RecordingHttpMessageHandler(_ => JsonResponse("{}"));
        var service = new ProxyHostService(new HttpClient(handler) { BaseAddress = new Uri("https://npm.example/") });

        var result = await service.DeleteAsync(123);

        Assert.True(result.IsSuccess);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Delete, request.Method);
        Assert.Equal("https://npm.example/api/nginx/proxy-hosts/123", request.RequestUri!.ToString());
    }

    private static HttpResponseMessage JsonResponse(string json) => new(HttpStatusCode.OK)
    {
        Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
    };
}
