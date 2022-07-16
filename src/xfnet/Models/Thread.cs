using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Thread. See https://xenforo.com/community/pages/api-endpoints/#type_Thread.
    /// </summary>
    public class Thread
    {
        public string username { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if they are watching this thread.
        /// </summary>
        public bool? is_watching { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, the number of posts they have made in this thread.
        /// </summary>
        public long? visitor_post_count { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this thread is unread.
        /// </summary>
        public bool? is_unread { get; set; }

        /// <summary>
        /// Key-value pairs of custom field values for this thread.
        /// </summary>
        public Dictionary<string, object> custom_fields { get; set; }

        public List<string> tags { get; set; }

        /// <summary>
        /// (Conditionally returned) Present if this thread has a prefix. Printable name of the prefix.
        /// </summary>
        public string prefix { get; set; }

        public bool? can_edit { get; set; }

        public bool? can_edit_tags { get; set; }

        public bool? can_reply { get; set; }

        public bool? can_soft_delete { get; set; }

        public bool? can_hard_delete { get; set; }

        public bool? can_view_attachments { get; set; }

        public string view_url { get; set; }

        public bool? is_first_post_pinned { get; set; }

        public List<long?> highlighted_post_ids { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the forum this thread was posted in.
        /// </summary>
        public Node Forum { get; set; }

        /// <summary>
        /// (Conditionally returned) The content's vote score (if supported).
        /// </summary>
        public long? vote_score { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the viewing user can vote on this content.
        /// </summary>
        public bool? can_content_vote { get; set; }

        /// <summary>
        /// (Conditionally returned) List of content vote types allowed on this content.
        /// </summary>
        public List<string> allowed_content_vote_types { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the viewing user has voted on this content.
        /// </summary>
        public bool? is_content_voted { get; set; }

        /// <summary>
        /// (Conditionally returned) If the viewer reacted, the vote they case (up/down).
        /// </summary>
        public string visitor_content_vote { get; set; }

        public long? thread_id { get; set; }

        public long? node_id { get; set; }

        public string title { get; set; }

        public long? reply_count { get; set; }

        public long? view_count { get; set; }

        public long? user_id { get; set; }

        public long? post_date { get; set; }

        public bool? sticky { get; set; }

        public string discussion_state { get; set; }

        public bool? discussion_open { get; set; }

        public string discussion_type { get; set; }

        public long? first_post_id { get; set; }

        public long? last_post_date { get; set; }

        public long? last_post_id { get; set; }

        public long? last_post_user_id { get; set; }

        public string last_post_username { get; set; }

        public long? first_post_reaction_score { get; set; }

        public long? prefix_id { get; set; }

        public User User { get; set; }
    }
}
