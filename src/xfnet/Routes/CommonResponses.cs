using Newtonsoft.Json;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class SuccessResponse
    {
        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("errors")]
        public List<XfModels.Error> Errors;
    }

    public class ActionResponse : SuccessResponse
    {
        [JsonProperty("action")]
        public string Action;
    }

    public class UrlResponse : SuccessResponse
    {
        [JsonProperty("url")]
        public string Url;
    }
}

