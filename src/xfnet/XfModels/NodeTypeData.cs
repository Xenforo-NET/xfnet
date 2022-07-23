using Newtonsoft.Json;
using System;

namespace xfnet.XfModels
{
    public class NodeTypeData
    {
        [JsonProperty("allow_posting")]
        public bool? AllowPosting { get; set; }

        [JsonProperty("can_create_thread")]
        public bool? CanCreateThread { get; set; }

        [JsonProperty("can_upload_attachment")]
        public bool? CanUploadAttachment { get; set; }

        [JsonProperty("discussion")]
        public NodeDiscussion Discussion { get; set; }

        [JsonProperty("discussion_count")]
        public long? DiscussionCount { get; set; }

        [JsonProperty("forum_type_id")]
        public string ForumTypeId { get; set; }

        [JsonProperty("is_unread")]
        public bool? IsUnread { get; set; }

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

        [JsonProperty("last_post_username")]
        public string LastPostUsername { get; set; }

        [JsonProperty("last_thread_id")]
        public long? LastThreadId { get; set; }

        [JsonProperty("last_thread_prefix_id")]
        public long? LastThreadPrefixId { get; set; }

        [JsonProperty("last_thread_title")]
        public string LastThreadTitle { get; set; }

        [JsonProperty("message_count")]
        public long? MessageCount { get; set; }

        [JsonProperty("min_tags")]
        public long? MinTags { get; set; }

        [JsonProperty("require_prefix")]
        public bool? RequirePrefix { get; set; }
    }
}
