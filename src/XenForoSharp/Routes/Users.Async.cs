using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Users
    {
        public Task<UsersResponse> GetAllAsync(long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users", Method.Get);
            AddParameter(request, "page", page);

            return ExecuteAsync<UsersResponse>(request, cancellationToken);
        }

        public Task<UserResponse> CreateAsync(Dictionary<string, object> options = null, Dictionary<string, object> profile = null, Dictionary<string, object> privacy = null, Dictionary<string, object> custom_fields = null, bool? visible = null, bool? activity_visible = null, string timezone = null, string custom_title = null, string username = null, string email = null, long? user_group_id = null, IEnumerable<long> secondary_group_ids = null, string user_state = null, bool? is_staff = null, long? message_count = null, long? reaction_score = null, long? trophy_points = null, bool? username_change_visible = null, string password = null, int? dob_day = null, int? dob_month = null, int? dob_year = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users", Method.Post);
            AddWritableParameters(request, options, profile, privacy, custom_fields, visible, activity_visible, timezone, custom_title, username, email, user_group_id, secondary_group_ids, user_state, is_staff, message_count, reaction_score, trophy_points, username_change_visible, password, dob_day, dob_month, dob_year);

            return ExecuteAsync<UserResponse>(request, cancellationToken);
        }

        public Task<UserWithProfilePostsResponse> GetByIdAsync(long id, bool? with_posts = null, long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/" + id, Method.Get);
            AddParameter(request, "with_posts", with_posts);
            AddParameter(request, "page", page);

            return ExecuteAsync<UserWithProfilePostsResponse>(request, cancellationToken);
        }

        public Task<UserResponse> UpdateByIdAsync(long id, Dictionary<string, object> options = null, Dictionary<string, object> profile = null, Dictionary<string, object> privacy = null, Dictionary<string, object> custom_fields = null, bool? visible = null, bool? activity_visible = null, string timezone = null, string custom_title = null, string username = null, string email = null, long? user_group_id = null, IEnumerable<long> secondary_group_ids = null, string user_state = null, bool? is_staff = null, long? message_count = null, long? reaction_score = null, long? trophy_points = null, bool? username_change_visible = null, string password = null, int? dob_day = null, int? dob_month = null, int? dob_year = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/" + id, Method.Post);
            AddWritableParameters(request, options, profile, privacy, custom_fields, visible, activity_visible, timezone, custom_title, username, email, user_group_id, secondary_group_ids, user_state, is_staff, message_count, reaction_score, trophy_points, username_change_visible, password, dob_day, dob_month, dob_year);

            return ExecuteAsync<UserResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, string rename_to = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/" + id, Method.Delete);
            AddParameter(request, "rename_to", rename_to);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> UploadAvatarByIdAsync(long id, byte[] avatar_bytes, string file_name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/" + id + "/avatar", Method.Post);
            AddFile(request, "avatar", avatar_bytes, file_name);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteAvatarByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/" + id + "/avatar", Method.Delete);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ProfilePostsResponse> GetProfilePostsByIdAsync(long id, long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/" + id + "/profile-posts", Method.Get);
            AddParameter(request, "page", page);

            return ExecuteAsync<ProfilePostsResponse>(request, cancellationToken);
        }

        public Task<UserItemResponse> FindByEmailAsync(string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/find-email", Method.Get);
            AddParameter(request, "email", email);

            return ExecuteAsync<UserItemResponse>(request, cancellationToken);
        }

        public Task<FindByNameResponse> FindByNameAsync(string username, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("users/find-name", Method.Get);
            AddParameter(request, "username", username);

            return ExecuteAsync<FindByNameResponse>(request, cancellationToken);
        }
    }
}
