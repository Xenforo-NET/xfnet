using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class Stats : RouteBase
    {
        public Stats(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get site statistics.
        /// </summary>
        /// <returns></returns>
        public StatsResponse Get()
        {
            RestRequest request = CreateRequest("stats", Method.Get);
            return Execute<StatsResponse>(request);
        }

        public class StatsResponse
        {
            [JsonProperty("totals[threads]")]
            public long? TotalThreads;

            [JsonProperty("totals[messages]")]
            public long? TotalMessages;

            [JsonProperty("totals[users]")]
            public long? TotalUsers;

            [JsonProperty("latest_user[user_id]")]
            public long? LatestUserId;

            [JsonProperty("latest_user[username]")]
            public string LatestUsername;

            [JsonProperty("latest_user[register_date]")]
            public long? LatestUserRegisterDate;

            [JsonProperty("online[total]")]
            public long? OnlineTotal;

            [JsonProperty("online[members]")]
            public long? OnlineMembers;

            [JsonProperty("online[guests]")]
            public long? OnlineGuests;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

