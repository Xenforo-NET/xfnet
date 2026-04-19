using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class ProfilePosts
    {
        public Task<ProfilePostResponse> CreateAsync(long user_id, string message, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-posts", Method.Post);
            AddParameter(request, "user_id", user_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ProfilePostResponse>(request, cancellationToken);
        }

        public Task<ProfilePostWithCommentsResponse> GetByIdAsync(long id, bool? with_comments = null, long? page = null, string direction = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-posts/" + id, Method.Get);
            AddParameter(request, "with_comments", with_comments);
            AddParameter(request, "page", page);
            AddParameter(request, "direction", direction);

            return ExecuteAsync<ProfilePostWithCommentsResponse>(request, cancellationToken);
        }

        public Task<ProfilePostResponse> UpdateByIdAsync(long id, string message = null, bool? author_alert = null, string author_alert_reason = null, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-posts/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ProfilePostResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, bool? hard_delete = null, string reason = null, bool? author_alert = null, string author_alert_reason = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-posts/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<CommentsResponse> GetCommentsByIdAsync(long id, long? page = null, string direction = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-posts/" + id + "/comments", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "direction", direction);

            return ExecuteAsync<CommentsResponse>(request, cancellationToken);
        }

        public Task<ActionResponse> ReactByIdAsync(long id, long? reaction_id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("profile-posts/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return ExecuteAsync<ActionResponse>(request, cancellationToken);
        }
    }
}
