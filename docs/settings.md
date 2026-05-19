# Settings

The settings resource covers Nginx Proxy Manager's `/api/settings` endpoints.

```csharp
var settings = await client.Settings.GetAllAsync();
var defaultSite = await client.Settings.GetByIdAsync("default-site");
await client.Settings.UpdateAsync("default-site", new SettingUpdateRequest { Value = "disabled" });
```

Supported operations: list, get by ID, and update.
