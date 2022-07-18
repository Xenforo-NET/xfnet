using Newtonsoft.Json;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: ThreadField. See https://xenforo.com/community/pages/api-endpoints/#type_ThreadField.
    /// </summary>
    public class ThreadField
    {
        [JsonProperty("field_id")]
        public string FieldId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("display_order")]
        public long? DisplayOrder { get; set; }

        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        /// <summary>
        /// (Conditionally returned) For choice types, an ordered list of choices, with "option" and "name" keys for each.
        /// </summary>
        [JsonProperty("field_choices")]
        public List<FieldChoice> FieldChoices { get; set; }

        [JsonProperty("match_type")]
        public string MatchType { get; set; }

        [JsonProperty("match_params")]
        public List<object> MatchParams { get; set; }

        [JsonProperty("max_length")]
        public long? MaxLength { get; set; }

        [JsonProperty("required")]
        public bool? Required { get; set; }

        /// <summary>
        /// (Conditionally returned) If this field type supports grouping, the group this field belongs to.
        /// </summary>
        [JsonProperty("display_group")]
        public string DisplayGroup { get; set; }
    }
}
