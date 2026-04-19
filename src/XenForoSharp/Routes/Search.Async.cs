using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Search
    {
        public Task<SearchResponse> CreateAsync(string search_type = null, string keywords = null, object constraints = null, string order = null, bool? grouped = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("search", Method.Post);
            AddParameter(request, "search_type", search_type);
            AddParameter(request, "keywords", keywords);
            AddJsonParameter(request, "c", constraints);
            AddParameter(request, "order", order);
            AddParameter(request, "grouped", grouped);

            return ExecuteAsync<SearchResponse>(request, cancellationToken);
        }

        public Task<SearchResultsResponse> GetByIdAsync(long id, long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("search/" + id, Method.Get);
            AddParameter(request, "page", page);

            return ExecuteAsync<SearchResultsResponse>(request, cancellationToken);
        }

        public Task<SearchResponse> GetOlderByIdAsync(long id, long before, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("search/" + id + "/older", Method.Post);
            AddParameter(request, "search_id", id);
            AddParameter(request, "before", before);

            return ExecuteAsync<SearchResponse>(request, cancellationToken);
        }

        public Task<SearchResponse> CreateMemberSearchAsync(long user_id, string content = null, string type = null, long? before = null, string thread_type = null, bool? grouped = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("search/member", Method.Post);
            AddParameter(request, "user_id", user_id);
            AddParameter(request, "content", content);
            AddParameter(request, "type", type);
            AddParameter(request, "before", before);
            AddParameter(request, "thread_type", thread_type);
            AddParameter(request, "grouped", grouped);

            return ExecuteAsync<SearchResponse>(request, cancellationToken);
        }
    }
}
