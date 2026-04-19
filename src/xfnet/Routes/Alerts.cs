using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace xfnet.Routes
{
    public class Alerts : RouteBase
    {
        public Alerts(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Gets the API user's list of alerts.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.UserAlert.</typeparam>
        /// <param name="page"></param>
        /// <param name="cutoff">Unix timestamp of oldest alert to include. Note that unread or unviewed alerts are always included.</param>
        /// <param name="unviewed">If true, gets only unviewed alerts. Unviewed alerts have not been seen (in the standard UI).</param>
        /// <param name="unread">If true, gets only unread alerts. Unread alerts may have been seen but the content they relate to has not been viewed.</param>
        /// <returns></returns>
        public UserAlertsResponse<T> GetAll<T>(long? page = null, long? cutoff = null, bool? unviewed = null, bool? unread = null) where T : XfModels.UserAlert
        {
            RestRequest request = CreateRequest("alerts", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "cutoff", cutoff);
            AddParameter(request, "unviewed", unviewed);
            AddParameter(request, "unread", unread);

            return Execute<UserAlertsResponse<T>>(request);
        }

        /// <summary>
        /// Gets the API user's list of alerts.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="cutoff">Unix timestamp of oldest alert to include. Note that unread or unviewed alerts are always included.</param>
        /// <param name="unviewed">If true, gets only unviewed alerts. Unviewed alerts have not been seen (in the standard UI).</param>
        /// <param name="unread">If true, gets only unread alerts. Unread alerts may have been seen but the content they relate to has not been viewed.</param>
        /// <returns></returns>
        public UserAlertsResponse GetAll(long? page = null, long? cutoff = null, bool? unviewed = null, bool? unread = null)
        {
            RestRequest request = CreateRequest("alerts", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "cutoff", cutoff);
            AddParameter(request, "unviewed", unviewed);
            AddParameter(request, "unread", unread);

            return Execute<UserAlertsResponse>(request);
        }

        /// <summary>
        /// Sends an alert to the specified user. Only available to super user keys.
        /// </summary>
        /// <param name="to_user_id">ID of the user to receive the alert.</param>
        /// <param name="alert">Text of the alert. May use the placeholder "{link}" to have the link automatically inserted.</param>
        /// <param name="from_user_id">If provided, the user to send the alert from. Otherwise, uses the current API user. May be 0 for an anonymous alert.</param>
        /// <param name="link_url">URL user will be taken to when the alert is clicked.</param>
        /// <param name="link_title">Text of the link URL that will be displayed. If no placeholder is present in the alert, will be automatically appended.</param>
        /// <returns></returns>
        public SuccessResponse SendToUser(long to_user_id, string alert, long? from_user_id = null, string link_url = null, string link_title = null)
        {
            RestRequest request = CreateRequest("alerts", Method.Post);
            AddParameter(request, "to_user_id", to_user_id);
            AddParameter(request, "alert", alert);
            AddParameter(request, "from_user_id", from_user_id);
            AddParameter(request, "link_url", link_url);
            AddParameter(request, "link_title", link_title);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Marks all of the API user's alerts as read or viewed. Must specify "read" or "viewed" parameters.
        /// </summary>
        /// <param name="read">If specified, marks all alerts as read.</param>
        /// <param name="viewed">If specified, marks all alerts as viewed. This will remove the alert counter but keep unactioned alerts highlighted.</param>
        /// <returns></returns>
        public SuccessResponse MarkAll(bool? read = null, bool? viewed = null)
        {
            RestRequest request = CreateRequest("alerts/mark-all", Method.Post);
            AddParameter(request, "read", read);
            AddParameter(request, "viewed", viewed);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified alert.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.UserAlert.</typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserAlertResponse<T> GetById<T>(long id) where T : XfModels.UserAlert
        {
            RestRequest request = CreateRequest("alerts/" + id, Method.Get);
            return Execute<UserAlertResponse<T>>(request);
        }

        /// <summary>
        /// Gets information about the specified alert.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserAlertResponse GetById(long id)
        {
            RestRequest request = CreateRequest("alerts/" + id, Method.Get);
            return Execute<UserAlertResponse>(request);
        }

        /// <summary>
        /// Marks the specified alert as read and viewed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SuccessResponse MarkById(long id)
        {
            RestRequest request = CreateRequest("alerts/" + id + "/mark", Method.Post);
            return Execute<SuccessResponse>(request);
        }

        #region TemplateClasses
        public class UserAlertsResponse<T> where T : XfModels.UserAlert
        {
            [JsonProperty("alerts")]
            public List<T> Alerts;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserAlertResponse<T> where T : XfModels.UserAlert
        {
            [JsonProperty("alert")]
            public T Alert;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion

        #region Classes
        public class UserAlertsResponse
        {
            [JsonProperty("alerts")]
            public List<XfModels.UserAlert> Alerts;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserAlertResponse
        {
            [JsonProperty("alert")]
            public XfModels.UserAlert Alert;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion
    }
}
