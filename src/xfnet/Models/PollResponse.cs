using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    public class PollResponse
    {
        public string text { get; set; }

        public long? vote_count { get; set; }

        public bool? visitor_voted_for { get; set; }
    }
}
