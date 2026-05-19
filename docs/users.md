# Users

The users resource covers Nginx Proxy Manager's `/api/users` endpoints.

```csharp
var users = await client.Users.GetAllAsync();
var user = await client.Users.CreateAsync(new UserCreateRequest
{
    Email = "ops@example.com",
    Name = "Ops User",
    Nickname = "ops",
    Roles = new[] { "admin" }
});
```

Supported operations: list, get by ID, create, update, update password, and delete.
