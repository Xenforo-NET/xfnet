using Newtonsoft.Json;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    public class NodeDiscussion
    {
        [JsonProperty("allowed_thread_types")]
        public List<string> AllowedThreadTypes { get; set; }

        [JsonProperty("allow_answer_voting")]
        public bool? AllowAnswerVoting { get; set; }

        [JsonProperty("allow_answer_downvote")]
        public bool? AllowAnswerDownvote { get; set; }
    }
}
