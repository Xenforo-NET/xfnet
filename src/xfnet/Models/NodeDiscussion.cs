using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    public class NodeDiscussion
    {
        public List<string> allowed_thread_types { get; set; }

        public bool? allow_answer_voting { get; set; }

        public bool? allow_answer_downvote { get; set; }
    }
}
