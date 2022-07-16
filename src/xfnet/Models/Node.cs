using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: Node. See https://xenforo.com/community/pages/api-endpoints/#type_Node.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// A list of breadcrumbs for this node, including the node_id, title, and node_type_id.
        /// </summary>
        public List<Breadcrumb> breadcrumbs { get; set; }

        /// <summary>
        /// Data related to the specific node type this represents. Contents will vary significantly. 
        /// </summary>
        public NodeTypeData type_data { get; set; }

        public string view_url { get; set; }

        public long? node_id { get; set; }

        public string title { get; set; }

        public string node_name { get; set; }

        public string description { get; set; }

        public string node_type_id { get; set; }

        public long? parent_node_id { get; set; }

        public long? display_order { get; set; }

        public bool? display_in_list { get; set; }
    }
}
