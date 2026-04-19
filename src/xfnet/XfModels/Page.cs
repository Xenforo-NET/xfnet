using Newtonsoft.Json;
using System;

namespace XenForoSharp.XfModels
{
    /// <summary>
    /// Data type: Page. See https://xenforo.com/community/pages/api-endpoints/#type_Page.
    /// </summary>
    public class Page
    {
        long? _publishDateUnix;

        [JsonProperty("publish_date")]
        public long? PublishDateUnix
        {
            get { return _publishDateUnix; }
            set
            {
                _publishDateUnix = value;
                if (!value.HasValue)
                    PublishDate = null;
                else
                    PublishDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? PublishDate { get; set; }

        [JsonProperty("view_count")]
        public long? ViewCount { get; set; }
    }
}

