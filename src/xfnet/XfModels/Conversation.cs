using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Conversation. See https://xenforo.com/community/pages/api-endpoints/#type_Conversation.
    /// </summary>
    public class Conversation
    {
        /// <summary>
        /// Name of the user that started the conversation.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Key-value pair of recipient user IDs and names.
        /// </summary>
        [JsonProperty("recipients")]
        public Dictionary<long, string> Recipients { get; set; }

        /// <summary>
        /// True if the viewing user starred the conversation.
        /// </summary>
        [JsonProperty("is_starred")]
        public bool? IsStarred { get; set; }

        /// <summary>
        /// (Conditionally returned) If accessing as a user, true if this conversation is unread.
        /// </summary>
        [JsonProperty("is_unread")]
        public bool? IsUnread { get; set; }

        [JsonProperty("can_edit")]
        public bool? CanEdit { get; set; }

        [JsonProperty("can_reply")]
        public bool? CanReply { get; set; }

        [JsonProperty("can_invite")]
        public bool? CanInvite { get; set; }

        [JsonProperty("can_upload_attachment")]
        public bool? CanUploadAttachment { get; set; }

        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        [JsonProperty("conversation_id")]
        public long? ConversationId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("start_date")]
        public long? StartDateUnix 
        { 
            get { return StartDateUnix; } 
            set 
            { 
                StartDateUnix = value;
                if (!value.HasValue)
                    StartDate = null;
                else 
                    StartDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            } 
        }

        public DateTime? StartDate { get; set; }

        [JsonProperty("open_invite")]
        public bool? OpenInvite { get; set; }

        [JsonProperty("conversation_open")]
        public bool? ConversationOpen { get; set; }

        [JsonProperty("reply_count")]
        public long? ReplyCount { get; set; }

        [JsonProperty("recipient_count")]
        public long? RecipientCount { get; set; }

        [JsonProperty("first_message_id")]
        public long? FirstMessageId { get; set; }

        [JsonProperty("last_message_date")]
        public long? LastMessageDateUnix
        {
            get { return LastMessageDateUnix; }
            set
            {
                LastMessageDateUnix = value;
                if (!value.HasValue)
                    LastMessageDate = null;
                else
                    LastMessageDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? LastMessageDate { get; set; }

        [JsonProperty("last_message_id")]
        public long? LastMessageId { get; set; }

        [JsonProperty("last_message_user_id")]
        public long? LastMessageUserId { get; set; }

        [JsonProperty("Starter")]
        public User Starter { get; set; }
    }
}
