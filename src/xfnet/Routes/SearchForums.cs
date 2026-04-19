using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class SearchForums : RouteBase
    {
        public SearchForums(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Gets information about the specified search forum.
        /// </summary>
        /// <param name="id">Search forum id.</param>
        /// <param name="with_threads">If true, includes threads.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public SearchForumThreadsResponse GetById(long id, bool? with_threads = null, long? page = null)
        {
            RestRequest request = CreateRequest("search-forums/" + id, Method.Get);
            AddParameter(request, "with_threads", with_threads);
            AddParameter(request, "page", page);

            return Execute<SearchForumThreadsResponse>(request);
        }

        /// <summary>
        /// Gets threads from the specified search forum.
        /// </summary>
        /// <param name="id">Search forum id.</param>
        /// <returns></returns>
        public SearchForumThreadsResponse GetThreadsById(long id)
        {
            RestRequest request = CreateRequest("search-forums/" + id + "/threads", Method.Get);
            return Execute<SearchForumThreadsResponse>(request);
        }

        public class SearchForumThreadsResponse
        {
            [JsonProperty("threads")]
            public List<XfModels.Thread> Threads;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("sticky")]
            public List<XfModels.Thread> Sticky;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

