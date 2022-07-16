using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Post. See https://xenforo.com/community/pages/api-endpoints/#type_Post.
    /// </summary>
    public class Post
    {
        public string username { get; set; }

        public bool? is_first_post { get; set; }

        public bool? is_last_post { get; set; }


        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this post is unread.
        /// </summary>
        public bool? is_unread { get; set; }

        /// <summary>
        /// HTML parsed version of the message contents..
        /// </summary>
        public string message_parsed { get; set; }

        public bool? can_edit { get; set; }

        public bool? can_soft_delete { get; set; }

        public bool? can_hard_delete { get; set; }

        public bool? can_react { get; set; }

        public bool? can_view_attachments { get; set; }

        public string view_url { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the thread this post is part of.
        /// </summary>
        public Thread Thread { get; set; }

        /// <summary>
        /// (Conditionally returned) Attachments to this post, if it has any.
        /// </summary>
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// True if the viewing user has reacted to this content.
        /// </summary>
        public bool? is_reacted_to { get; set; }

        /// <summary>
        /// If the viewer reacted, the ID of the reaction they used.
        /// </summary>
        public long? visitor_reaction_id { get; set; }

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

        public long? post_id { get; set; }

        public long? thread_id { get; set; }

        public long? user_id { get; set; }

        public long? post_date { get; set; }

        public string message { get; set; }

        public string message_state { get; set; }

        public long? attach_count { get; set; }

        public string warning_message { get; set; }

        public long? position { get; set; }

        public long? last_edit_date { get; set; }

        public long? reaction_score { get; set; }

        public User User { get; set; }
    }
}
