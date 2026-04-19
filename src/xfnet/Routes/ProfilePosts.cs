using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class ProfilePosts : RouteBase
    {
        public ProfilePosts(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Create a new profile post.
        /// </summary>
        /// <param name="user_id">Profile user id.</param>
        /// <param name="message">Profile post message.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ProfilePostResponse Create(long user_id, string message, string attachment_key = null)
        {
            RestRequest request = CreateRequest("profile-posts", Method.Post);
            AddParameter(request, "user_id", user_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<ProfilePostResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified profile post.
        /// </summary>
        /// <param name="id">Profile post id.</param>
        /// <param name="with_comments">If true, includes comments.</param>
        /// <param name="page"></param>
        /// <param name="direction">Sort direction.</param>
        /// <returns></returns>
        public ProfilePostWithCommentsResponse GetById(long id, bool? with_comments = null, long? page = null, string direction = null)
        {
            RestRequest request = CreateRequest("profile-posts/" + id, Method.Get);
            AddParameter(request, "with_comments", with_comments);
            AddParameter(request, "page", page);
            AddParameter(request, "direction", direction);

            return Execute<ProfilePostWithCommentsResponse>(request);
        }

        /// <summary>
        /// Updates the specified profile post.
        /// </summary>
        /// <param name="id">Profile post id.</param>
        /// <param name="message">New profile post message.</param>
        /// <param name="author_alert">If true, alerts the author.</param>
        /// <param name="author_alert_reason">Reason to include in the author alert.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ProfilePostResponse UpdateById(long id, string message = null, bool? author_alert = null, string author_alert_reason = null, string attachment_key = null)
        {
            RestRequest request = CreateRequest("profile-posts/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<ProfilePostResponse>(request);
        }

        /// <summary>
        /// Deletes the specified profile post.
        /// </summary>
        /// <param name="id">Profile post id.</param>
        /// <param name="hard_delete">If true, hard deletes the profile post.</param>
        /// <param name="reason">Deletion reason.</param>
        /// <param name="author_alert">If true, alerts the author.</param>
        /// <param name="author_alert_reason">Reason to include in the author alert.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, bool? hard_delete = null, string reason = null, bool? author_alert = null, string author_alert_reason = null)
        {
            RestRequest request = CreateRequest("profile-posts/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Gets comments for the specified profile post.
        /// </summary>
        /// <param name="id">Profile post id.</param>
        /// <param name="page"></param>
        /// <param name="direction">Sort direction.</param>
        /// <returns></returns>
        public CommentsResponse GetCommentsById(long id, long? page = null, string direction = null)
        {
            RestRequest request = CreateRequest("profile-posts/" + id + "/comments", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "direction", direction);

            return Execute<CommentsResponse>(request);
        }

        /// <summary>
        /// Reacts to the specified profile post.
        /// </summary>
        /// <param name="id">Profile post id.</param>
        /// <param name="reaction_id">Reaction id to apply. Use 0 or null to remove reaction.</param>
        /// <returns></returns>
        public ActionResponse ReactById(long id, long? reaction_id = null)
        {
            RestRequest request = CreateRequest("profile-posts/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return Execute<ActionResponse>(request);
        }

        public class ProfilePostResponse : SuccessResponse
        {
            [JsonProperty("profile_post")]
            public XfModels.ProfilePost ProfilePost;
        }

        public class ProfilePostWithCommentsResponse
        {
            [JsonProperty("profile_post")]
            public XfModels.ProfilePost ProfilePost;

            [JsonProperty("comments")]
            public List<XfModels.ProfilePostComment> Comments;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class CommentsResponse
        {
            [JsonProperty("comments")]
            public List<XfModels.ProfilePostComment> Comments;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

