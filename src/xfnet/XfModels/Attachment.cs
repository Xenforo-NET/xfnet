using Newtonsoft.Json;
using System;

namespace XenForoSharp.XfModels
{
    /// <summary>
    /// Data type: Attachment. See https://xenforo.com/community/pages/api-endpoints/#type_Attachment.
    /// </summary>
    public class Attachment
    {
        long? _attachDateUnix;

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

        [JsonProperty("retina_thumbnail_url")]
        public string RetinaThumbnailUrl { get; set; }

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
        public long? AttachDateUnix
        {
            get { return _attachDateUnix; }
            set
            {
                _attachDateUnix = value;
                if (!value.HasValue)
                    AttachDate = null;
                else
                    AttachDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? AttachDate { get; set; }

        [JsonProperty("view_count")]
        public long? ViewCount { get; set; }
    }
}

