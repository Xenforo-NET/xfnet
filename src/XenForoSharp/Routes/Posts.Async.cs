using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Posts
    {
        public Task<PostResponse> CreateAsync(long thread_id, string message, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts", Method.Post);
            AddParameter(request, "thread_id", thread_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<PostResponse>(request, cancellationToken);
        }

        public Task<PostItemResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts/" + id, Method.Get);
            return ExecuteAsync<PostItemResponse>(request, cancellationToken);
        }

        public Task<PostResponse> UpdateByIdAsync(long id, string message = null, bool? silent = null, bool? clear_edit = null, bool? author_alert = null, string author_alert_reason = null, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "silent", silent);
            AddParameter(request, "clear_edit", clear_edit);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<PostResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, bool? hard_delete = null, string reason = null, bool? author_alert = null, string author_alert_reason = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<MarkSolutionResponse> MarkSolutionByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts/" + id + "/mark-solution", Method.Post);
            return ExecuteAsync<MarkSolutionResponse>(request, cancellationToken);
        }

        public Task<ActionResponse> ReactByIdAsync(long id, long? reaction_id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return ExecuteAsync<ActionResponse>(request, cancellationToken);
        }

        public Task<ActionResponse> VoteByIdAsync(long id, string type, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("posts/" + id + "/vote", Method.Post);
            AddParameter(request, "type", type);

            return ExecuteAsync<ActionResponse>(request, cancellationToken);
        }
    }
}
