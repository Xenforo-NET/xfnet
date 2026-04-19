using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class Threads : RouteBase
    {
        public Threads(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get a list of threads.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="prefix_id">Optional prefix filter.</param>
        /// <param name="starter_id">Optional starter filter.</param>
        /// <param name="last_days">Optional number of days to limit by.</param>
        /// <param name="unread">If true, only unread threads are returned.</param>
        /// <param name="thread_type">Optional thread type filter.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="direction">Sort direction.</param>
        /// <returns></returns>
        public ThreadsResponse GetAll(long? page = null, long? prefix_id = null, long? starter_id = null, long? last_days = null, bool? unread = null, string thread_type = null, string order = null, string direction = null)
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

            return Execute<ThreadsResponse>(request);
        }

        /// <summary>
        /// Create a thread.
        /// </summary>
        /// <param name="node_id">Forum node id.</param>
        /// <param name="title">Thread title.</param>
        /// <param name="message">Thread message.</param>
        /// <param name="discussion_type">Thread type.</param>
        /// <param name="prefix_id">Prefix id.</param>
        /// <param name="tags">List of tags.</param>
        /// <param name="custom_fields">Map of custom field values.</param>
        /// <param name="discussion_open">If true, thread remains open.</param>
        /// <param name="sticky">If true, thread is sticky.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ThreadResponse Create(long node_id, string title, string message, string discussion_type = null, long? prefix_id = null, IEnumerable<string> tags = null, Dictionary<string, object> custom_fields = null, bool? discussion_open = null, bool? sticky = null, string attachment_key = null)
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

            return Execute<ThreadResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="with_posts">If true, includes posts.</param>
        /// <param name="page"></param>
        /// <param name="with_first_post">If true, includes the first post.</param>
        /// <param name="with_last_post">If true, includes the last post.</param>
        /// <param name="order">Sort order for posts.</param>
        /// <returns></returns>
        public ThreadWithPostsResponse GetById(long id, bool? with_posts = null, long? page = null, bool? with_first_post = null, bool? with_last_post = null, string order = null)
        {
            RestRequest request = CreateRequest("threads/" + id, Method.Get);
            AddParameter(request, "with_posts", with_posts);
            AddParameter(request, "page", page);
            AddParameter(request, "with_first_post", with_first_post);
            AddParameter(request, "with_last_post", with_last_post);
            AddParameter(request, "order", order);

            return Execute<ThreadWithPostsResponse>(request);
        }

        /// <summary>
        /// Updates the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="prefix_id">Prefix id.</param>
        /// <param name="title">Thread title.</param>
        /// <param name="discussion_open">If true, thread remains open.</param>
        /// <param name="sticky">If true, thread is sticky.</param>
        /// <param name="custom_fields">Map of custom field values.</param>
        /// <param name="add_tags">Tags to add.</param>
        /// <param name="remove_tags">Tags to remove.</param>
        /// <returns></returns>
        public ThreadResponse UpdateById(long id, long? prefix_id = null, string title = null, bool? discussion_open = null, bool? sticky = null, Dictionary<string, object> custom_fields = null, IEnumerable<string> add_tags = null, IEnumerable<string> remove_tags = null)
        {
            RestRequest request = CreateRequest("threads/" + id, Method.Post);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "title", title);
            AddParameter(request, "discussion_open", discussion_open);
            AddParameter(request, "sticky", sticky);
            AddDictionaryParameters(request, "custom_fields", custom_fields);
            AddParameter(request, "add_tags", add_tags);
            AddParameter(request, "remove_tags", remove_tags);

            return Execute<ThreadResponse>(request);
        }

        /// <summary>
        /// Deletes the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="hard_delete">If true, hard deletes the thread.</param>
        /// <param name="reason">Deletion reason.</param>
        /// <param name="starter_alert">If true, alerts the starter.</param>
        /// <param name="starter_alert_reason">Reason to include in the starter alert.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, bool? hard_delete = null, string reason = null, bool? starter_alert = null, string starter_alert_reason = null)
        {
            RestRequest request = CreateRequest("threads/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "starter_alert", starter_alert);
            AddParameter(request, "starter_alert_reason", starter_alert_reason);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Changes the specified thread's type.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="new_thread_type_id">New thread type id.</param>
        /// <returns></returns>
        public ThreadResponse ChangeTypeById(long id, string new_thread_type_id)
        {
            RestRequest request = CreateRequest("threads/" + id + "/change-type", Method.Post);
            AddParameter(request, "new_thread_type_id", new_thread_type_id);

            return Execute<ThreadResponse>(request);
        }

        /// <summary>
        /// Features the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <returns></returns>
        public FeatureResponse FeatureById(long id)
        {
            RestRequest request = CreateRequest("threads/" + id + "/feature", Method.Post);
            return Execute<FeatureResponse>(request);
        }

        /// <summary>
        /// Marks the specified thread as read.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="date">Unix timestamp to mark as read through.</param>
        /// <returns></returns>
        public SuccessResponse MarkReadById(long id, long? date = null)
        {
            RestRequest request = CreateRequest("threads/" + id + "/mark-read", Method.Post);
            AddParameter(request, "date", date);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Moves the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="target_node_id">Target forum node id.</param>
        /// <param name="prefix_id">Prefix id.</param>
        /// <param name="title">Thread title.</param>
        /// <param name="notify_watchers">If true, notifies watchers.</param>
        /// <param name="starter_alert">If true, alerts the starter.</param>
        /// <param name="starter_alert_reason">Reason to include in the starter alert.</param>
        /// <returns></returns>
        public ThreadResponse MoveById(long id, long target_node_id, long? prefix_id = null, string title = null, bool? notify_watchers = null, bool? starter_alert = null, string starter_alert_reason = null)
        {
            RestRequest request = CreateRequest("threads/" + id + "/move", Method.Post);
            AddParameter(request, "target_node_id", target_node_id);
            AddParameter(request, "prefix_id", prefix_id);
            AddParameter(request, "title", title);
            AddParameter(request, "notify_watchers", notify_watchers);
            AddParameter(request, "starter_alert", starter_alert);
            AddParameter(request, "starter_alert_reason", starter_alert_reason);

            return Execute<ThreadResponse>(request);
        }

        /// <summary>
        /// Gets posts for the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="page"></param>
        /// <param name="order">Sort order for posts.</param>
        /// <returns></returns>
        public ThreadPostsResponse GetPostsById(long id, long? page = null, string order = null)
        {
            RestRequest request = CreateRequest("threads/" + id + "/posts", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "order", order);

            return Execute<ThreadPostsResponse>(request);
        }

        /// <summary>
        /// Unfeatures the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <returns></returns>
        public SuccessResponse UnfeatureById(long id)
        {
            RestRequest request = CreateRequest("threads/" + id + "/unfeature", Method.Post);
            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Votes on the specified thread.
        /// </summary>
        /// <param name="id">Thread id.</param>
        /// <param name="type">Vote type.</param>
        /// <returns></returns>
        public ActionResponse VoteById(long id, string type)
        {
            RestRequest request = CreateRequest("threads/" + id + "/vote", Method.Post);
            AddParameter(request, "type", type);

            return Execute<ActionResponse>(request);
        }

        public class ThreadsResponse
        {
            [JsonProperty("threads")]
            public List<XfModels.Thread> Threads;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ThreadResponse : SuccessResponse
        {
            [JsonProperty("thread")]
            public XfModels.Thread Thread;
        }

        public class ThreadWithPostsResponse
        {
            [JsonProperty("thread")]
            public XfModels.Thread Thread;

            [JsonProperty("first_unread")]
            public XfModels.Post FirstUnread;

            [JsonProperty("first_post")]
            public XfModels.Post FirstPost;

            [JsonProperty("last_post")]
            public XfModels.Post LastPost;

            [JsonProperty("pinned_post")]
            public XfModels.Post PinnedPost;

            [JsonProperty("highlighted_posts")]
            public List<XfModels.Post> HighlightedPosts;

            [JsonProperty("posts")]
            public List<XfModels.Post> Posts;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ThreadPostsResponse
        {
            [JsonProperty("pinned_post")]
            public XfModels.Post PinnedPost;

            [JsonProperty("highlighted_posts")]
            public List<XfModels.Post> HighlightedPosts;

            [JsonProperty("posts")]
            public List<XfModels.Post> Posts;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class FeatureResponse : SuccessResponse
        {
            [JsonProperty("feature")]
            public XfModels.FeaturedContent Feature;
        }
    }
}

