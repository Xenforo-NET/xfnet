using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Threads
    {
        public Task<ThreadsResponse> GetAllAsync(long? page = null, long? prefix_id = null, long? starter_id = null, long? last_days = null, bool? unread = null, string thread_type = null, string order = null, string direction = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "starter_id", starter_id);
            AddParameter(request, "last_days", last_days);
            AddParameter(request, "unread", unread);
            AddParameter(request, "thread_type", thread_type);
            AddParameter(request, "order", order);
            AddParameter(request, "direction", direction);

            return ExecuteAsync<ThreadsResponse>(request, cancellationToken);
        }

        public Task<ThreadResponse> CreateAsync(long node_id, string title, string message, string discussion_type = null, long? prefix_id = null, IEnumerable<string> tags = null, Dictionary<string, object> custom_fields = null, bool? discussion_open = null, bool? sticky = null, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads", Method.Post);
            AddParameter(request, "node_id", node_id);
            AddParameter(request, "title", title);
            AddParameter(request, "message", message);
            AddParameter(request, "discussion_type", discussion_type);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "tags", tags);
            AddDictionaryParameters(request, "custom_fields", custom_fields);
            AddParameter(request, "discussion_open", discussion_open);
            AddParameter(request, "sticky", sticky);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ThreadResponse>(request, cancellationToken);
        }

        public Task<ThreadWithPostsResponse> GetByIdAsync(long id, bool? with_posts = null, long? page = null, bool? with_first_post = null, bool? with_last_post = null, string order = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id, Method.Get);
            AddParameter(request, "with_posts", with_posts);
            AddParameter(request, "page", page);
            AddParameter(request, "with_first_post", with_first_post);
            AddParameter(request, "with_last_post", with_last_post);
            AddParameter(request, "order", order);

            return ExecuteAsync<ThreadWithPostsResponse>(request, cancellationToken);
        }

        public Task<ThreadResponse> UpdateByIdAsync(long id, long? prefix_id = null, string title = null, bool? discussion_open = null, bool? sticky = null, Dictionary<string, object> custom_fields = null, IEnumerable<string> add_tags = null, IEnumerable<string> remove_tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id, Method.Post);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "title", title);
            AddParameter(request, "discussion_open", discussion_open);
            AddParameter(request, "sticky", sticky);
            AddDictionaryParameters(request, "custom_fields", custom_fields);
            AddParameter(request, "add_tags", add_tags);
            AddParameter(request, "remove_tags", remove_tags);

            return ExecuteAsync<ThreadResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, bool? hard_delete = null, string reason = null, bool? starter_alert = null, string starter_alert_reason = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "starter_alert", starter_alert);
            AddParameter(request, "starter_alert_reason", starter_alert_reason);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ThreadResponse> ChangeTypeByIdAsync(long id, string new_thread_type_id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/change-type", Method.Post);
            AddParameter(request, "new_thread_type_id", new_thread_type_id);

            return ExecuteAsync<ThreadResponse>(request, cancellationToken);
        }

        public Task<FeatureResponse> FeatureByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/feature", Method.Post);
            return ExecuteAsync<FeatureResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> MarkReadByIdAsync(long id, long? date = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/mark-read", Method.Post);
            AddParameter(request, "date", date);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ThreadResponse> MoveByIdAsync(long id, long target_node_id, long? prefix_id = null, string title = null, bool? notify_watchers = null, bool? starter_alert = null, string starter_alert_reason = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/move", Method.Post);
            AddParameter(request, "target_node_id", target_node_id);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "title", title);
            AddParameter(request, "notify_watchers", notify_watchers);
            AddParameter(request, "starter_alert", starter_alert);
            AddParameter(request, "starter_alert_reason", starter_alert_reason);

            return ExecuteAsync<ThreadResponse>(request, cancellationToken);
        }

        public Task<ThreadPostsResponse> GetPostsByIdAsync(long id, long? page = null, string order = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/posts", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "order", order);

            return ExecuteAsync<ThreadPostsResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> UnfeatureByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/unfeature", Method.Post);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ActionResponse> VoteByIdAsync(long id, string type, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("threads/" + id + "/vote", Method.Post);
            AddParameter(request, "type", type);

            return ExecuteAsync<ActionResponse>(request, cancellationToken);
        }
    }
}
