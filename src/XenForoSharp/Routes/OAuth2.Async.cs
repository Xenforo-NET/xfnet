using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class OAuth2
    {
        public Task<TokenInfoResponse> GetTokenInfoAsync(string client_id, string client_secret, string token, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("oauth2/token", Method.Get);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "token", token);

            return ExecuteAsync<TokenInfoResponse>(request, cancellationToken);
        }

        public Task<CreateTokenResponse> CreateTokenAsync(string client_id, string client_secret, string grant_type, string code = null, string refresh_token = null, string code_verifier = null, string redirect_uri = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("oauth2/token", Method.Post);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "grant_type", grant_type);
            AddParameter(request, "code", code);
            AddParameter(request, "refresh_token", refresh_token);
            AddParameter(request, "code_verifier", code_verifier);
            AddParameter(request, "redirect_uri", redirect_uri);

            return ExecuteAsync<CreateTokenResponse>(request, cancellationToken);
        }

        public Task<IntrospectResponse> IntrospectAsync(string client_id, string client_secret, string token, string token_type_hint = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("oauth2/introspect", Method.Post);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "token", token);
            AddParameter(request, "token_type_hint", token_type_hint);

            return ExecuteAsync<IntrospectResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> RevokeAsync(string client_id, string client_secret, string token, string token_type_hint = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("oauth2/revoke", Method.Post);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "token", token);
            AddParameter(request, "token_type_hint", token_type_hint);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }
    }
}
