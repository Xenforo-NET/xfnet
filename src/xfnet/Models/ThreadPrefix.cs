using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: ThreadPrefix. See https://xenforo.com/community/pages/api-endpoints/#type_ThreadPrefix.
    /// </summary>
    public class ThreadPrefix
    {
        public long? prefix_id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string usage_help { get; set; }

        /// <summary>
        /// True if the acting user can use (select) this prefix.
        /// </summary>
        public bool? is_usable { get; set; }

        public long? prefix_group_id { get; set; }

        public long? display_order { get; set; }

        /// <summary>
        /// Effective order, taking group ordering into account.
        /// </summary>
        public long? materialized_order { get; set; }
    }
}
