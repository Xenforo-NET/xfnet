using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class Users : RouteBase
    {
        public Users(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public UsersResponse GetAll(long? page = null)
        {
            RestRequest request = CreateRequest("users", Method.Get);
            AddParameter(request, "page", page);

            return Execute<UsersResponse>(request);
        }

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="options">Map of option values.</param>
        /// <param name="profile">Map of profile values.</param>
        /// <param name="privacy">Map of privacy values.</param>
        /// <param name="custom_fields">Map of custom field values.</param>
        /// <param name="visible"></param>
        /// <param name="activity_visible"></param>
        /// <param name="timezone"></param>
        /// <param name="custom_title"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="user_group_id"></param>
        /// <param name="secondary_group_ids"></param>
        /// <param name="user_state"></param>
        /// <param name="is_staff"></param>
        /// <param name="message_count"></param>
        /// <param name="reaction_score"></param>
        /// <param name="trophy_points"></param>
        /// <param name="username_change_visible"></param>
        /// <param name="password"></param>
        /// <param name="dob_day"></param>
        /// <param name="dob_month"></param>
        /// <param name="dob_year"></param>
        /// <returns></returns>
        public UserResponse Create(Dictionary<string, object> options = null, Dictionary<string, object> profile = null, Dictionary<string, object> privacy = null, Dictionary<string, object> custom_fields = null, bool? visible = null, bool? activity_visible = null, string timezone = null, string custom_title = null, string username = null, string email = null, long? user_group_id = null, IEnumerable<long> secondary_group_ids = null, string user_state = null, bool? is_staff = null, long? message_count = null, long? reaction_score = null, long? trophy_points = null, bool? username_change_visible = null, string password = null, int? dob_day = null, int? dob_month = null, int? dob_year = null)
        {
            RestRequest request = CreateRequest("users", Method.Post);
            AddWritableParameters(request, options, profile, privacy, custom_fields, visible, activity_visible, timezone, custom_title, username, email, user_group_id, secondary_group_ids, user_state, is_staff, message_count, reaction_score, trophy_points, username_change_visible, password, dob_day, dob_month, dob_year);

            return Execute<UserResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="with_posts">If true, includes profile posts.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public UserWithProfilePostsResponse GetById(long id, bool? with_posts = null, long? page = null)
        {
            RestRequest request = CreateRequest("users/" + id, Method.Get);
            AddParameter(request, "with_posts", with_posts);
            AddParameter(request, "page", page);

            return Execute<UserWithProfilePostsResponse>(request);
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="options">Map of option values.</param>
        /// <param name="profile">Map of profile values.</param>
        /// <param name="privacy">Map of privacy values.</param>
        /// <param name="custom_fields">Map of custom field values.</param>
        /// <param name="visible"></param>
        /// <param name="activity_visible"></param>
        /// <param name="timezone"></param>
        /// <param name="custom_title"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="user_group_id"></param>
        /// <param name="secondary_group_ids"></param>
        /// <param name="user_state"></param>
        /// <param name="is_staff"></param>
        /// <param name="message_count"></param>
        /// <param name="reaction_score"></param>
        /// <param name="trophy_points"></param>
        /// <param name="username_change_visible"></param>
        /// <param name="password"></param>
        /// <param name="dob_day"></param>
        /// <param name="dob_month"></param>
        /// <param name="dob_year"></param>
        /// <returns></returns>
        public UserResponse UpdateById(long id, Dictionary<string, object> options = null, Dictionary<string, object> profile = null, Dictionary<string, object> privacy = null, Dictionary<string, object> custom_fields = null, bool? visible = null, bool? activity_visible = null, string timezone = null, string custom_title = null, string username = null, string email = null, long? user_group_id = null, IEnumerable<long> secondary_group_ids = null, string user_state = null, bool? is_staff = null, long? message_count = null, long? reaction_score = null, long? trophy_points = null, bool? username_change_visible = null, string password = null, int? dob_day = null, int? dob_month = null, int? dob_year = null)
        {
            RestRequest request = CreateRequest("users/" + id, Method.Post);
            AddWritableParameters(request, options, profile, privacy, custom_fields, visible, activity_visible, timezone, custom_title, username, email, user_group_id, secondary_group_ids, user_state, is_staff, message_count, reaction_score, trophy_points, username_change_visible, password, dob_day, dob_month, dob_year);

            return Execute<UserResponse>(request);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="rename_to">Optional username to rename the account to before deletion.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, string rename_to = null)
        {
            RestRequest request = CreateRequest("users/" + id, Method.Delete);
            AddParameter(request, "rename_to", rename_to);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Upload a new avatar for the specified user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="avatar_bytes">Avatar bytes.</param>
        /// <param name="file_name">Avatar file name.</param>
        /// <returns></returns>
        public SuccessResponse UploadAvatarById(long id, byte[] avatar_bytes, string file_name)
        {
            RestRequest request = CreateRequest("users/" + id + "/avatar", Method.Post);
            AddFile(request, "avatar", avatar_bytes, file_name);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Deletes the specified user's avatar.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns></returns>
        public SuccessResponse DeleteAvatarById(long id)
        {
            RestRequest request = CreateRequest("users/" + id + "/avatar", Method.Delete);
            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Gets profile posts for the specified user.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ProfilePostsResponse GetProfilePostsById(long id, long? page = null)
        {
            RestRequest request = CreateRequest("users/" + id + "/profile-posts", Method.Get);
            AddParameter(request, "page", page);

            return Execute<ProfilePostsResponse>(request);
        }

        /// <summary>
        /// Finds a user by email address.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <returns></returns>
        public UserItemResponse FindByEmail(string email)
        {
            RestRequest request = CreateRequest("users/find-email", Method.Get);
            AddParameter(request, "email", email);

            return Execute<UserItemResponse>(request);
        }

        /// <summary>
        /// Finds users by username.
        /// </summary>
        /// <param name="username">Username to search for.</param>
        /// <returns></returns>
        public FindByNameResponse FindByName(string username)
        {
            RestRequest request = CreateRequest("users/find-name", Method.Get);
            AddParameter(request, "username", username);

            return Execute<FindByNameResponse>(request);
        }

        void AddWritableParameters(RestRequest request, Dictionary<string, object> options, Dictionary<string, object> profile, Dictionary<string, object> privacy, Dictionary<string, object> custom_fields, bool? visible, bool? activity_visible, string timezone, string custom_title, string username, string email, long? user_group_id, IEnumerable<long> secondary_group_ids, string user_state, bool? is_staff, long? message_count, long? reaction_score, long? trophy_points, bool? username_change_visible, string password, int? dob_day, int? dob_month, int? dob_year)
        {
            AddDictionaryParameters(request, "option", options);
            AddDictionaryParameters(request, "profile", profile);
            AddDictionaryParameters(request, "privacy", privacy);
            AddParameter(request, "visible", visible);
            AddParameter(request, "activity_visible", activity_visible);
            AddParameter(request, "timezone", timezone);
            AddParameter(request, "custom_title", custom_title);
            AddParameter(request, "username", username);
            AddParameter(request, "email", email);
            AddParameter(request, "user_group_id", user_group_id);
            AddParameter(request, "secondary_group_ids", secondary_group_ids);
            AddParameter(request, "user_state", user_state);
            AddParameter(request, "is_staff", is_staff);
            AddParameter(request, "message_count", message_count);
            AddParameter(request, "reaction_score", reaction_score);
            AddParameter(request, "trophy_points", trophy_points);
            AddParameter(request, "username_change_visible", username_change_visible);
            AddParameter(request, "password", password);
            AddParameter(request, "dob[day]", dob_day);
            AddParameter(request, "dob[month]", dob_month);
            AddParameter(request, "dob[year]", dob_year);
            AddDictionaryParameters(request, "custom_fields", custom_fields);
        }

        public class UsersResponse
        {
            [JsonProperty("users")]
            public List<XfModels.User> Users;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserResponse : SuccessResponse
        {
            [JsonProperty("user")]
            public XfModels.User User;
        }

        public class UserItemResponse
        {
            [JsonProperty("user")]
            public XfModels.User User;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserWithProfilePostsResponse
        {
            [JsonProperty("user")]
            public XfModels.User User;

            [JsonProperty("profile_posts")]
            public List<XfModels.ProfilePost> ProfilePosts;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ProfilePostsResponse
        {
            [JsonProperty("profile_posts")]
            public List<XfModels.ProfilePost> ProfilePosts;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class FindByNameResponse
        {
            [JsonProperty("exact")]
            public XfModels.User Exact;

            [JsonProperty("recommendations")]
            public List<XfModels.User> Recommendations;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}
