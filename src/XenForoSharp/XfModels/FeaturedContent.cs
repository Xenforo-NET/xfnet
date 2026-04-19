using Newtonsoft.Json;
using System;

namespace XenForoSharp.XfModels
{
    /// <summary>
    /// Data type: FeaturedContent. See https://docs.xenforo.com/api.
    /// </summary>
    public class FeaturedContent
    {
        long? _unfeatureDateUnix;
        long? _contentDateUnix;
        long? _featureDateUnix;
        long? _imageDateUnix;

        [JsonProperty("content_username")]
        public string ContentUsername { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        [JsonProperty("can_view_content")]
        public bool? CanViewContent { get; set; }

        [JsonProperty("feature_user_id")]
        public long? FeatureUserId { get; set; }

        [JsonProperty("unfeature_date")]
        public long? UnfeatureDateUnix
        {
            get { return _unfeatureDateUnix; }
            set
            {
                _unfeatureDateUnix = value;
                if (!value.HasValue)
                    UnfeatureDate = null;
                else
                    UnfeatureDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? UnfeatureDate { get; set; }

        [JsonProperty("auto_featured")]
        public bool? AutoFeatured { get; set; }

        [JsonProperty("always_visible")]
        public bool? AlwaysVisible { get; set; }

        [JsonProperty("unfeature_days")]
        public long? UnfeatureDays { get; set; }

        [JsonProperty("is_customized")]
        public bool? IsCustomized { get; set; }

        [JsonProperty("featured_content_id")]
        public long? FeaturedContentId { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("content_id")]
        public long? ContentId { get; set; }

        [JsonProperty("content_container_id")]
        public long? ContentContainerId { get; set; }

        [JsonProperty("content_user_id")]
        public long? ContentUserId { get; set; }

        [JsonProperty("content_date")]
        public long? ContentDateUnix
        {
            get { return _contentDateUnix; }
            set
            {
                _contentDateUnix = value;
                if (!value.HasValue)
                    ContentDate = null;
                else
                    ContentDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? ContentDate { get; set; }

        [JsonProperty("content_visible")]
        public bool? ContentVisible { get; set; }

        [JsonProperty("feature_date")]
        public long? FeatureDateUnix
        {
            get { return _featureDateUnix; }
            set
            {
                _featureDateUnix = value;
                if (!value.HasValue)
                    FeatureDate = null;
                else
                    FeatureDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? FeatureDate { get; set; }

        [JsonProperty("image_date")]
        public long? ImageDateUnix
        {
            get { return _imageDateUnix; }
            set
            {
                _imageDateUnix = value;
                if (!value.HasValue)
                    ImageDate = null;
                else
                    ImageDate = Utilities.DateConvert.UnixTimeStampToDateTime(Convert.ToDouble(value.Value));
            }
        }

        [JsonIgnore]
        public DateTime? ImageDate { get; set; }

        [JsonProperty("ContentUser")]
        public User ContentUser { get; set; }
    }
}

