using Newtonsoft.Json;
using System;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: Page. See https://xenforo.com/community/pages/api-endpoints/#type_Page.
    /// </summary>
    public class Page
    {
        [JsonProperty("publish_date")]
        public long? PublishDateUnix
        {
            get { return PublishDateUnix; }
            set
            {
                PublishDateUnix = value;
                if (!value.HasValue)
                    PublishDate = null;
                else
                    PublishDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? PublishDate { get; set; }

        [JsonProperty("view_count")]
        public long? ViewCount { get; set; }
    }
}
