using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    public class NodeTypeData
    {
        public bool? allow_posting { get; set; }

        public bool? can_create_thread { get; set; }

        public bool? can_upload_attachment { get; set; }

        public NodeDiscussion discussion { get; set; }

        public long? discussion_count { get; set; }

        public string forum_type_id { get; set; }

        public bool? is_unread { get; set; }

        public long? last_post_date { get; set; }

        public long? last_post_id { get; set; }

        public string last_post_username { get; set; }

        public long? last_thread_id { get; set; }

        public long? last_thread_prefix_id { get; set; }

        public string last_thread_title { get; set; }

        public long? message_count { get; set; }

        public long? min_tags { get; set; }

        public bool? require_prefix { get; set; }
    }
}
