using Newtonsoft.Json;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: ProfilePostComment. See https://xenforo.com/community/pages/api-endpoints/#type_ProfilePostComment.
    /// </summary>
    public class ProfilePostComment
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// HTML parsed version of the message contents.
        /// </summary>
        [JsonProperty("message_parsed")]
        public string MessageParsed { get; set; }

        [JsonProperty("can_edit")]
        public bool? CanEdit { get; set; }

        [JsonProperty("can_soft_delete")]
        public bool? CanSoftDelete { get; set; }

        [JsonProperty("can_hard_delete")]
        public bool? CanHardDelete { get; set; }

        [JsonProperty("can_react")]
        public bool? CanReact { get; set; }

        [JsonProperty("can_view_attachments")]
        public bool? CanViewAttachments { get; set; }

        /// <summary>
        /// (Conditionally returned) Attachments to this profile post, if it has any.
        /// </summary>
        [JsonProperty("Attachments")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the profile post this comment relates to.
        /// </summary>
        [JsonProperty("ProfilePost")]
        public ProfilePost ProfilePost { get; set; }

        /// <summary>
        /// True if the viewing user has reacted to this content.
        /// </summary>
        [JsonProperty("is_reacted_to")]
        public bool? IsReactedTo { get; set; }

        /// <summary>
        /// If the viewer reacted, the ID of the reaction they used.
        /// </summary>
        [JsonProperty("visitor_reaction_id")]
        public long? VisitorReactionId { get; set; }

        [JsonProperty("profile_post_comment_id")]
        public long? ProfilePostCommentId { get; set; }

        [JsonProperty("profile_post_id")]
        public long? ProfilePostId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("comment_date")]
        public long? CommentDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("message_state")]
        public string MessageState { get; set; }

        [JsonProperty("warning_message")]
        public string WarningMessage { get; set; }

        [JsonProperty("reaction_score")]
        public long? ReactionScore { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }
    }
}
