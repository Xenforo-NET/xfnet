using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class ProfilePostComments
    {
        public Task<ProfilePostCommentResponse> CreateAsync(long profile_post_id, string message, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-post-comments", Method.Post);
            AddParameter(request, "profile_post_id", profile_post_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ProfilePostCommentResponse>(request, cancellationToken);
        }

        public Task<ProfilePostCommentItemResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id, Method.Get);
            return ExecuteAsync<ProfilePostCommentItemResponse>(request, cancellationToken);
        }

        public Task<ProfilePostCommentResponse> UpdateByIdAsync(long id, string message = null, bool? author_alert = null, string author_alert_reason = null, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ProfilePostCommentResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, bool? hard_delete = null, string reason = null, bool? author_alert = null, string author_alert_reason = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ActionResponse> ReactByIdAsync(long id, long? reaction_id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return ExecuteAsync<ActionResponse>(request, cancellationToken);
        }
    }
}
