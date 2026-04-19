using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Forums
    {
        public Task<ForumResponse> GetByIdAsync(long id, bool? with_threads = null, long? page = null, long? prefix_id = null, long? starter_id = null, long? last_days = null, bool? unread = null, string thread_type = null, string order = null, string direction = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("forums/" + id, Method.Get);
            AddParameter(request, "with_threads", with_threads);
            AddParameter(request, "page", page);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "starter_id", starter_id);
            AddParameter(request, "last_days", last_days);
            AddParameter(request, "unread", unread);
            AddParameter(request, "thread_type", thread_type);
            AddParameter(request, "order", order);
            AddParameter(request, "direction", direction);

            return ExecuteAsync<ForumResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> MarkReadByIdAsync(long id, long? date = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("forums/" + id + "/mark-read", Method.Post);
            AddParameter(request, "date", date);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ThreadsResponse> GetThreadsByIdAsync(long id, long? page = null, long? prefix_id = null, long? starter_id = null, long? last_days = null, bool? unread = null, string thread_type = null, string order = null, string direction = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("forums/" + id + "/threads", Method.Get);
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
    }
}
