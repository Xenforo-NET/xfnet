using Newtonsoft.Json;

namespace xfnet.XfModels
{
    public class ImageSizes
    {
        [JsonProperty("o")]
        public string Horizontal { get; set; }

        [JsonProperty("h")]
        public string Large { get; set; }

        [JsonProperty("l")]
        public string Medium { get; set; }

        [JsonProperty("m")]
        public string Small { get; set; }

        [JsonProperty("s")]
        public string Tiny { get; set; }
    }
}
