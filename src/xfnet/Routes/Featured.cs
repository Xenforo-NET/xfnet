using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class Featured : RouteBase
    {
        public Featured(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get a list of featured content.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="content_type">Optional content type filter.</param>
        /// <param name="user_id">Optional content owner filter.</param>
        /// <returns></returns>
        public FeaturedResponse GetAll(long? page = null, string content_type = null, long? user_id = null)
        {
            RestRequest request = CreateRequest("featured", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "content_type", content_type);
            AddParameter(request, "user_id", user_id);

            return Execute<FeaturedResponse>(request);
        }

        public class FeaturedResponse
        {
            [JsonProperty("features")]
            public List<XfModels.FeaturedContent> Features;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

