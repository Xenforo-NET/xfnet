using Newtonsoft.Json;

namespace xfnet.XfModels
{
    public class XfDate
    {
        [JsonProperty("year")]
        public long? Year { get; set; }

        [JsonProperty("month")]
        public long? Month { get; set; }

        [JsonProperty("day")]
        public long? Day { get; set; }
    }
}
