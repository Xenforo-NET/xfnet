using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class Search : RouteBase
    {
        public Search(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Create a new search.
        /// </summary>
        /// <param name="search_type">Search type.</param>
        /// <param name="keywords">Search keywords.</param>
        /// <param name="constraints">Search constraints.</param>
        /// <param name="order">Result order.</param>
        /// <param name="grouped">If true, groups results.</param>
        /// <returns></returns>
        public SearchResponse Create(string search_type = null, string keywords = null, object constraints = null, string order = null, bool? grouped = null)
        {
            RestRequest request = CreateRequest("search", Method.Post);
            AddParameter(request, "search_type", search_type);
            AddParameter(request, "keywords", keywords);
            AddJsonParameter(request, "c", constraints);
            AddParameter(request, "order", order);
            AddParameter(request, "grouped", grouped);

            return Execute<SearchResponse>(request);
        }

        /// <summary>
        /// Gets information and results for the specified search.
        /// </summary>
        /// <param name="id">Search id.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public SearchResultsResponse GetById(long id, long? page = null)
        {
            RestRequest request = CreateRequest("search/" + id, Method.Get);
            AddParameter(request, "page", page);

            return Execute<SearchResultsResponse>(request);
        }

        /// <summary>
        /// Gets older results for the specified search.
        /// </summary>
        /// <param name="id">Search id.</param>
        /// <param name="before">Unix timestamp to search before.</param>
        /// <returns></returns>
        public SearchResponse GetOlderById(long id, long before)
        {
            RestRequest request = CreateRequest("search/" + id + "/older", Method.Post);
            AddParameter(request, "search_id", id);
            AddParameter(request, "before", before);

            return Execute<SearchResponse>(request);
        }

        /// <summary>
        /// Create a member search.
        /// </summary>
        /// <param name="user_id">User id.</param>
        /// <param name="content">Content type filter.</param>
        /// <param name="type">Search type.</param>
        /// <param name="before">Unix timestamp to search before.</param>
        /// <param name="thread_type">Thread type filter.</param>
        /// <param name="grouped">If true, groups results.</param>
        /// <returns></returns>
        public SearchResponse CreateMemberSearch(long user_id, string content = null, string type = null, long? before = null, string thread_type = null, bool? grouped = null)
        {
            RestRequest request = CreateRequest("search/member", Method.Post);
            AddParameter(request, "user_id", user_id);
            AddParameter(request, "content", content);
            AddParameter(request, "type", type);
            AddParameter(request, "before", before);
            AddParameter(request, "thread_type", thread_type);
            AddParameter(request, "grouped", grouped);

            return Execute<SearchResponse>(request);
        }

        public class SearchResponse : SuccessResponse
        {
            [JsonProperty("search")]
            public XfModels.Search Search;
        }

        public class SearchResultsResponse
        {
            [JsonProperty("search")]
            public XfModels.Search Search;

            [JsonProperty("results")]
            public List<object> Results;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("get_older_results_date")]
            public long? GetOlderResultsDate;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}
