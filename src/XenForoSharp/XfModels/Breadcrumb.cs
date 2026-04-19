using Newtonsoft.Json;

namespace XenForoSharp.XfModels
{
    public class Breadcrumb
    {
        [JsonProperty("node_id")]
        public long? NodeId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("node_type_id")]
        public string NodeTypeId { get; set; }
    }
}

