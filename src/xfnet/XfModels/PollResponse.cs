using Newtonsoft.Json;

namespace xfnet.XfModels
{
    public class PollResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("vote_count")]
        public long? VoteCount { get; set; }

        [JsonProperty("visitor_voted_for")]
        public bool? VisitorVotedFor { get; set; }
    }
}
