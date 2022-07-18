using Newtonsoft.Json;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Forum. See https://xenforo.com/community/pages/api-endpoints/#type_Forum.
    /// </summary>
    public class Forum
    {
        [JsonProperty("forum_type_id")]
        public string ForumTypeId { get; set; }

        [JsonProperty("allow_posting")]
        public bool? AllowPosting { get; set; }

        [JsonProperty("require_prefix")]
        public bool? RequirePrefix { get; set; }

        [JsonProperty("min_tags")]
        public long? MinTags { get; set; }
    }
}
