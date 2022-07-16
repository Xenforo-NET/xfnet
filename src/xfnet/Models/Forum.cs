using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Forum. See https://xenforo.com/community/pages/api-endpoints/#type_Forum.
    /// </summary>
    public class Forum
    {
        public string forum_type_id { get; set; }

        public bool? allow_posting { get; set; }

        public bool? require_prefix { get; set; }

        public long? min_tags { get; set; }
    }
}
