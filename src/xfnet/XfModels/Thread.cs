using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Thread. See https://xenforo.com/community/pages/api-endpoints/#type_Thread.
    /// </summary>
    public class Thread
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if they are watching this thread.
        /// </summary>
        [JsonProperty("is_watching")]
        public bool? IsWatching { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, the number of posts they have made in this thread.
        /// </summary>
        [JsonProperty("visitor_post_count")]
        public long? VisitorPostCount { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this thread is unread.
        /// </summary>
        [JsonProperty("is_unread")]
        public bool? IsUnread { get; set; }

        /// <summary>
        /// Key-value pairs of custom field values for this thread.
        /// </summary>
        [JsonProperty("custom_fields")]
        public Dictionary<string, object> CustomFields { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// (Conditionally returned) Present if this thread has a prefix. Printable name of the prefix.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("can_edit")]
        public bool? CanEdit { get; set; }

        [JsonProperty("can_edit_tags")]
        public bool? CanEditTags { get; set; }

        [JsonProperty("can_reply")]
        public bool? CanReply { get; set; }

        [JsonProperty("can_soft_delete")]
        public bool? CanSoftDelete { get; set; }

        [JsonProperty("can_hard_delete")]
        public bool? CanHardDelete { get; set; }

        [JsonProperty("can_view_attachments")]
        public bool? CanViewAttachments { get; set; }

        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        [JsonProperty("is_first_post_pinned")]
        public bool? IsFirstPostPinned { get; set; }

        [JsonProperty("highlighted_post_ids")]
        public List<long?> HighlightedPostIds { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the forum this thread was posted in.
        /// </summary>
        [JsonProperty("Forum")]
        public Node Forum { get; set; }

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

        [JsonProperty("thread_id")]
        public long? ThreadId { get; set; }

        [JsonProperty("node_id")]
        public long? NodeId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("reply_count")]
        public long? ReplyCount { get; set; }

        [JsonProperty("view_count")]
        public long? ViewCount { get; set; }

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

        [JsonProperty("sticky")]
        public bool? Sticky { get; set; }

        [JsonProperty("discussion_state")]
        public string DiscussionState { get; set; }

        [JsonProperty("discussion_open")]
        public bool? DiscussionOpen { get; set; }

        [JsonProperty("discussion_type")]
        public string DiscussionType { get; set; }

        [JsonProperty("first_post_id")]
        public long? FirstPostId { get; set; }

        [JsonProperty("last_post_date")]
        public long? LastPostDateUnix
        {
            get { return LastPostDateUnix; }
            set
            {
                LastPostDateUnix = value;
                if (!value.HasValue)
                    LastPostDate = null;
                else
                    LastPostDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? LastPostDate { get; set; }

        [JsonProperty("last_post_id")]
        public long? LastPostId { get; set; }

        [JsonProperty("last_post_user_id")]
        public long? LastPostUserId { get; set; }

        [JsonProperty("last_post_username")]
        public string LastPostUsername { get; set; }

        [JsonProperty("first_post_reaction_score")]
        public long? FirstPostReactionScore { get; set; }

        [JsonProperty("prefix_id")]
        public long? PrefixId { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }
    }
}
