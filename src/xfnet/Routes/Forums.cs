using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class Forums : RouteBase
    {
        public Forums(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Gets information about the specified forum.
        /// </summary>
        /// <param name="id">Forum id.</param>
        /// <param name="with_threads">If true, includes threads from the forum.</param>
        /// <param name="page"></param>
        /// <param name="prefix_id">Optional prefix filter.</param>
        /// <param name="starter_id">Optional starter filter.</param>
        /// <param name="last_days">Optional number of days to limit by.</param>
        /// <param name="unread">If true, only unread threads are returned.</param>
        /// <param name="thread_type">Optional thread type filter.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="direction">Sort direction.</param>
        /// <returns></returns>
        public ForumResponse GetById(long id, bool? with_threads = null, long? page = null, long? prefix_id = null, long? starter_id = null, long? last_days = null, bool? unread = null, string thread_type = null, string order = null, string direction = null)
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

            return Execute<ForumResponse>(request);
        }

        /// <summary>
        /// Marks the specified forum as read.
        /// </summary>
        /// <param name="id">Forum id.</param>
        /// <param name="date">Unix timestamp to mark as read through.</param>
        /// <returns></returns>
        public SuccessResponse MarkReadById(long id, long? date = null)
        {
            RestRequest request = CreateRequest("forums/" + id + "/mark-read", Method.Post);
            AddParameter(request, "date", date);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Gets a page of threads from the specified forum.
        /// </summary>
        /// <param name="id">Forum id.</param>
        /// <param name="page"></param>
        /// <param name="prefix_id">Optional prefix filter.</param>
        /// <param name="starter_id">Optional starter filter.</param>
        /// <param name="last_days">Optional number of days to limit by.</param>
        /// <param name="unread">If true, only unread threads are returned.</param>
        /// <param name="thread_type">Optional thread type filter.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="direction">Sort direction.</param>
        /// <returns></returns>
        public ThreadsResponse GetThreadsById(long id, long? page = null, long? prefix_id = null, long? starter_id = null, long? last_days = null, bool? unread = null, string thread_type = null, string order = null, string direction = null)
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

            return Execute<ThreadsResponse>(request);
        }

        public class ForumResponse
        {
            [JsonProperty("forum")]
            public XfModels.Node Forum;

            [JsonProperty("threads")]
            public List<XfModels.Thread> Threads;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("sticky")]
            public List<XfModels.Thread> Sticky;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ThreadsResponse
        {
            [JsonProperty("threads")]
            public List<XfModels.Thread> Threads;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("sticky")]
            public List<XfModels.Thread> Sticky;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}
