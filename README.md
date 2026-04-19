# xfnet

[![Build](https://github.com/Xenforo-NET/xfnet/actions/workflows/ci.yml/badge.svg)](https://github.com/Xenforo-NET/xfnet/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

Typed XenForo REST API client for .NET Framework 4.8.

---

## What is this?

`xfnet` wraps the XenForo REST API in a clean, route-based client with strongly typed models. No stringly-typed nonsense - just call the route, get a model back, move on.

---

## Getting Started

### Add to your project

```xml
<ProjectReference Include="src\xfnet\xfnet.csproj" />
```

### Build from source

```powershell
& "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" src\xfnet.sln /t:Build /p:Configuration=Release
```

---

## Usage

```csharp
var api = new XenforoApi(
    xfToken: "YOUR_API_KEY",
    baseUrl: "https://community.example.com",
    isVerbose: true);

// Site info
var index = api.Index.Get();
Console.WriteLine(index.SiteTitle);

// Current user
var me = api.Me.Get();
Console.WriteLine(me.Me.Username);

// Latest threads
var threads = api.Threads.GetAll(page: 1, order: "post_date", direction: "desc");
foreach (var thread in threads.Threads)
    Console.WriteLine(thread.Title);
```

The base URL is normalized automatically - any of these will work:

```
https://community.example.com
https://community.example.com/api
https://community.example.com/api/
```

---

## API Coverage

All core XenForo REST endpoints are wrapped:

`Alerts` · `Attachments` · `Auth` · `ConversationMessages` · `Conversations` · `Featured` · `Forums` · `Index` · `Me` · `Nodes` · `OAuth2` · `OEmbed` · `Posts` · `ProfilePostComments` · `ProfilePosts` · `Search` · `SearchForums` · `Stats` · `Threads` · `Users`

Not yet supported: XenForo Media Gallery (`media*`) and Resource Manager (`resource*`). Pull requests are welcome.

---

## Examples

See [examples/README.md](examples/README.md) for runnable examples:

- [UserAuth.cs](examples/UserAuth.cs) - API key auth flow
- [Threads.cs](examples/Threads.cs) - reading and creating threads
- [Attachments.cs](examples/Attachments.cs) - uploading files and fetching thumbnails
- [Users.cs](examples/Users.cs) - user lookup and profile data

---

## NuGet Package

```powershell
# Bump version across the project
.\build\set-version.ps1 -Version 1.0.0

# Build and pack
.\build\pack.ps1 -Configuration Release -Version 1.0.0
```

Output goes to `artifacts`. Publishing is manual, there's no automatic push from CI.

See [RELEASING.md](RELEASING.md) for the full release process.

---

## Notes

- The client is currently synchronous.
- XML docs are generated on build, so IntelliSense works out of the box.
- NuGet metadata lives in [src/xfnet/xfnet.nuspec](src/xfnet/xfnet.nuspec).

---

## License

[MIT](LICENSE)
```
