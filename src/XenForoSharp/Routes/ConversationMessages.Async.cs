using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class ConversationMessages
    {
        public Task<ConversationMessageResponse> CreateAsync(long conversation_id, string message, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversation-messages", Method.Post);
            AddParameter(request, "conversation_id", conversation_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ConversationMessageResponse>(request, cancellationToken);
        }

        public Task<ConversationMessageItemResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversation-messages/" + id, Method.Get);
            return ExecuteAsync<ConversationMessageItemResponse>(request, cancellationToken);
        }

        public Task<ConversationMessageResponse> UpdateByIdAsync(long id, string message = null, string attachment_key = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversation-messages/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return ExecuteAsync<ConversationMessageResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversation-messages/" + id, Method.Delete);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public Task<ActionResponse> ReactByIdAsync(long id, long? reaction_id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("conversation-messages/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return ExecuteAsync<ActionResponse>(request, cancellationToken);
        }
    }
}
