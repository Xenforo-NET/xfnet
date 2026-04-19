using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class SearchForums
    {
        public Task<SearchForumThreadsResponse> GetByIdAsync(long id, bool? with_threads = null, long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("search-forums/" + id, Method.Get);
            AddParameter(request, "with_threads", with_threads);
            AddParameter(request, "page", page);

            return ExecuteAsync<SearchForumThreadsResponse>(request, cancellationToken);
        }

        public Task<SearchForumThreadsResponse> GetThreadsByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("search-forums/" + id + "/threads", Method.Get);
            return ExecuteAsync<SearchForumThreadsResponse>(request, cancellationToken);
        }
    }
}
