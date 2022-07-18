using Newtonsoft.Json;
using System.Collections.Generic;

namespace xfnet.XfModels
{
    /// <summary>
    /// Data type: User. Information about the user. Different information will be included based on permissions and verbosity. See https://xenforo.com/community/pages/api-endpoints/#type_User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("about")]
        public string About { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("activity_visible")]
        public bool? ActivityVisible { get; set; }

        /// <summary>
        /// (Conditionally returned) The user's current age. Only included if available.
        /// </summary>
        [JsonProperty("age")]
        public long? Age { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("alert_optout")]
        public List<object> AlertOptout { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("allow_post_profile")]
        public string AllowPostProfile { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("allow_receive_news_feed")]
        public string AllowReceiveNewsFeed { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("allow_send_personal_conversation")]
        public string AllowSendPersonalConversation { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("allow_view_identities")]
        public string AllowViewIdentities { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("allow_view_profile")]
        public string AllowViewProfile { get; set; }

        /// <summary>
        /// Maps from size types to URL.
        /// </summary>
        [JsonProperty("avatar_urls")]
        public ImageSizes AvatarUrls { get; set; }

        /// <summary>
        /// Maps from size types to URL.
        /// </summary>
        [JsonProperty("profile_banner_urls")]
        public ImageSizes ProfileBannerUrls { get; set; }

        [JsonProperty("can_ban")]
        public bool? CanBan { get; set; }

        [JsonProperty("can_converse")]
        public bool? CanConverse { get; set; }

        [JsonProperty("can_edit")]
        public bool? CanEdit { get; set; }

        [JsonProperty("can_follow")]
        public bool? CanFollow { get; set; }

        [JsonProperty("can_ignore")]
        public bool? CanIgnore { get; set; }

        [JsonProperty("can_post_profile")]
        public bool? CanPostProfile { get; set; }

        [JsonProperty("can_view_profile")]
        public bool? CanViewProfile { get; set; }

        [JsonProperty("can_view_profile_posts")]
        public bool? CanViewProfilePosts { get; set; }

        [JsonProperty("can_warn")]
        public bool? CanWarn { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("content_show_signature")]
        public bool? ContentShowSignature { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("creation_watch_state")]
        public string CreationWatchState { get; set; }

        /// <summary>
        /// Map of custom field keys and values. Returned only if permissions are met.
        /// </summary>
        [JsonProperty("custom_fields")]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Will have a value if a custom title has been specifically set; prefer user_title instead. Returned only if permissions are met.
        /// </summary>
        [JsonProperty("custom_title")]
        public string CustomTitle { get; set; }

        /// <summary>
        /// Date of birth with year, month and day keys. Returned only if permissions are met.
        /// </summary>
        [JsonProperty("dob")]
        public XfDate DateOfBirth { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("email_on_conversation")]
        public bool? EmailOnConversation { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("gravatar")]
        public string Gravatar { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("interaction_watch_state")]
        public bool? InteractionWatchState { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("is_admin")]
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("is_banned")]
        public bool? IsBanned { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("is_discouraged")]
        public bool? IsDiscouraged { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the visitor is following this user. Only included if visitor is not a guest.
        /// </summary>
        [JsonProperty("is_followed")]
        public bool? IsFollowed { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the visitor is following this user. Only included if visitor is not a guest.
        /// </summary>
        [JsonProperty("is_ignored")]
        public bool? IsIgnored { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("is_moderator")]
        public bool? IsModerator { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("is_super_admin")]
        public bool? IsSuperAdmin { get; set; }

        /// <summary>
        /// Unix timestamp of user's last activity, if available. Returned only if permissions are met.
        /// </summary>
        [JsonProperty("last_activity")]
        public long? LastActivity { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("push_on_conversation")]
        public bool? PushOnConversation { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("push_optout")]
        public List<object> PushOptout { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("receive_admin_email")]
        public bool? ReceiveAdminEmail { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("secondary_group_ids")]
        public List<long> SecondaryGroupIds { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("show_dob_date")]
        public bool? ShowDobDate { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("show_dob_year")]
        public bool? ShowDobYear { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        [JsonProperty("use_tfa")]
        public bool? UseTFA { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("user_group_id")]
        public long? UserGroupId { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("user_state")]
        public string UserState { get; set; }

        [JsonProperty("user_title")]
        public string UserTitle { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("visible")]
        public bool? Visible { get; set; }

        /// <summary>
        /// Current warning points. Returned only if permissions are met.
        /// </summary>
        [JsonProperty("warning_points")]
        public long? WarningPoints { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("message_count")]
        public long? MessageCount { get; set; }

        [JsonProperty("question_solution_count")]
        public long? QuestionSolutionCount { get; set; }

        [JsonProperty("register_date")]
        public long? RegisterDate { get; set; }

        [JsonProperty("trophy_points")]
        public long? TrophyPoints { get; set; }

        [JsonProperty("is_staff")]
        public bool? IsStaff { get; set; }

        [JsonProperty("reaction_score")]
        public long? ReactionScore { get; set; }

        [JsonProperty("vote_score")]
        public long? VoteScore { get; set; }
    }
}
