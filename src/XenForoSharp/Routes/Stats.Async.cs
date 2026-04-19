using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Stats
    {
        public Task<StatsResponse> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("stats", Method.Get);
            return ExecuteAsync<StatsResponse>(request, cancellationToken);
        }
    }
}
