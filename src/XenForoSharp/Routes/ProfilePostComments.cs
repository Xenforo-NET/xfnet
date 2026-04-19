using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public partial class ProfilePostComments : RouteBase
    {
        public ProfilePostComments(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Create a new profile post comment.
        /// </summary>
        /// <param name="profile_post_id">Profile post id.</param>
        /// <param name="message">Comment message.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ProfilePostCommentResponse Create(long profile_post_id, string message, string attachment_key = null)
        {
            RestRequest request = CreateRequest("profile-post-comments", Method.Post);
            AddParameter(request, "profile_post_id", profile_post_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<ProfilePostCommentResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified profile post comment.
        /// </summary>
        /// <param name="id">Profile post comment id.</param>
        /// <returns></returns>
        public ProfilePostCommentItemResponse GetById(long id)
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id, Method.Get);
            return Execute<ProfilePostCommentItemResponse>(request);
        }

        /// <summary>
        /// Updates the specified profile post comment.
        /// </summary>
        /// <param name="id">Profile post comment id.</param>
        /// <param name="message">New comment message.</param>
        /// <param name="author_alert">If true, alerts the author.</param>
        /// <param name="author_alert_reason">Reason to include in the author alert.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ProfilePostCommentResponse UpdateById(long id, string message = null, bool? author_alert = null, string author_alert_reason = null, string attachment_key = null)
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<ProfilePostCommentResponse>(request);
        }

        /// <summary>
        /// Deletes the specified profile post comment.
        /// </summary>
        /// <param name="id">Profile post comment id.</param>
        /// <param name="hard_delete">If true, hard deletes the comment.</param>
        /// <param name="reason">Deletion reason.</param>
        /// <param name="author_alert">If true, alerts the author.</param>
        /// <param name="author_alert_reason">Reason to include in the author alert.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, bool? hard_delete = null, string reason = null, bool? author_alert = null, string author_alert_reason = null)
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id, Method.Delete);
            AddParameter(request, "hard_delete", hard_delete);
            AddParameter(request, "reason", reason);
            AddParameter(request, "author_alert", author_alert);
            AddParameter(request, "author_alert_reason", author_alert_reason);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Reacts to the specified profile post comment.
        /// </summary>
        /// <param name="id">Profile post comment id.</param>
        /// <param name="reaction_id">Reaction id to apply. Use 0 or null to remove reaction.</param>
        /// <returns></returns>
        public ActionResponse ReactById(long id, long? reaction_id = null)
        {
            RestRequest request = CreateRequest("profile-post-comments/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return Execute<ActionResponse>(request);
        }

        public class ProfilePostCommentResponse : SuccessResponse
        {
            [JsonProperty("comment")]
            public XfModels.ProfilePostComment Comment;
        }

        public class ProfilePostCommentItemResponse
        {
            [JsonProperty("comment")]
            public XfModels.ProfilePostComment Comment;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

