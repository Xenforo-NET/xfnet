using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class OAuth2 : RouteBase
    {
        public OAuth2(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get information about an access token.
        /// </summary>
        /// <param name="client_id">OAuth client id.</param>
        /// <param name="client_secret">OAuth client secret.</param>
        /// <param name="token">Token to inspect.</param>
        /// <returns></returns>
        public TokenInfoResponse GetTokenInfo(string client_id, string client_secret, string token)
        {
            RestRequest request = CreateRequest("oauth2/token", Method.Get);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "token", token);

            return Execute<TokenInfoResponse>(request);
        }

        /// <summary>
        /// Create an OAuth access token.
        /// </summary>
        /// <param name="client_id">OAuth client id.</param>
        /// <param name="client_secret">OAuth client secret.</param>
        /// <param name="grant_type">Grant type.</param>
        /// <param name="code">Authorization code.</param>
        /// <param name="refresh_token">Refresh token.</param>
        /// <param name="code_verifier">PKCE code verifier.</param>
        /// <param name="redirect_uri">Redirect URI.</param>
        /// <returns></returns>
        public CreateTokenResponse CreateToken(string client_id, string client_secret, string grant_type, string code = null, string refresh_token = null, string code_verifier = null, string redirect_uri = null)
        {
            RestRequest request = CreateRequest("oauth2/token", Method.Post);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "grant_type", grant_type);
            AddParameter(request, "code", code);
            AddParameter(request, "refresh_token", refresh_token);
            AddParameter(request, "code_verifier", code_verifier);
            AddParameter(request, "redirect_uri", redirect_uri);

            return Execute<CreateTokenResponse>(request);
        }

        /// <summary>
        /// Introspects an OAuth token.
        /// </summary>
        /// <param name="client_id">OAuth client id.</param>
        /// <param name="client_secret">OAuth client secret.</param>
        /// <param name="token">Token to introspect.</param>
        /// <param name="token_type_hint">Optional token type hint.</param>
        /// <returns></returns>
        public IntrospectResponse Introspect(string client_id, string client_secret, string token, string token_type_hint = null)
        {
            RestRequest request = CreateRequest("oauth2/introspect", Method.Post);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "token", token);
            AddParameter(request, "token_type_hint", token_type_hint);

            return Execute<IntrospectResponse>(request);
        }

        /// <summary>
        /// Revokes an OAuth token.
        /// </summary>
        /// <param name="client_id">OAuth client id.</param>
        /// <param name="client_secret">OAuth client secret.</param>
        /// <param name="token">Token to revoke.</param>
        /// <param name="token_type_hint">Optional token type hint.</param>
        /// <returns></returns>
        public SuccessResponse Revoke(string client_id, string client_secret, string token, string token_type_hint = null)
        {
            RestRequest request = CreateRequest("oauth2/revoke", Method.Post);
            AddParameter(request, "client_id", client_id);
            AddParameter(request, "client_secret", client_secret);
            AddParameter(request, "token", token);
            AddParameter(request, "token_type_hint", token_type_hint);

            return Execute<SuccessResponse>(request);
        }

        public class TokenInfoResponse
        {
            [JsonProperty("user_id")]
            public long? UserId;

            [JsonProperty("scope")]
            public string Scope;

            [JsonProperty("expires_in")]
            public long? ExpiresIn;

            [JsonProperty("issue_date")]
            public long? IssueDate;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class CreateTokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken;

            [JsonProperty("refresh_token")]
            public string RefreshToken;

            [JsonProperty("token_type")]
            public string TokenType;

            [JsonProperty("expires_in")]
            public long? ExpiresIn;

            [JsonProperty("scope")]
            public string Scope;

            [JsonProperty("issue_date")]
            public long? IssueDate;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class IntrospectResponse
        {
            [JsonProperty("active")]
            public bool? Active;

            [JsonProperty("scope")]
            public string Scope;

            [JsonProperty("client_id")]
            public string ClientId;

            [JsonProperty("username")]
            public string Username;

            [JsonProperty("token_type")]
            public string TokenType;

            [JsonProperty("exp")]
            public long? Exp;

            [JsonProperty("iat")]
            public long? Iat;

            [JsonProperty("sub")]
            public string Sub;

            [JsonProperty("iss")]
            public string Iss;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

