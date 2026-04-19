using Newtonsoft.Json;

namespace XenForoSharp.XfModels
{
    public class XfDate
    {
        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("day")]
        public int? Day { get; set; }
    }
}

