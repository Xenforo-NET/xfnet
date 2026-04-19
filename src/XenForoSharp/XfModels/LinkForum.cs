using Newtonsoft.Json;

namespace XenForoSharp.XfModels
{
    /// <summary>
    /// Data type: LinkForum. See https://xenforo.com/community/pages/api-endpoints/#type_LinkForum.
    /// </summary>
    public class LinkForum
    {
        [JsonProperty("link_url")]
        public string LinkUrl { get; set; }

        [JsonProperty("redirect_count")]
        public long? RedirectCount { get; set; }
    }
}

