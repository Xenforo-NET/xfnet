using Newtonsoft.Json;

namespace xfnet.XfModels
{
    public class Pagination
    {
        [JsonProperty("current_page")]
        public long? CurrentPage { get; set; }

        [JsonProperty("last_page")]
        public long? LastPage { get; set; }

        [JsonProperty("per_page")]
        public long? PerPage { get; set; }

        [JsonProperty("shown")]
        public long? Shown { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }
    }
}
