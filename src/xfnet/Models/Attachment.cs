namespace xfnet.Models
{
    /// <summary>
    /// Data type: Attachment. See https://xenforo.com/community/pages/api-endpoints/#type_Attachment.
    /// </summary>
    public class Attachment
    {
        public string filename { get; set; }

        public long? file_size { get; set; }

        public long? height { get; set; }

        public long? width { get; set; }

        public string thumbnail_url { get; set; }

        public string direct_url { get; set; }

        public bool? is_video { get; set; }

        public bool? is_audio { get; set; }

        public long? attachment_id { get; set; }

        public string content_type { get; set; }

        public long? content_id { get; set; }

        public long? attach_date { get; set; }

        public long? view_count { get; set; }
    }
}
