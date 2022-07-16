using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Conversation. See https://xenforo.com/community/pages/api-endpoints/#type_Conversation.
    /// </summary>
    public class Conversation
    {
        /// <summary>
        /// Name of the user that started the conversation.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Key-value pair of recipient user IDs and names.
        /// </summary>
        public Dictionary<long, string> recipients { get; set; }

        /// <summary>
        /// True if the viewing user starred the conversation.
        /// </summary>
        public bool? is_starred { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this conversation is unread.
        /// </summary>
        public bool? is_unread { get; set; }

        public bool? can_edit { get; set; }

        public bool? can_reply { get; set; }

        public bool? can_invite { get; set; }

        public bool? can_upload_attachment { get; set; }

        public string view_url { get; set; }

        public long? conversation_id { get; set; }

        public string title { get; set; }

        public long? user_id { get; set; }

        public long? start_date { get; set; }

        public bool? open_invite { get; set; }

        public bool? conversation_open { get; set; }

        public long? reply_count { get; set; }

        public long? recipient_count { get; set; }

        public long? first_message_id { get; set; }

        public long? last_message_date { get; set; }

        public long? last_message_id { get; set; }

        public long? last_message_user_id { get; set; }

        public User Starter { get; set; }
    }
}
