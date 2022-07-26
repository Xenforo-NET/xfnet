using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace xfnet.Routes
{
    public class Alerts
    {
        readonly string xfToken;
        readonly bool isVerbose;
        readonly string baseUrl;

        readonly RestClient _client;

        public Alerts(string xfToken, bool isVerbose, string baseUrl)
        {
            this.xfToken = xfToken;
            this.isVerbose = isVerbose;
            this.baseUrl = baseUrl;

            this._client = new RestClient(this.baseUrl);
        }

        /// <summary>
        /// Gets the API user's list of alerts
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.UserAlert</typeparam>
        /// <param name="page"></param>
        /// <param name="cutoff">Unix timestamp of oldest alert to include. Note that unread or unviewed alerts are always included.</param>
        /// <param name="unviewed">If true, gets only unviewed alerts. Unviewed alerts have not been seen (in the standard UI).</param>
        /// <param name="unread">If true, gets only unread alerts. Unread alerts may have been seen but the content they relate to has not been viewed.</param>
        /// <returns></returns>
        public UserAlertsResponse<T> Get<T>(long page = 0, long cutoff = 0, bool unviewed = false, bool unread = false) where T : XfModels.UserAlert
        {
            RestRequest request = new RestRequest("alerts", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);
            
            request.AddParameter("page", page);
            request.AddParameter("cutoff", cutoff);
            request.AddParameter("unviewed", unviewed);
            request.AddParameter("unread", unread);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertsResponseVerbose<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertsResponse<T>>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets the API user's list of alerts
        /// </summary>
        /// <param name = "page" ></ param >
        /// <param name="cutoff">Unix timestamp of oldest alert to include. Note that unread or unviewed alerts are always included.</param>
        /// <param name="unviewed">If true, gets only unviewed alerts. Unviewed alerts have not been seen (in the standard UI).</param>
        /// <param name="unread">If true, gets only unread alerts. Unread alerts may have been seen but the content they relate to has not been viewed.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public UserAlertsResponse Get(long page = 0, long cutoff = 0, bool unviewed = false, bool unread = false)
        {
            RestRequest request = new RestRequest("alerts", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("page", page);
            request.AddParameter("cutoff", cutoff);
            request.AddParameter("unviewed", unviewed);
            request.AddParameter("unread", unread);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertsResponseVerbose>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertsResponse>(encoding.GetString(response.RawBytes));
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
        public UserAlertsSuccessResponse SendToUser(long to_user_id, string alert, long from_user_id = 0, string link_url = "", string link_title = "")
        {
            RestRequest request = new RestRequest("alerts", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("to_user_id", to_user_id);
            request.AddParameter("alert", alert);
            request.AddParameter("from_user_id", from_user_id);
            request.AddParameter("link_url", link_url);
            request.AddParameter("link_title", link_title);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertsSuccessResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertsSuccessResponse>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Marks all of the API user's alerts as read or viewed. Must specify "read" or "viewed" parameters.
        /// </summary>
        /// <param name="read">If specified, marks all alerts as read.</param>
        /// <param name="viewed">If specified, marks all alerts as viewed. This will remove the alert counter but keep unactioned alerts highlighted.</param>
        /// <returns></returns>
        public UserAlertsSuccessResponse MarkAll(bool read = false, bool viewed = false)
        {
            RestRequest request = new RestRequest("alerts/mark-all", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("read", read);
            request.AddParameter("viewed", viewed);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertsSuccessResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertsSuccessResponse>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets information about the specified alert.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.UserAlert</typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserAlertResponse<T> GetById<T>(long id) where T : XfModels.UserAlert
        {
            RestRequest request = new RestRequest($"alerts/{id}", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertResponseVerbose<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertResponse<T>>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets information about the specified alert.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserAlertResponse GetById(long id)
        {
            RestRequest request = new RestRequest($"alerts/{id}", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertResponseVerbose>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertResponse>(encoding.GetString(response.RawBytes));
        }

        public UserAlertsSuccessResponse MarkById(long id)
        {
            RestRequest request = new RestRequest($"alerts/{id}/mark", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<UserAlertsSuccessResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<UserAlertsSuccessResponse>(encoding.GetString(response.RawBytes));
        }

        #region TemplateClasses
        public class UserAlertsResponse<T> where T : XfModels.UserAlert
        {
            [JsonProperty("alerts")]
            public List<T> Alerts;
        }

        public class UserAlertsResponseVerbose<T> : UserAlertsResponse<T> where T : XfModels.UserAlert
        {
            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserAlertResponse<T> where T : XfModels.UserAlert
        {
            [JsonProperty("alert")]
            public T Alert;
        }

        public class UserAlertResponseVerbose<T> : UserAlertResponse<T> where T : XfModels.UserAlert
        {
            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion

        #region Classes
        public class UserAlertsResponse
        {
            [JsonProperty("alerts")]
            public List<XfModels.UserAlert> Alerts;
        }

        public class UserAlertsResponseVerbose : UserAlertsResponse
        {
            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserAlertsSuccessResponse
        {
            [JsonProperty("success")]
            public bool Success;
        }

        public class UserAlertsSuccessResponseVerbose : UserAlertsSuccessResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class UserAlertResponse
        {
            [JsonProperty("alert")]
            public XfModels.UserAlert Alert;
        }

        public class UserAlertResponseVerbose : UserAlertResponse
        {
            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion
    }
}
