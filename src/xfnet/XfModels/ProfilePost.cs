using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: ProfilePost. See https://xenforo.com/community/pages/api-endpoints/#type_ProfilePost.
    /// </summary>
    public class ProfilePost
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

        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the user this profile post was left for.
        /// </summary>
        [JsonProperty("ProfileUser")]
        public User ProfileUser { get; set; }

        /// <summary>
        /// (Conditionally returned) Attachments to this profile post, if it has any.
        /// </summary>
        [JsonProperty("Attachments")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested, the most recent comments on this profile post.
        /// </summary>
        [JsonProperty("LatestComments")]
        public List<ProfilePostComment> LatestComments { get; set; }

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

        [JsonProperty("profile_post_id")]
        public long? ProfilePostId { get; set; }

        [JsonProperty("profile_user_id")]
        public long? ProfileUserId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("post_date")]
        public long? PostDateUnix
        {
            get { return PostDateUnix; }
            set
            {
                PostDateUnix = value;
                if (!value.HasValue)
                    PostDate = null;
                else
                    PostDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? PostDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("message_state")]
        public string MessageState { get; set; }

        [JsonProperty("warning_message")]
        public string WarningMessage { get; set; }

        [JsonProperty("comment_count")]
        public long? CommentCount { get; set; }

        [JsonProperty("first_comment_date")]
        public long? FirstCommentDateUnix
        {
            get { return FirstCommentDateUnix; }
            set
            {
                FirstCommentDateUnix = value;
                if (!value.HasValue)
                    FirstCommentDate = null;
                else
                    FirstCommentDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? FirstCommentDate { get; set; }

        [JsonProperty("last_comment_date")]
        public long? LastCommentDateUnix
        {
            get { return LastCommentDateUnix; }
            set
            {
                LastCommentDateUnix = value;
                if (!value.HasValue)
                    LastCommentDate = null;
                else
                    LastCommentDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? LastCommentDate { get; set; }

        [JsonProperty("reaction_score")]
        public long? ReactionScore { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }
    }
}
