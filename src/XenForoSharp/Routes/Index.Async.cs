using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Index
    {
        public Task<IndexResponse> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("index", Method.Get);
            return ExecuteAsync<IndexResponse>(request, cancellationToken);
        }
    }
}
