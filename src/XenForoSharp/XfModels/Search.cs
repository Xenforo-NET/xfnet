using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XenForoSharp.XfModels
{
    /// <summary>
    /// Data type: Search. See https://docs.xenforo.com/api.
    /// </summary>
    public class Search
    {
        long? _searchDateUnix;

        [JsonProperty("search_id")]
        public long? SearchId { get; set; }

        [JsonProperty("result_count")]
        public long? ResultCount { get; set; }

        [JsonProperty("search_type")]
        public string SearchType { get; set; }

        [JsonProperty("search_query")]
        public string SearchQuery { get; set; }

        [JsonProperty("search_constraints")]
        public List<object> SearchConstraints { get; set; }

        [JsonProperty("search_order")]
        public string SearchOrder { get; set; }

        [JsonProperty("search_grouping")]
        public bool? SearchGrouping { get; set; }

        [JsonProperty("warnings")]
        public List<object> Warnings { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("search_date")]
        public long? SearchDateUnix
        {
            get { return _searchDateUnix; }
            set
            {
                _searchDateUnix = value;
                if (!value.HasValue)
                    SearchDate = null;
                else
                    SearchDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? SearchDate { get; set; }

        [JsonProperty("query_hash")]
        public string QueryHash { get; set; }
    }
}

