using Newtonsoft.Json;

namespace xfnet.XfModels
{
    public class FieldChoice
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("option")]
        public string Option { get; set; }
    }
}
