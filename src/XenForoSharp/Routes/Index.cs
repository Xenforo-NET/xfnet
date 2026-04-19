using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public partial class Index : RouteBase
    {
        public Index(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get site and API information.
        /// </summary>
        /// <returns></returns>
        public IndexResponse Get()
        {
            RestRequest request = CreateRequest("index", Method.Get);
            return Execute<IndexResponse>(request);
        }

        public class IndexResponse
        {
            [JsonProperty("version_id")]
            public long? VersionId;

            [JsonProperty("site_title")]
            public string SiteTitle;

            [JsonProperty("base_url")]
            public string BaseUrl;

            [JsonProperty("api_url")]
            public string ApiUrl;

            [JsonProperty("key[type]")]
            public string KeyType;

            [JsonProperty("key[user_id]")]
            public long? KeyUserId;

            [JsonProperty("key[allow_all_scopes]")]
            public bool? KeyAllowAllScopes;

            [JsonProperty("key[scopes]")]
            public List<string> KeyScopes;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

