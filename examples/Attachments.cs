using System.IO;
using xfnet;

namespace xfnet.examples
{
    internal static class Attachments
    {
        public static void Run()
        {
            XenforoApi api = new XenforoApi(
                xfToken: "YOUR_API_KEY",
                isVerbose: true,
                baseUrl: "https://community.example.com");

            byte[] bytes = File.ReadAllBytes(@"C:\temp\image.png");

            var key = api.Attachments.CreateNewKey(
                type: "post",
                context: null);

            api.Attachments.Upload(
                attachment_key: key.Key,
                file_bytes: bytes,
                file_name: "image.png");

            api.Posts.Create(
                thread_id: 15,
                message: "Post with attachment",
                attachment_key: key.Key);
        }
    }
}
