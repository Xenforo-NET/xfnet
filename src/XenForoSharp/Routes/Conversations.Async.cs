using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Conversations
    {
        public Task<ConversationsResponse> GetAllAsync(long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations", Method.Get);
            AddParameter(request, "page", page);

            return ExecuteAsync<ConversationsResponse>(request, cancellationToken);
        }

        public Task<ConversationResponse> CreateAsync(IEnumerable<long> recipient_ids, string title, string message, string attachment_key = null, bool? conversation_open = null, bool? open_invite = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations", Method.Post);
            AddParameter(request, "recipient_ids", recipient_ids);
            AddParameter(request, "title", title);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);
            AddParameter(request, "conversation_open", conversation_open);
            AddParameter(request, "open_invite", open_invite);

            return ExecuteAsync<ConversationResponse>(request, cancellationToken);
        }

        public Task<ConversationWithMessagesResponse> GetByIdAsync(long id, bool? with_messages = null, long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id, Method.Get);
            AddParameter(request, "with_messages", with_messages);
            AddParameter(request, "page", page);

            return ExecuteAsync<ConversationWithMessagesResponse>(request, cancellationToken);
        }

        public Task<ConversationResponse> UpdateByIdAsync(long id, string title = null, bool? open_invite = null, bool? conversation_open = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id, Method.Post);
            AddParameter(request, "title", title);
            AddParameter(request, "open_invite", open_invite);
            AddParameter(request, "conversation_open", conversation_open);

            return ExecuteAsync<ConversationResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, bool? ignore = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id, Method.Delete);
            AddParameter(request, "ignore", ignore);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> InviteByIdAsync(long id, IEnumerable<long> recipient_ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id + "/invite", Method.Post);
            AddParameter(request, "recipient_ids", recipient_ids);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> SetLabelsByIdAsync(long id, IEnumerable<string> labels, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id + "/labels", Method.Post);
            AddParameter(request, "labels", labels);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> MarkReadByIdAsync(long id, long? date = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id + "/mark-read", Method.Post);
            AddParameter(request, "date", date);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> MarkUnreadByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id + "/mark-unread", Method.Post);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ConversationMessagesResponse> GetMessagesByIdAsync(long id, long? page = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id + "/messages", Method.Get);
            AddParameter(request, "page", page);

            return ExecuteAsync<ConversationMessagesResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> StarByIdAsync(long id, bool star, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversations/" + id + "/star", Method.Post);
            AddParameter(request, "star", star);

            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }
    }
}
