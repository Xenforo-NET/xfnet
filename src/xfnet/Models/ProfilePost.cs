using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: ProfilePost. See https://xenforo.com/community/pages/api-endpoints/#type_ProfilePost.
    /// </summary>
    public class ProfilePost
    {
        public string username { get; set; }

        /// <summary>
        /// HTML parsed version of the message contents.
        /// </summary>
        public string message_parsed { get; set; }

        public bool? can_edit { get; set; }

        public bool? can_soft_delete { get; set; }

        public bool? can_hard_delete { get; set; }

        public bool? can_react { get; set; }

        public bool? can_view_attachments { get; set; }

        public string view_url { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the user this profile post was left for.
        /// </summary>
        public User ProfileUser { get; set; }

        /// <summary>
        /// (Conditionally returned) Attachments to this profile post, if it has any.
        /// </summary>
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested, the most recent comments on this profile post.
        /// </summary>
        public List<ProfilePostComment> LatestComments { get; set; }

        /// <summary>
        /// True if the viewing user has reacted to this content.
        /// </summary>
        public bool? is_reacted_to { get; set; }

        /// <summary>
        /// If the viewer reacted, the ID of the reaction they used.
        /// </summary>
        public long? visitor_reaction_id { get; set; }

        public long? profile_post_id { get; set; }

        public long? profile_user_id { get; set; }

        public long? user_id { get; set; }

        public long? post_date { get; set; }

        public string message { get; set; }

        public string message_state { get; set; }

        public string warning_message { get; set; }

        public long? comment_count { get; set; }

        public long? first_comment_date { get; set; }

        public long? last_comment_date { get; set; }

        public long? reaction_score { get; set; }

        public User User { get; set; }
    }
}
