using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Nodes
    {
        public Task<NodesResponse> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("nodes", Method.Get);
            return ExecuteAsync<NodesResponse>(request, cancellationToken);
        }

        public Task<NodeResponse> CreateAsync(string title, long parent_node_id, string node_type_id, Dictionary<string, object> type_data = null, string node_name = null, string description = null, long? display_order = null, bool? display_in_list = null, CancellationToken cancellationToken = default(CancellationToken))
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

            return ExecuteAsync<NodeResponse>(request, cancellationToken);
        }

        public Task<NodeResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("nodes/" + id, Method.Get);
            return ExecuteAsync<NodeResponse>(request, cancellationToken);
        }

        public Task<NodeResponse> UpdateByIdAsync(long id, string title = null, long? parent_node_id = null, Dictionary<string, object> type_data = null, string node_name = null, string description = null, long? display_order = null, bool? display_in_list = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("nodes/" + id, Method.Post);
            AddParameter(request, "node[title]", title);
            AddParameter(request, "node[parent_node_id]", parent_node_id);
            AddParameter(request, "node[node_name]", node_name);
            AddParameter(request, "node[description]", description);
            AddParameter(request, "node[display_order]", display_order);
            AddParameter(request, "node[display_in_list]", display_in_list);
            AddJsonParameter(request, "type_data", type_data);

            return ExecuteAsync<NodeResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, bool? delete_children = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("nodes/" + id, Method.Delete);
            AddParameter(request, "delete_children", delete_children);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<FlattenedNodesResponse> GetFlattenedAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("nodes/flattened", Method.Get);
            return ExecuteAsync<FlattenedNodesResponse>(request, cancellationToken);
        }
    }
}
