using System.Net;
using NginxProxyManager.SDK.Client;
using NginxProxyManager.SDK.Services.Interfaces;
using Xunit;

namespace NginxProxyManager.SDK.Tests;

public class AuthenticationHandlerTests
{
    [Fact]
    public async Task SendAsync_AfterUnauthorizedRefreshesTokenAndRetriesWithClonedContent()
    {
        var terminal = new RecordingHttpMessageHandler(
            req => new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("nope") },
            req => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") });
        var auth = new SequenceAuthService("stale-token", "fresh-token");
        var client = new HttpClient(new AuthenticationHandler(auth, new AuthenticationCredentials("admin@example.com", "secret"))
        {
            InnerHandler = terminal
        })
        {
            BaseAddress = new Uri("https://npm.example/")
        };

        using var response = await client.PostAsync("api/nginx/proxy-hosts", new StringContent("{\"hello\":\"world\"}"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(2, terminal.Requests.Count);
        Assert.Equal("Bearer", terminal.Requests[0].Headers.Authorization!.Scheme);
        Assert.Equal("stale-token", terminal.Requests[0].Headers.Authorization!.Parameter);
        Assert.Equal("fresh-token", terminal.Requests[1].Headers.Authorization!.Parameter);
        Assert.Equal("{\"hello\":\"world\"}", terminal.RequestBodies[0]);
        Assert.Equal("{\"hello\":\"world\"}", terminal.RequestBodies[1]);
        Assert.Equal(2, auth.GetValidTokenCallCount);
    }

    private sealed class SequenceAuthService : IAuthService
    {
        private readonly Queue<string> _tokens;
        public int GetValidTokenCallCount { get; private set; }

        public SequenceAuthService(params string[] tokens) => _tokens = new Queue<string>(tokens);
        public Task<string> AuthenticateAsync(AuthenticationCredentials credentials) => GetValidTokenAsync(credentials);
        public Task<string> GetValidTokenAsync(AuthenticationCredentials credentials)
        {
            GetValidTokenCallCount++;
            return Task.FromResult(_tokens.Dequeue());
        }
    }
}
