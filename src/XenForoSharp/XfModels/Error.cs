using System.Collections.Generic;
using Newtonsoft.Json;

namespace XenForoSharp.XfModels
{
    public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("params")]
        public Dictionary<string, string> Params { get; set; }
    }
}

