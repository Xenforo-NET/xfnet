using System.Collections.Generic;
using Newtonsoft.Json;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Node. See https://xenforo.com/community/pages/api-endpoints/#type_Node.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// A list of breadcrumbs for this node, including the node_id, title, and node_type_id.
        /// </summary>
        [JsonProperty("breadcrumbs")]
        public List<Breadcrumb> Breadcrumbs { get; set; }

        /// <summary>
        /// Data related to the specific node type this represents. Contents will vary significantly. 
        /// </summary>
        [JsonProperty("type_data")]
        public NodeTypeData TypeData { get; set; }

        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        [JsonProperty("node_id")]
        public long? NodeId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("node_name")]
        public string NodeName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("node_type_id")]
        public string NodeTypeId { get; set; }

        [JsonProperty("parent_node_id")]
        public long? ParentNodeId { get; set; }

        [JsonProperty("display_order")]
        public long? DisplayOrder { get; set; }

        [JsonProperty("display_in_list")]
        public bool? DisplayInList { get; set; }
    }
}
