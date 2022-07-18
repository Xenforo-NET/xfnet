using Newtonsoft.Json;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Attachment. See https://xenforo.com/community/pages/api-endpoints/#type_Attachment.
    /// </summary>
    public class Attachment
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("file_size")]
        public long? FileSize { get; set; }

        [JsonProperty("height")]
        public long? Height { get; set; }

        [JsonProperty("width")]
        public long? Width { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("direct_url")]
        public string DirectUrl { get; set; }

        [JsonProperty("is_video")]
        public bool? IsVideo { get; set; }

        [JsonProperty("is_audio")]
        public bool? IsAudio { get; set; }

        [JsonProperty("attachment_id")]
        public long? AttachmentId { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("content_id")]
        public long? ContentId { get; set; }

        [JsonProperty("attach_date")]
        public long? AttachDate { get; set; }

        [JsonProperty("view_count")]
        public long? ViewCount { get; set; }
    }
}
