using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class OEmbed : RouteBase
    {
        public OEmbed(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Look up oEmbed information for a URL.
        /// </summary>
        /// <param name="url">The URL to look up.</param>
        /// <returns></returns>
        public OEmbedResponse GetByUrl(string url)
        {
            RestRequest request = CreateRequest("oembed", Method.Get);
            AddParameter(request, "url", url);

            return Execute<OEmbedResponse>(request);
        }

        public class OEmbedResponse
        {
            [JsonProperty("version")]
            public string Version;

            [JsonProperty("type")]
            public string Type;

            [JsonProperty("provider_name")]
            public string ProviderName;

            [JsonProperty("provider_url")]
            public string ProviderUrl;

            [JsonProperty("author_name")]
            public string AuthorName;

            [JsonProperty("author_url")]
            public string AuthorUrl;

            [JsonProperty("html")]
            public string Html;

            [JsonProperty("referrer")]
            public string Referrer;

            [JsonProperty("cache_age")]
            public long? CacheAge;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}
