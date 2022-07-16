using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: ConversationMessage. See https://xenforo.com/community/pages/api-endpoints/#type_ConversationMessage.
    /// </summary>
    public class ConversationMessage
    {
        public string username { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this conversation message is unread.
        /// </summary>
        public bool? is_unread { get; set; }

        /// <summary>
        /// HTML parsed version of the message contents.
        /// </summary>
        public string message_parsed { get; set; }

        public bool? can_edit { get; set; }

        public bool? can_react { get; set; }

        public string view_url { get; set; }

        /// <summary>
        /// (Conditionally returned) If requested by context, the conversation this message is part of.
        /// </summary>
        public Conversation Conversation { get; set; }

        /// <summary>
        /// If there are attachments to this message, a list of attachments.
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

        public long? message_id { get; set; }

        public long? conversation_id { get; set; }

        public long? message_date { get; set; }

        public long? user_id { get; set; }

        public string message { get; set; }

        public long? attach_count { get; set; }

        public long? reaction_score { get; set; }

        public User User { get; set; }
    }
}
