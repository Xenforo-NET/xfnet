using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class Me : RouteBase
    {
        public Me(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get information about the current user.
        /// </summary>
        /// <returns></returns>
        public MeResponse Get()
        {
            RestRequest request = CreateRequest("me", Method.Get);
            return Execute<MeResponse>(request);
        }

        /// <summary>
        /// Update information about the current user.
        /// </summary>
        /// <param name="options">Map of option values.</param>
        /// <param name="profile">Map of profile values.</param>
        /// <param name="privacy">Map of privacy values.</param>
        /// <param name="visible"></param>
        /// <param name="activity_visible"></param>
        /// <param name="timezone"></param>
        /// <param name="custom_title"></param>
        /// <param name="custom_fields">Map of custom field values.</param>
        /// <returns></returns>
        public SuccessResponse Update(Dictionary<string, object> options = null, Dictionary<string, object> profile = null, Dictionary<string, object> privacy = null, bool? visible = null, bool? activity_visible = null, string timezone = null, string custom_title = null, Dictionary<string, object> custom_fields = null)
        {
            RestRequest request = CreateRequest("me", Method.Post);
            AddDictionaryParameters(request, "option", options);
            AddDictionaryParameters(request, "profile", profile);
            AddDictionaryParameters(request, "privacy", privacy);
            AddParameter(request, "visible", visible);
            AddParameter(request, "activity_visible", activity_visible);
            AddParameter(request, "timezone", timezone);
            AddParameter(request, "custom_title", custom_title);
            AddDictionaryParameters(request, "custom_fields", custom_fields);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Upload a new avatar for the current user.
        /// </summary>
        /// <param name="avatar_bytes">Avatar bytes.</param>
        /// <param name="file_name">Avatar file name.</param>
        /// <returns></returns>
        public SuccessResponse UploadAvatar(byte[] avatar_bytes, string file_name)
        {
            RestRequest request = CreateRequest("me/avatar", Method.Post);
            AddFile(request, "avatar", avatar_bytes, file_name);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Deletes the current user's avatar.
        /// </summary>
        /// <returns></returns>
        public SuccessResponse DeleteAvatar()
        {
            RestRequest request = CreateRequest("me/avatar", Method.Delete);
            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Changes the current user's email address.
        /// </summary>
        /// <param name="current_password">Current password.</param>
        /// <param name="email">New email address.</param>
        /// <returns></returns>
        public ChangeEmailResponse UpdateEmail(string current_password, string email)
        {
            RestRequest request = CreateRequest("me/email", Method.Post);
            AddParameter(request, "current_password", current_password);
            AddParameter(request, "email", email);

            return Execute<ChangeEmailResponse>(request);
        }

        /// <summary>
        /// Changes the current user's password.
        /// </summary>
        /// <param name="current_password">Current password.</param>
        /// <param name="new_password">New password.</param>
        /// <returns></returns>
        public SuccessResponse UpdatePassword(string current_password, string new_password)
        {
            RestRequest request = CreateRequest("me/password", Method.Post);
            AddParameter(request, "current_password", current_password);
            AddParameter(request, "new_password", new_password);

            return Execute<SuccessResponse>(request);
        }

        public class MeResponse
        {
            [JsonProperty("me")]
            public XfModels.User Me;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ChangeEmailResponse : SuccessResponse
        {
            [JsonProperty("confirmation_required")]
            public bool? ConfirmationRequired;
        }
    }
}
