using Newtonsoft.Json;
using System;

namespace xfnet.XfModels
{
    public class UserAlert
    {
        long? _eventDateUnix;
        long? _readDateUnix;
        long? _viewDateUnix;

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
            get { return _eventDateUnix; }
            set
            {
                _eventDateUnix = value;
                if (!value.HasValue)
                    EventDate = null;
                else
                    EventDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? EventDate { get; set; }

        public bool IsReaded { get; set; }

        [JsonProperty("read_date")]
        public long? ReadDateUnix
        {
            get { return _readDateUnix; }
            set
            {
                _readDateUnix = value;
                if (!value.HasValue || value.Value == 0)
                {
                    ReadDate = null;
                    IsReaded = false;
                }
                else
                {
                    ReadDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
                    IsReaded = true;
                }
            }
        }

        [JsonIgnore]
        public DateTime? ReadDate { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        public bool IsViewed { get; set; }

        [JsonProperty("view_date")]
        public long? ViewDateUnix
        {
            get { return _viewDateUnix; }
            set
            {
                _viewDateUnix = value;
                if (!value.HasValue || value.Value == 0)
                {
                    ViewDate = null;
                    IsViewed = false;
                }
                else
                {
                    ViewDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
                    IsViewed = true;
                }
            }
        }

        [JsonIgnore]
        public DateTime? ViewDate { get; set; }
    }
}
