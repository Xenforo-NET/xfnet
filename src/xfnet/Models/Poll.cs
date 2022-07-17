using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Poll. See https://xenforo.com/community/pages/api-endpoints/#type_Poll.
    /// </summary>
    public class Poll
    {
        public bool? can_vote { get; set; }

        public bool? has_voted { get; set; }

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
        public List<PollResponse> responses { 
            get 
            { 
                return _list_responses;
            }
            set
            {
                responses = value;
            }
        }

        public long? poll_id { get; set; }

        public string question { get; set; }

        public long? voter_count { get; set; }

        public bool? public_votes { get; set; }

        public long? max_votes { get; set; }

        public long? close_date { get; set; }

        public bool? change_vote { get; set; }

        public bool? view_results_unvoted { get; set; }
    }
}
