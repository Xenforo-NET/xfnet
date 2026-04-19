using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Alerts
    {
        public Task<UserAlertsResponse<T>> GetAllAsync<T>(long? page = null, long? cutoff = null, bool? unviewed = null, bool? unread = null, CancellationToken cancellationToken = default(CancellationToken)) where T : XfModels.UserAlert
        {
            RestRequest request = CreateRequest("alerts", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "cutoff", cutoff);
            AddParameter(request, "unviewed", unviewed);
            AddParameter(request, "unread", unread);

            return ExecuteAsync<UserAlertsResponse<T>>(request, cancellationToken);
        }

        public Task<UserAlertsResponse> GetAllAsync(long? page = null, long? cutoff = null, bool? unviewed = null, bool? unread = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("alerts", Method.Get);
            AddParameter(request, "page", page);
            AddParameter(request, "cutoff", cutoff);
            AddParameter(request, "unviewed", unviewed);
            AddParameter(request, "unread", unread);

            return ExecuteAsync<UserAlertsResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> SendToUserAsync(long to_user_id, string alert, long? from_user_id = null, string link_url = null, string link_title = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("alerts", Method.Post);
            AddParameter(request, "to_user_id", to_user_id);
            AddParameter(request, "alert", alert);
            AddParameter(request, "from_user_id", from_user_id);
            AddParameter(request, "link_url", link_url);
            AddParameter(request, "link_title", link_title);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> MarkAllAsync(bool? read = null, bool? viewed = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("alerts/mark-all", Method.Post);
            AddParameter(request, "read", read);
            AddParameter(request, "viewed", viewed);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<UserAlertResponse<T>> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default(CancellationToken)) where T : XfModels.UserAlert
        {
            RestRequest request = CreateRequest("alerts/" + id, Method.Get);
            return ExecuteAsync<UserAlertResponse<T>>(request, cancellationToken);
        }

        public Task<UserAlertResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("alerts/" + id, Method.Get);
            return ExecuteAsync<UserAlertResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> MarkByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("alerts/" + id + "/mark", Method.Post);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }
    }
}
