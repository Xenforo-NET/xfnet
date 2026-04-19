using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Me
    {
        public Task<MeResponse> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("me", Method.Get);
            return ExecuteAsync<MeResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> UpdateAsync(Dictionary<string, object> options = null, Dictionary<string, object> profile = null, Dictionary<string, object> privacy = null, bool? visible = null, bool? activity_visible = null, string timezone = null, string custom_title = null, Dictionary<string, object> custom_fields = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("me", Method.Post);
            AddDictionaryParameters(request, "option", options);
            AddDictionaryParameters(request, "profile", profile);
            AddDictionaryParameters(request, "privacy", privacy);
            AddParameter(request, "visible", visible);
            AddParameter(request, "activity_visible", activity_visible);
            AddParameter(request, "timezone", timezone);
            AddParameter(request, "custom_title", custom_title);
            AddDictionaryParameters(request, "custom_fields", custom_fields);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> UploadAvatarAsync(byte[] avatar_bytes, string file_name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("me/avatar", Method.Post);
            AddFile(request, "avatar", avatar_bytes, file_name);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteAvatarAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("me/avatar", Method.Delete);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ChangeEmailResponse> UpdateEmailAsync(string current_password, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("me/email", Method.Post);
            AddParameter(request, "current_password", current_password);
            AddParameter(request, "email", email);

            return ExecuteAsync<ChangeEmailResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> UpdatePasswordAsync(string current_password, string new_password, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("me/password", Method.Post);
            AddParameter(request, "current_password", current_password);
            AddParameter(request, "new_password", new_password);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }
    }
}
