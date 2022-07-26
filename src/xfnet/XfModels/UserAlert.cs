using Newtonsoft.Json;
using System;

namespace xfnet.XfModels
{
    public class UserAlert
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("alert_id")]
        public long? AlertId { get; set; }

        [JsonProperty("alert_text")]
        public string AlertText { get; set; }

        [JsonProperty("alert_url")]
        public string AlertUrl { get; set; }

        [JsonProperty("alerted_user_id")]
        public long? AlertedUserId { get; set; }

        [JsonProperty("auto_read")]
        public bool? AutoRead { get; set; }

        [JsonProperty("content_id")]
        public long? ContentId { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("event_date")]
        public long? EventDateUnix { 
            get { return EventDateUnix; }
            set
            {
                EventDateUnix = value;
                if (!value.HasValue)
                    EventDate = null;
                else
                    EventDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        public DateTime? EventDate { get; set; }

        public bool IsReaded { get; set; }

        [JsonProperty("read_date")]
        public long? ReadDateUnix
        {
            get { return ReadDateUnix; }
            set
            {
                ReadDateUnix = value;
                if (value.HasValue)
                {
                    if (!value.HasValue)
                    {
                        ReadDate = null;
                        IsReaded = false;
                    }
                    else
                    {
                        ReadDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
                        IsReaded = value.Value != 0;
                    }
                }
            }
        }

        public DateTime? ReadDate { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("username")]
        public long? Username { get; set; }

        public bool IsViewed { get; set; }

        [JsonProperty("view_date")]
        public long? ViewDateUnix
        {
            get { return ViewDateUnix; }
            set
            {
                ViewDateUnix = value;
                if (value.HasValue)
                {
                    if (!value.HasValue)
                    {
                        ViewDate = null;
                        IsViewed = false;
                    }
                    else
                    {
                        ViewDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
                        IsViewed = value.Value != 0;
                    }
                }
            }
        }

        public DateTime? ViewDate { get; set; }
    }
}
