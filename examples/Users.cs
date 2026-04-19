using System;
using System.Collections.Generic;
using xfnet;

namespace xfnet.examples
{
    internal static class Users
    {
        public static void Run()
        {
            XenforoApi api = new XenforoApi(
                xfToken: "YOUR_API_KEY",
                isVerbose: true,
                baseUrl: "https://community.example.com");

            var users = api.Users.GetAll(page: 1);
            foreach (var user in users.Users)
                Console.WriteLine(user.Username);

            var foundByName = api.Users.FindByName("adm");
            Console.WriteLine(foundByName.Exact != null ? foundByName.Exact.Username : "No exact match");

            var foundByEmail = api.Users.FindByEmail("user@example.com");
            Console.WriteLine(foundByEmail.User.Username);

            api.Me.Update(
                profile: new Dictionary<string, object>
                {
                    { "location", "Moscow" },
                    { "website", "https://example.com" }
                });
        }
    }
}
