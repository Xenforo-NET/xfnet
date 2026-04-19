using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public partial class Conversations : RouteBase
    {
        public Conversations(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Get a list of user conversations.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ConversationsResponse GetAll(long? page = null)
        {
            RestRequest request = CreateRequest("conversations", Method.Get);
            AddParameter(request, "page", page);

            return Execute<ConversationsResponse>(request);
        }

        /// <summary>
        /// Create a conversation.
        /// </summary>
        /// <param name="recipient_ids">List of user IDs to send the conversation to.</param>
        /// <param name="title">Conversation title.</param>
        /// <param name="message">Conversation message.</param>
        /// <param name="attachment_key">Attachment key containing uploaded attachments.</param>
        /// <param name="conversation_open">True to keep the conversation open.</param>
        /// <param name="open_invite">True to allow new recipients to be invited by participants.</param>
        /// <returns></returns>
        public ConversationResponse Create(IEnumerable<long> recipient_ids, string title, string message, string attachment_key = null, bool? conversation_open = null, bool? open_invite = null)
        {
            RestRequest request = CreateRequest("conversations", Method.Post);
            AddParameter(request, "recipient_ids", recipient_ids);
            AddParameter(request, "title", title);
            AddParameter(request, "message", message);
            AddParameter(request, "attachment_key", attachment_key);
            AddParameter(request, "conversation_open", conversation_open);
            AddParameter(request, "open_invite", open_invite);

            return Execute<ConversationResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="with_messages">If true, includes messages.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ConversationWithMessagesResponse GetById(long id, bool? with_messages = null, long? page = null)
        {
            RestRequest request = CreateRequest("conversations/" + id, Method.Get);
            AddParameter(request, "with_messages", with_messages);
            AddParameter(request, "page", page);

            return Execute<ConversationWithMessagesResponse>(request);
        }

        /// <summary>
        /// Updates the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="title">Conversation title.</param>
        /// <param name="open_invite">True to allow new recipients to be invited by participants.</param>
        /// <param name="conversation_open">True to keep the conversation open.</param>
        /// <returns></returns>
        public ConversationResponse UpdateById(long id, string title = null, bool? open_invite = null, bool? conversation_open = null)
        {
            RestRequest request = CreateRequest("conversations/" + id, Method.Post);
            AddParameter(request, "title", title);
            AddParameter(request, "open_invite", open_invite);
            AddParameter(request, "conversation_open", conversation_open);

            return Execute<ConversationResponse>(request);
        }

        /// <summary>
        /// Deletes the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="ignore">If true, ignores the conversation instead of leaving it.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id, bool? ignore = null)
        {
            RestRequest request = CreateRequest("conversations/" + id, Method.Delete);
            AddParameter(request, "ignore", ignore);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Invites users to the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="recipient_ids">List of user IDs to invite.</param>
        /// <returns></returns>
        public SuccessResponse InviteById(long id, IEnumerable<long> recipient_ids)
        {
            RestRequest request = CreateRequest("conversations/" + id + "/invite", Method.Post);
            AddParameter(request, "recipient_ids", recipient_ids);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Sets labels for the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="labels">List of labels to assign.</param>
        /// <returns></returns>
        public SuccessResponse SetLabelsById(long id, IEnumerable<string> labels)
        {
            RestRequest request = CreateRequest("conversations/" + id + "/labels", Method.Post);
            AddParameter(request, "labels", labels);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Marks the conversation as read up to the specified date.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="date">Unix timestamp to mark as read through.</param>
        /// <returns></returns>
        public SuccessResponse MarkReadById(long id, long? date = null)
        {
            RestRequest request = CreateRequest("conversations/" + id + "/mark-read", Method.Post);
            AddParameter(request, "date", date);

            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Marks the conversation as unread.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <returns></returns>
        public SuccessResponse MarkUnreadById(long id)
        {
            RestRequest request = CreateRequest("conversations/" + id + "/mark-unread", Method.Post);
            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Gets the messages for the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ConversationMessagesResponse GetMessagesById(long id, long? page = null)
        {
            RestRequest request = CreateRequest("conversations/" + id + "/messages", Method.Get);
            AddParameter(request, "page", page);

            return Execute<ConversationMessagesResponse>(request);
        }

        /// <summary>
        /// Stars or unstars the specified conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="star">True to star the conversation.</param>
        /// <returns></returns>
        public SuccessResponse StarById(long id, bool star)
        {
            RestRequest request = CreateRequest("conversations/" + id + "/star", Method.Post);
            AddParameter(request, "star", star);

            return Execute<SuccessResponse>(request);
        }

        public class ConversationsResponse
        {
            [JsonProperty("conversations")]
            public List<XfModels.Conversation> Conversations;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ConversationResponse : SuccessResponse
        {
            [JsonProperty("conversation")]
            public XfModels.Conversation Conversation;
        }

        public class ConversationWithMessagesResponse
        {
            [JsonProperty("conversation")]
            public XfModels.Conversation Conversation;

            [JsonProperty("messages")]
            public List<XfModels.ConversationMessage> Messages;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class ConversationMessagesResponse
        {
            [JsonProperty("messages")]
            public List<XfModels.ConversationMessage> Messages;

            [JsonProperty("pagination")]
            public XfModels.Pagination Pagination;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
    }
}

