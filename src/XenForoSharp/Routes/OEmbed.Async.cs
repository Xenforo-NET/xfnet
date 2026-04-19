using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class OEmbed
    {
        public Task<OEmbedResponse> GetByUrlAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("oembed", Method.Get);
            AddParameter(request, "url", url);

            return ExecuteAsync<OEmbedResponse>(request, cancellationToken);
        }
    }
}
