using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Poll. See https://xenforo.com/community/pages/api-endpoints/#type_Poll.
    /// </summary>
    public class Poll
    {
        long? _closeDateUnix;

        [JsonProperty("can_vote")]
        public bool? CanVote { get; set; }

        [JsonProperty("has_voted")]
        public bool? HasVoted { get; set; }

        [JsonProperty("responses")]
        public Dictionary<string, PollResponse> ResponsesMap
        {
            set
            {
                if (value == null)
                    Responses = null;
                else
                    Responses = value.Values.ToList();
            }
        }

        /// <summary>
        /// List of possible responses with text, vote count (if visible) and whether the API user has voted for each.
        /// </summary>
        [JsonIgnore]
        public List<PollResponse> Responses { 
            get 
            { 
                return _responses;
            }
            set { _responses = value; }
        }

        List<PollResponse> _responses;

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
        public long? CloseDateUnix
        {
            get { return _closeDateUnix; }
            set
            {
                _closeDateUnix = value;
                if (!value.HasValue)
                    CloseDate = null;
                else
                    CloseDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? CloseDate { get; set; }

        [JsonProperty("change_vote")]
        public bool? ChangeVote { get; set; }

        [JsonProperty("view_results_unvoted")]
        public bool? ViewResultsUnvoted { get; set; }
    }
}
