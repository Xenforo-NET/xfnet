using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Featured
    {
        public Task<FeaturedResponse> GetAllAsync(long? page = null, string content_type = null, long? user_id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("featured", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "content_type", content_type);
            AddParameter(request, "user_id", user_id);

            return ExecuteAsync<FeaturedResponse>(request, cancellationToken);
        }
    }
}
