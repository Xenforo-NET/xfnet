using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class Nodes : RouteBase
    {
        public Nodes(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get the node tree.
        /// </summary>
        /// <returns></returns>
        public NodesResponse GetAll()
        {
            RestRequest request = CreateRequest("nodes", Method.Get);
            return Execute<NodesResponse>(request);
        }

        /// <summary>
        /// Create a new node.
        /// </summary>
        /// <param name="title">Node title.</param>
        /// <param name="parent_node_id">Parent node id.</param>
        /// <param name="node_type_id">Node type id.</param>
        /// <param name="type_data">Type-specific node data.</param>
        /// <param name="node_name">Node name.</param>
        /// <param name="description">Node description.</param>
        /// <param name="display_order">Display order.</param>
        /// <param name="display_in_list">If true, display node in list.</param>
        /// <returns></returns>
        public NodeResponse Create(string title, long parent_node_id, string node_type_id, Dictionary<string, object> type_data = null, string node_name = null, string description = null, long? display_order = null, bool? display_in_list = null)
        {
            RestRequest request = CreateRequest("nodes", Method.Post);
            AddParameter(request, "node[title]", title);
            AddParameter(request, "node[parent_node_id]", parent_node_id);
            AddParameter(request, "node_type_id", node_type_id);
            AddParameter(request, "node[node_name]", node_name);
            AddParameter(request, "node[description]", description);
            AddParameter(request, "node[display_order]", display_order);
            AddParameter(request, "node[display_in_list]", display_in_list);
            AddJsonParameter(request, "type_data", type_data);

            return Execute<NodeResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified node.
        /// </summary>
        /// <param name="id">Node id.</param>
        /// <returns></returns>
        public NodeResponse GetById(long id)
        {
            RestRequest request = CreateRequest("nodes/" + id, Method.Get);
            return Execute<NodeResponse>(request);
        }

        /// <summary>
        /// Updates the specified node.
        /// </summary>
        /// <param name="id">Node id.</param>
        /// <param name="title">Node title.</param>
        /// <param name="parent_node_id">Parent node id.</param>
        /// <param name="type_data">Type-specific node data.</param>
        /// <param name="node_name">Node name.</param>
        /// <param name="description">Node description.</param>
        /// <param name="display_order">Display order.</param>
        /// <param name="display_in_list">If true, display node in list.</param>
        /// <returns></returns>
        public NodeResponse UpdateById(long id, string title = null, long? parent_node_id = null, Dictionary<string, object> type_data = null, string node_name = null, string description = null, long? display_order = null, bool? display_in_list = null)
        {
            RestRequest request = CreateRequest("nodes/" + id, Method.Post);
            AddParameter(request, "node[title]", title);
            AddParameter(request, "node[parent_node_id]", parent_node_id);
            AddParameter(request, "node[node_name]", node_name);
            AddParameter(request, "node[description]", description);
            AddParameter(request, "node[display_order]", display_order);
            AddParameter(request, "node[display_in_list]", display_in_list);
            AddJsonParameter(request, "type_data", type_data);

            return Execute<NodeResponse>(request);
        }

        /// <summary>
        /// Deletes the specified node.
        /// </summary>
        /// <param name="id">Node id.</param>
        /// <param name="delete_children">If true, delete child nodes as well.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, bool? delete_children = null)
        {
            RestRequest request = CreateRequest("nodes/" + id, Method.Delete);
            AddParameter(request, "delete_children", delete_children);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Get a flattened node tree.
        /// </summary>
        /// <returns></returns>
        public FlattenedNodesResponse GetFlattened()
        {
            RestRequest request = CreateRequest("nodes/flattened", Method.Get);
            return Execute<FlattenedNodesResponse>(request);
        }

        public class NodesResponse
        {
            [JsonProperty("tree_map")]
            public Dictionary<long, List<long>> TreeMap;

            [JsonProperty("nodes")]
            public List<XfModels.Node> Nodes;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class NodeResponse
        {
            [JsonProperty("node")]
            public XfModels.Node Node;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class FlattenedNodesResponse
        {
            [JsonProperty("nodes_flat")]
            public List<XfModels.Node> Nodes;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

