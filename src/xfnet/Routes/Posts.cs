using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class Posts : RouteBase
    {
        public Posts(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Add a new reply to a thread.
        /// </summary>
        /// <param name="thread_id">Thread id.</param>
        /// <param name="message">Reply message.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public PostResponse Create(long thread_id, string message, string attachment_key = null)
        {
            RestRequest request = CreateRequest("posts", Method.Post);
            AddParameter(request, "thread_id", thread_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<PostResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified post.
        /// </summary>
        /// <param name="id">Post id.</param>
        /// <returns></returns>
        public PostItemResponse GetById(long id)
        {
            RestRequest request = CreateRequest("posts/" + id, Method.Get);
            return Execute<PostItemResponse>(request);
        }

        /// <summary>
        /// Updates the specified post.
        /// </summary>
        /// <param name="id">Post id.</param>
        /// <param name="message">New message text.</param>
        /// <param name="silent">If true, do not update last activity information.</param>
        /// <param name="clear_edit">If true, clears edit history information.</param>
        /// <param name="author_alert">If true, alerts the author.</param>
        /// <param name="author_alert_reason">Reason to include in the author alert.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public PostResponse UpdateById(long id, string message = null, bool? silent = null, bool? clear_edit = null, bool? author_alert = null, string author_alert_reason = null, string attachment_key = null)
        {
            RestRequest request = CreateRequest("posts/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "silent", silent);
            AddParameter(request, "clear_edit", clear_edit);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<PostResponse>(request);
        }

        /// <summary>
        /// Deletes the specified post.
        /// </summary>
        /// <param name="id">Post id.</param>
        /// <param name="hard_delete">If true, hard deletes the post.</param>
        /// <param name="reason">Deletion reason.</param>
        /// <param name="author_alert">If true, alerts the author.</param>
        /// <param name="author_alert_reason">Reason to include in the author alert.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, bool? hard_delete = null, string reason = null, bool? author_alert = null, string author_alert_reason = null)
        {
            RestRequest request = CreateRequest("posts/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Marks or clears the specified post as the solution.
        /// </summary>
        /// <param name="id">Post id.</param>
        /// <returns></returns>
        public MarkSolutionResponse MarkSolutionById(long id)
        {
            RestRequest request = CreateRequest("posts/" + id + "/mark-solution", Method.Post);
            return Execute<MarkSolutionResponse>(request);
        }

        /// <summary>
        /// Reacts to the specified post.
        /// </summary>
        /// <param name="id">Post id.</param>
        /// <param name="reaction_id">Reaction id to apply. Use 0 or null to remove reaction.</param>
        /// <returns></returns>
        public ActionResponse ReactById(long id, long? reaction_id = null)
        {
            RestRequest request = CreateRequest("posts/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return Execute<ActionResponse>(request);
        }

        /// <summary>
        /// Votes on the specified post.
        /// </summary>
        /// <param name="id">Post id.</param>
        /// <param name="type">Vote type.</param>
        /// <returns></returns>
        public ActionResponse VoteById(long id, string type)
        {
            RestRequest request = CreateRequest("posts/" + id + "/vote", Method.Post);
            AddParameter(request, "type", type);

            return Execute<ActionResponse>(request);
        }

        public class PostResponse : SuccessResponse
        {
            [JsonProperty("post")]
            public XfModels.Post Post;
        }

        public class PostItemResponse
        {
            [JsonProperty("post")]
            public XfModels.Post Post;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class MarkSolutionResponse : SuccessResponse
        {
            [JsonProperty("new_solution_post")]
            public XfModels.Post NewSolutionPost;

            [JsonProperty("old_solution_post")]
            public XfModels.Post OldSolutionPost;
        }
    }
}

