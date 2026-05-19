using System.Net;
using System.Text.Json;
using NginxProxyManager.SDK.Models.Settings;
using NginxProxyManager.SDK.Models.Users;
using NginxProxyManager.SDK.Services;
using Xunit;

namespace NginxProxyManager.SDK.Tests;

public class UserAndSettingsServiceTests
{
    [Fact]
    public async Task Users_GetAll_UsesApiUsersRoute()
    {
        var handler = new RecordingHttpMessageHandler(_ => JsonResponse("[]"));
        var service = new UserService(new HttpClient(handler) { BaseAddress = new Uri("https://npm.example/") });
        var result = await service.GetAllAsync();
        Assert.True(result.IsSuccess);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Get, request.Method);
        Assert.Equal("https://npm.example/api/users", request.RequestUri!.ToString());
    }

    [Fact]
    public async Task Users_Create_SerializesRolesAndDisabledState()
    {
        var handler = new RecordingHttpMessageHandler(_ => JsonResponse("{\"id\":5}"));
        var service = new UserService(new HttpClient(handler) { BaseAddress = new Uri("https://npm.example/") });
        var result = await service.CreateAsync(new UserCreateRequest { Email = "ops@example.com", Name = "Ops", Nickname = "ops", Roles = new[] { "admin" }, IsDisabled = true });
        Assert.True(result.IsSuccess);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("https://npm.example/api/users", request.RequestUri!.ToString());
        using var body = JsonDocument.Parse(Assert.Single(handler.RequestBodies)!);
        Assert.Equal("ops@example.com", body.RootElement.GetProperty("email").GetString());
        Assert.Equal("admin", body.RootElement.GetProperty("roles")[0].GetString());
        Assert.True(body.RootElement.GetProperty("is_disabled").GetBoolean());
    }

    [Fact]
    public async Task Users_UpdatePassword_UsesAuthRoute()
    {
        var handler = new RecordingHttpMessageHandler(_ => JsonResponse("{}"));
        var service = new UserService(new HttpClient(handler) { BaseAddress = new Uri("https://npm.example/") });
        var result = await service.UpdatePasswordAsync(7, new UserPasswordUpdateRequest { Secret = "new-password" });
        Assert.True(result.IsSuccess);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Put, request.Method);
        Assert.Equal("https://npm.example/api/users/7/auth", request.RequestUri!.ToString());
    }

    [Fact]
    public async Task Settings_Update_EscapesSettingIdAndSerializesValue()
    {
        var handler = new RecordingHttpMessageHandler(_ => JsonResponse("{\"id\":\"default-site\",\"value\":\"disabled\"}"));
        var service = new SettingsService(new HttpClient(handler) { BaseAddress = new Uri("https://npm.example/") });
        var result = await service.UpdateAsync("default/site", new SettingUpdateRequest { Value = "disabled" });
        Assert.True(result.IsSuccess);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Put, request.Method);
        Assert.Equal("https://npm.example/api/settings/default%2Fsite", request.RequestUri!.ToString());
        using var body = JsonDocument.Parse(Assert.Single(handler.RequestBodies)!);
        Assert.Equal("disabled", body.RootElement.GetProperty("value").GetString());
    }

    private static HttpResponseMessage JsonResponse(string json) => new(HttpStatusCode.OK)
    {
        Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
    };
}
