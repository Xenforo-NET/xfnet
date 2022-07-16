using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xfnet.Models
{
    /// <summary>
    /// Data type: User. Information about the user. Different information will be included based on permissions and verbosity. See https://xenforo.com/community/pages/api-endpoints/#type_User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string about { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? activity_visible { get; set; }

        /// <summary>
        /// (Conditionally returned) The user's current age. Only included if available.
        /// </summary>
        public long? age { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public List<object> alert_optout { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string allow_post_profile { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string allow_receive_news_feed { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string allow_send_personal_conversation { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string allow_view_identities { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string allow_view_profile { get; set; }

        /// <summary>
        /// Maps from size types to URL.
        /// </summary>
        public ImageSizes avatar_urls { get; set; }

        /// <summary>
        /// Maps from size types to URL.
        /// </summary>
        public ImageSizes profile_banner_urls { get; set; }

        public bool? can_ban { get; set; }

        public bool? can_converse { get; set; }

        public bool? can_edit { get; set; }

        public bool? can_follow { get; set; }

        public bool? can_ignore { get; set; }

        public bool? can_post_profile { get; set; }

        public bool? can_view_profile { get; set; }

        public bool? can_view_profile_posts { get; set; }

        public bool? can_warn { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? content_show_signature { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string creation_watch_state { get; set; }

        /// <summary>
        /// Map of custom field keys and values. Returned only if permissions are met.
        /// </summary>
        public Dictionary<string, string> custom_fields { get; set; }

        /// <summary>
        /// Will have a value if a custom title has been specifically set; prefer user_title instead. Returned only if permissions are met.
        /// </summary>
        public string custom_title { get; set; }

        /// <summary>
        /// Date of birth with year, month and day keys. Returned only if permissions are met.
        /// </summary>
        public Date dob { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? email_on_conversation { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string gravatar { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? interaction_watch_state { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? is_admin { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? is_banned { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? is_discouraged { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the visitor is following this user. Only included if visitor is not a guest.
        /// </summary>
        public bool? is_followed { get; set; }

        /// <summary>
        /// (Conditionally returned) True if the visitor is following this user. Only included if visitor is not a guest.
        /// </summary>
        public bool? is_ignored { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? is_moderator { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? is_super_admin { get; set; }

        /// <summary>
        /// Unix timestamp of user's last activity, if available. Returned only if permissions are met.
        /// </summary>
        public long? last_activity { get; set; }

        public string location { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? push_on_conversation { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public List<object> push_optout { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? receive_admin_email { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public List<long> secondary_group_ids { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? show_dob_date { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? show_dob_year { get; set; }

        public string signature { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public string timezone { get; set; }

        /// <summary>
        /// (Verbose results only) Returned only if permissions are met.
        /// </summary>
        public bool? use_tfa { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public long? user_group_id { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public string user_state { get; set; }

        public string user_title { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public bool? visible { get; set; }

        /// <summary>
        /// Current warning points. Returned only if permissions are met.
        /// </summary>
        public long? warning_points { get; set; }

        /// <summary>
        /// Returned only if permissions are met.
        /// </summary>
        public string website { get; set; }

        public string view_url { get; set; }

        public long? user_id { get; set; }

        public string username { get; set; }

        public long? message_count { get; set; }

        public long? question_solution_count { get; set; }

        public long? register_date { get; set; }

        public long? trophy_points { get; set; }

        public bool? is_staff { get; set; }

        public long? reaction_score { get; set; }

        public long? vote_score { get; set; }
    }
}
