using Newtonsoft.Json;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Page. See https://xenforo.com/community/pages/api-endpoints/#type_Page.
    /// </summary>
    public class Page
    {
        [JsonProperty("publish_date")]
        public long? PublishDate { get; set; }

        [JsonProperty("view_count")]
        public long? ViewCount { get; set; }
    }
}
