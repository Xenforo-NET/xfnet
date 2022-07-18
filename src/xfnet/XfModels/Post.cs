using Newtonsoft.Json;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Post. See https://xenforo.com/community/pages/api-endpoints/#type_Post.
    /// </summary>
    public class Post
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("is_first_post")]
        public bool? IsFirstPost { get; set; }

        [JsonProperty("is_last_post")]
        public bool? IsLastPost { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this post is unread.
        /// </summary>
        [JsonProperty("is_unread")]
        public bool? IsUnread { get; set; }

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
        /// (Conditionally returned) If requested by context, the thread this post is part of.
        /// </summary>
        [JsonProperty("Thread")]
        public Thread Thread { get; set; }

        /// <summary>
        /// (Conditionally returned) Attachments to this post, if it has any.
        /// </summary>
        [JsonProperty("Attachments")]
        public List<Attachment> Attachments { get; set; }

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

        /// <summary>
        /// (Conditionally returned) The content's vote score (if supported).
        /// </summary>
        [JsonProperty("vote_score")]
        public long? VoteScore { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the viewing user can vote on this content.
        /// </summary>
        [JsonProperty("can_content_vote")]
        public bool? CanContentVote { get; set; }

        /// <summary>
        /// (Conditionally returned) List of content vote types allowed on this content.
        /// </summary>
        [JsonProperty("allowed_content_vote_types")]
        public List<string> AllowedContentVoteTypes { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the viewing user has voted on this content.
        /// </summary>
        [JsonProperty("is_content_voted")]
        public bool? IsContentVoted { get; set; }

        /// <summary>
        /// (Conditionally returned) If the viewer reacted, the vote they case (up/down).
        /// </summary>
        [JsonProperty("visitor_content_vote")]
        public string VisitorContentVote { get; set; }

        [JsonProperty("post_id")]
        public long? PostId { get; set; }

        [JsonProperty("thread_id")]
        public long? ThreadId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("post_date")]
        public long? PostDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("message_state")]
        public string MssageState { get; set; }

        [JsonProperty("attach_count")]
        public long? AttachCount { get; set; }

        [JsonProperty("warning_message")]
        public string WarningMessage { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        [JsonProperty("last_edit_date")]
        public long? LastEditDate { get; set; }

        [JsonProperty("reaction_score")]
        public long? ReactionScore { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }
    }
}
