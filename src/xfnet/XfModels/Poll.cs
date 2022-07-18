using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Poll. See https://xenforo.com/community/pages/api-endpoints/#type_Poll.
    /// </summary>
    public class Poll
    {
        [JsonProperty("can_vote")]
        public bool? CanVote { get; set; }

        [JsonProperty("has_voted")]
        public bool? HasVoted { get; set; }

        [JsonProperty("responses")]
        private Dictionary<string, PollResponse> _responses { get { return _responses; } 
            set 
            { 
                _responses = value;
                _list_responses = _responses.Values.ToList();
            } 
        }

        private List<PollResponse> _list_responses { get; set; }

        /// <summary>
        /// List of possible responses with text, vote count (if visible) and whether the API user has voted for each.
        /// </summary>
        public List<PollResponse> Responses { 
            get 
            { 
                return _list_responses;
            }
            set
            {
                Responses = value;
            }
        }

        [JsonProperty("poll_id")]
        public long? PollId { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("voter_count")]
        public long? VoterCount { get; set; }

        [JsonProperty("public_votes")]
        public bool? PublicVotes { get; set; }

        [JsonProperty("max_votes")]
        public long? MaxVotes { get; set; }

        [JsonProperty("close_date")]
        public long? CloseDate { get; set; }

        [JsonProperty("change_vote")]
        public bool? ChangeVote { get; set; }

        [JsonProperty("view_results_unvoted")]
        public bool? ViewResultsUnvoted { get; set; }
    }
}
