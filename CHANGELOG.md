# Changelog

## 1.0.0
- Reworked the client into a proper route-based XenForo API library
- Covered main endpoints: auth, users, threads, posts, conversations, search, nodes, forums, stats and everything around them
- Fixed model deserialization and removed stale fields
- Added NuGet metadata, usage examples and release docs

## 1.0.1
- Added asynchrony. Async methods use the `Async` suffix and accept an optional `CancellationToken`.
