using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Auth
    {
        public Task<UserResponse> LoginAsync(string login, string password, bool? limit_ip = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("auth", Method.Post);
            AddParameter(request, "login", login);
            AddParameter(request, "password", password);
            AddParameter(request, "limit_ip", limit_ip);

            return ExecuteAsync<UserResponse>(request, cancellationToken);
        }

        public Task<AuthFromSessionResponse> FromSessionAsync(string session_id = null, string remember_cookie = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("auth/from-session", Method.Post);
            AddParameter(request, "session_id", session_id);
            AddParameter(request, "remember_cookie", remember_cookie);

            return ExecuteAsync<AuthFromSessionResponse>(request, cancellationToken);
        }

        public Task<LoginTokenResponse> CreateLoginTokenAsync(long user_id, bool? limit_ip = null, string return_url = null, bool? force = null, bool? remember = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("auth/login-token", Method.Post);
            AddParameter(request, "user_id", user_id);
            AddParameter(request, "limit_ip", limit_ip);
            AddParameter(request, "return_url", return_url);
            AddParameter(request, "force", force);
            AddParameter(request, "remember", remember);

            return ExecuteAsync<LoginTokenResponse>(request, cancellationToken);
        }
    }
}
