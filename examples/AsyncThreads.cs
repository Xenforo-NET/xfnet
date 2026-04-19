using System;
using System.Threading;
using System.Threading.Tasks;
using XenForoSharp;

namespace XenForoSharp.examples
{
    internal static class AsyncThreads
    {
        public static async Task RunAsync(CancellationToken cancellationToken = default)
        {
            XenforoApi api = new XenforoApi(
                xfToken: "YOUR_API_KEY",
                isVerbose: true,
                baseUrl: "https://community.example.com");

            var created = await api.Threads.CreateAsync(
                node_id: 2,
                title: "Async API thread",
                message: "Created from XenForoSharp asynchronously",
                cancellationToken: cancellationToken);

            Console.WriteLine(created.Thread.ThreadId);

            var thread = await api.Threads.GetByIdAsync(
                created.Thread.ThreadId.Value,
                with_posts: true,
                page: 1,
                cancellationToken: cancellationToken);

            Console.WriteLine(thread.Thread.Title);

            var reply = await api.Posts.CreateAsync(
                thread_id: created.Thread.ThreadId.Value,
                message: "Async reply from XenForoSharp",
                cancellationToken: cancellationToken);

            Console.WriteLine(reply.Post.PostId);
        }
    }
}
