using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class Auth : RouteBase
    {
        public Auth(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Test a login and password for validity.
        /// </summary>
        /// <param name="login">Username or email address.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="limit_ip">If true, rate limit based on IP address.</param>
        /// <returns></returns>
        public UserResponse Login(string login, string password, bool? limit_ip = null)
        {
            RestRequest request = CreateRequest("auth", Method.Post);
            AddParameter(request, "login", login);
            AddParameter(request, "password", password);
            AddParameter(request, "limit_ip", limit_ip);

            return Execute<UserResponse>(request);
        }

        /// <summary>
        /// Look up an active user from session data.
        /// </summary>
        /// <param name="session_id">The session ID to check.</param>
        /// <param name="remember_cookie">Remember-me cookie value associated with the session.</param>
        /// <returns></returns>
        public AuthFromSessionResponse FromSession(string session_id = null, string remember_cookie = null)
        {
            RestRequest request = CreateRequest("auth/from-session", Method.Post);
            AddParameter(request, "session_id", session_id);
            AddParameter(request, "remember_cookie", remember_cookie);

            return Execute<AuthFromSessionResponse>(request);
        }

        /// <summary>
        /// Create a login token for the specified user.
        /// </summary>
        /// <param name="user_id">User id.</param>
        /// <param name="limit_ip">If true, limit the token to the request IP.</param>
        /// <param name="return_url">Optional return URL.</param>
        /// <param name="force">If true, forces token creation.</param>
        /// <param name="remember">If true, creates a remembered login.</param>
        /// <returns></returns>
        public LoginTokenResponse CreateLoginToken(long user_id, bool? limit_ip = null, string return_url = null, bool? force = null, bool? remember = null)
        {
            RestRequest request = CreateRequest("auth/login-token", Method.Post);
            AddParameter(request, "user_id", user_id);
            AddParameter(request, "limit_ip", limit_ip);
            AddParameter(request, "return_url", return_url);
            AddParameter(request, "force", force);
            AddParameter(request, "remember", remember);

            return Execute<LoginTokenResponse>(request);
        }

        public class UserResponse
        {
            [JsonProperty("user")]
            public XfModels.User User;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AuthFromSessionResponse : SuccessResponse
        {
            [JsonProperty("user")]
            public XfModels.User User;
        }

        public class LoginTokenResponse
        {
            [JsonProperty("login_token")]
            public string LoginToken;

            [JsonProperty("login_url")]
            public string LoginUrl;

            [JsonProperty("expiry_date")]
            public long? ExpiryDate;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}
