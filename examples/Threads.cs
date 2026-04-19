using System;
using XenForoSharp;

namespace XenForoSharp.examples
{
    internal static class Threads
    {
        public static void Run()
        {
            XenforoApi api = new XenforoApi(
                xfToken: "YOUR_API_KEY",
                isVerbose: true,
                baseUrl: "https://community.example.com");

            var created = api.Threads.Create(
                node_id: 2,
                title: "API thread",
                message: "Created from XenForoSharp");

            Console.WriteLine(created.Thread.ThreadId);

            var thread = api.Threads.GetById(created.Thread.ThreadId.Value, with_posts: true, page: 1);
            Console.WriteLine(thread.Thread.Title);

            var reply = api.Posts.Create(
                thread_id: created.Thread.ThreadId.Value,
                message: "Reply from XenForoSharp");

            Console.WriteLine(reply.Post.PostId);
        }
    }
}

