using Newtonsoft.Json;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: ThreadPrefix. See https://xenforo.com/community/pages/api-endpoints/#type_ThreadPrefix.
    /// </summary>
    public class ThreadPrefix
    {
        [JsonProperty("prefix_id")]
        public long? PrefixId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("usage_help")]
        public string UsageHelp { get; set; }

        /// <summary>
        /// True if the acting user can use (select) this prefix.
        /// </summary>
        [JsonProperty("is_usable")]
        public bool? IsUsable { get; set; }

        [JsonProperty("prefix_group_id")]
        public long? PrefixGroupId { get; set; }

        [JsonProperty("display_order")]
        public long? DisplayOrder { get; set; }

        /// <summary>
        /// Effective order, taking group ordering into account.
        /// </summary>
        [JsonProperty("materialized_order")]
        public long? MaterializedOrder { get; set; }
    }
}
