using System;
using XenForoSharp;

namespace XenForoSharp.examples
{
    internal static class UserAuth
    {
        public static void Run()
        {
            XenforoApi api = new XenforoApi(
                xfToken: "YOUR_API_KEY",
                isVerbose: true,
                baseUrl: "https://community.example.com");

            var login = api.Auth.Login(
                login: "user@example.com",
                password: "USER_PASSWORD");

            if (login.Errors != null && login.Errors.Count > 0)
            {
                foreach (var error in login.Errors)
                    Console.WriteLine(error.Message);

                return;
            }

            Console.WriteLine(login.User.Username);

            var loginToken = api.Auth.CreateLoginToken(
                user_id: login.User.UserId.Value,
                remember: true,
                return_url: "https://community.example.com/account/");

            Console.WriteLine(loginToken.LoginUrl);

            var fromSession = api.Auth.FromSession(
                session_id: "SESSION_ID",
                remember_cookie: "REMEMBER_COOKIE");

            Console.WriteLine(fromSession.User != null ? fromSession.User.Username : "No active session");
        }
    }
}

