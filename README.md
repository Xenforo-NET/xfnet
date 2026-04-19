# XenForoSharp

[![Build](https://github.com/XenForoSharp/XenForoSharp/actions/workflows/ci.yml/badge.svg)](https://github.com/XenForoSharp/XenForoSharp/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/XenForoSharp.svg)](https://www.nuget.org/packages/XenForoSharp/)
[![License: MIT](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

Typed XenForo REST API client for .NET Framework 4.8.

---

## What is this?

`XenForoSharp` wraps the XenForo REST API in a clean, route-based client with strongly typed models. No stringly-typed nonsense - just call the route, get a model back, move on.

---

## Getting Started

### Install from NuGet

Package page: [XenForoSharp on NuGet](https://www.nuget.org/packages/XenForoSharp/)

```xml
<PackageReference Include="XenForoSharp" Version="1.0.1" />
```

```powershell
Install-Package XenForoSharp
```

If you're using the repository directly:

### Add as a project reference

```xml
<ProjectReference Include="src\XenForoSharp\XenForoSharp.csproj" />
```

### Build from source

```powershell
& "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" src\XenForoSharp.sln /t:Build /p:Configuration=Release
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

Async variants are available for the same routes via the `Async` suffix, for example `await api.Threads.GetAllAsync(...)`.

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
- [AsyncThreads.cs](examples/AsyncThreads.cs) - async threads and posts with CancellationToken
- [Attachments.cs](examples/Attachments.cs) - uploading files and fetching thumbnails
- [Users.cs](examples/Users.cs) - user lookup and profile data

---

## Notes

- Sync and async route methods are both available.
- Async methods use the `Async` suffix and accept an optional `CancellationToken`.
- XML docs are generated on build, so IntelliSense works out of the box.

---

## License
[MIT](LICENSE)
