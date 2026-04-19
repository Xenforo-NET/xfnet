using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public class ConversationMessages : RouteBase
    {
        public ConversationMessages(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Reply to a conversation.
        /// </summary>
        /// <param name="conversation_id">The conversation to reply to.</param>
        /// <param name="message">The reply text.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ConversationMessageResponse Create(long conversation_id, string message, string attachment_key = null)
        {
            RestRequest request = CreateRequest("conversation-messages", Method.Post);
            AddParameter(request, "conversation_id", conversation_id);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<ConversationMessageResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified conversation message.
        /// </summary>
        /// <param name="id">Conversation message id.</param>
        /// <returns></returns>
        public ConversationMessageItemResponse GetById(long id)
        {
            RestRequest request = CreateRequest("conversation-messages/" + id, Method.Get);
            return Execute<ConversationMessageItemResponse>(request);
        }

        /// <summary>
        /// Updates the specified conversation message.
        /// </summary>
        /// <param name="id">Conversation message id.</param>
        /// <param name="message">The new message text.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <returns></returns>
        public ConversationMessageResponse UpdateById(long id, string message = null, string attachment_key = null)
        {
            RestRequest request = CreateRequest("conversation-messages/" + id, Method.Post);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);

            return Execute<ConversationMessageResponse>(request);
        }

        /// <summary>
        /// Deletes the specified conversation message.
        /// </summary>
        /// <param name="id">Conversation message id.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id)
        {
            RestRequest request = CreateRequest("conversation-messages/" + id, Method.Delete);
            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Reacts to the specified conversation message.
        /// </summary>
        /// <param name="id">Conversation message id.</param>
        /// <param name="reaction_id">Reaction id to apply. Use 0 or null to remove reaction.</param>
        /// <returns></returns>
        public ActionResponse ReactById(long id, long? reaction_id = null)
        {
            RestRequest request = CreateRequest("conversation-messages/" + id + "/react", Method.Post);
            AddParameter(request, "reaction_id", reaction_id);

            return Execute<ActionResponse>(request);
        }

        public class ConversationMessageResponse : SuccessResponse
        {
            [JsonProperty("message")]
            public XfModels.ConversationMessage Message;
        }

        public class ConversationMessageItemResponse
        {
            [JsonProperty("message")]
            public XfModels.ConversationMessage Message;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

