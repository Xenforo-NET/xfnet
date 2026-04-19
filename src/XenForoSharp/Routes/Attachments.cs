using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace XenForoSharp.Routes
{
    public partial class Attachments : RouteBase
    {
        public Attachments(string xfToken, bool isVerbose, string baseUrl) : base(xfToken, isVerbose, baseUrl) { }

        /// <summary>
        /// Gets the attachments associated with the provided API attachment key. Only returns attachments that have not been associated with content.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="attachment_key">The API attachment key.</param>
        /// <returns></returns>
        public AttachmentsResponse<T> GetAll<T>(string attachment_key) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments", Method.Get);
            AddParameter(request, "key", attachment_key);

            return Execute<AttachmentsResponse<T>>(request);
        }

        /// <summary>
        /// Gets the attachments associated with the provided API attachment key. Only returns attachments that have not been associated with content.
        /// </summary>
        /// <param name="attachment_key">The API attachment key.</param>
        /// <returns></returns>
        public AttachmentsResponse GetAll(string attachment_key)
        {
            RestRequest request = CreateRequest("attachments", Method.Get);
            AddParameter(request, "key", attachment_key);

            return Execute<AttachmentsResponse>(request);
        }

        /// <summary>
        /// Uploads an attachment. An API attachment key must be created first. Must be submitted using multipart/form-data encoding.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="attachment_key">The API attachment key to associated with.</param>
        /// <param name="file_bytes">The attachment file bytes.</param>
        /// <param name="file_name">The attachment file name.</param>
        /// <returns></returns>
        public AttachmentResponse<T> Upload<T>(string attachment_key, byte[] file_bytes, string file_name) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments", Method.Post);
            AddParameter(request, "key", attachment_key);
            AddFile(request, "attachment", file_bytes, file_name);

            return Execute<AttachmentResponse<T>>(request);
        }

        /// <summary>
        /// Uploads an attachment. An API attachment key must be created first. Must be submitted using multipart/form-data encoding.
        /// </summary>
        /// <param name="attachment_key">The API attachment key to associated with.</param>
        /// <param name="file_bytes">The attachment file bytes.</param>
        /// <param name="file_name">The attachment file name.</param>
        /// <returns></returns>
        public AttachmentResponse Upload(string attachment_key, byte[] file_bytes, string file_name)
        {
            RestRequest request = CreateRequest("attachments", Method.Post);
            AddParameter(request, "key", attachment_key);
            AddFile(request, "attachment", file_bytes, file_name);

            return Execute<AttachmentResponse>(request);
        }

        /// <summary>
        /// Creates a new attachment key, allowing attachments to be uploaded separately from the related content.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="type">The content type of the attachment. Default types include post, conversation_message. Add-ons may add more.</param>
        /// <param name="context">Key-value pairs representing the context of the attachment. This will vary depending on content type and the action being taken. See relevant actions for further details.</param>
        /// <param name="file_bytes">The attachment file bytes.</param>
        /// <param name="file_name">The attachment file name.</param>
        /// <returns></returns>
        public CreateNewAttachmentKeyResponse<T> CreateNewKey<T>(string type, Dictionary<string, string> context = null, byte[] file_bytes = null, string file_name = null) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments/new-key", Method.Post);
            AddParameter(request, "type", type);
            AddJsonParameter(request, "context", context);
            AddFile(request, "attachment", file_bytes, file_name);

            return Execute<CreateNewAttachmentKeyResponse<T>>(request);
        }

        /// <summary>
        /// Creates a new attachment key, allowing attachments to be uploaded separately from the related content.
        /// </summary>
        /// <param name="type">The content type of the attachment. Default types include post, conversation_message. Add-ons may add more.</param>
        /// <param name="context">Key-value pairs representing the context of the attachment. This will vary depending on content type and the action being taken. See relevant actions for further details.</param>
        /// <param name="file_bytes">The attachment file bytes.</param>
        /// <param name="file_name">The attachment file name.</param>
        /// <returns></returns>
        public CreateNewAttachmentKeyResponse CreateNewKey(string type, Dictionary<string, string> context = null, byte[] file_bytes = null, string file_name = null)
        {
            RestRequest request = CreateRequest("attachments/new-key", Method.Post);
            AddParameter(request, "type", type);
            AddJsonParameter(request, "context", context);
            AddFile(request, "attachment", file_bytes, file_name);

            return Execute<CreateNewAttachmentKeyResponse>(request);
        }

        /// <summary>
        /// Gets information about the specified attachment.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentResponse<T> GetById<T>(long id) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments/" + id, Method.Get);
            return Execute<AttachmentResponse<T>>(request);
        }

        /// <summary>
        /// Gets information about the specified attachment.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentResponse GetById(long id)
        {
            RestRequest request = CreateRequest("attachments/" + id, Method.Get);
            return Execute<AttachmentResponse>(request);
        }

        /// <summary>
        /// Delete's the specified attachment.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public SuccessResponse DeleteById(long id)
        {
            RestRequest request = CreateRequest("attachments/" + id, Method.Delete);
            return Execute<SuccessResponse>(request);
        }

        /// <summary>
        /// Gets the data that makes up the specified attachment. The output is the raw binary data.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentBinaryResponse GetBinaryById(long id)
        {
            RestRequest request = CreateRequest("attachments/" + id + "/data", Method.Get);
            RestResponse response = Execute(request);

            if (!string.IsNullOrWhiteSpace(response.Content))
                return Deserialize<AttachmentBinaryResponse>(response);

            return new AttachmentBinaryResponse
            {
                Data = response.RawBytes
            };
        }

        /// <summary>
        /// Gets the URL to the attachment's retina thumbnail, if it has one. URL returned via a 301 redirect.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public UrlResponse GetRetinaUrlById(long id)
        {
            RestRequest request = CreateRequest("attachments/" + id + "/retina-thumbnail", Method.Get);
            return ExecuteUrl(request);
        }

        /// <summary>
        /// Gets the URL to the attachment's thumbnail, if it has one. URL returned via a 301 redirect.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public UrlResponse GetUrlById(long id)
        {
            RestRequest request = CreateRequest("attachments/" + id + "/thumbnail", Method.Get);
            return ExecuteUrl(request);
        }

        #region TemplateClasses
        public class AttachmentsResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("attachments")]
            public List<T> Attachments;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("attachment")]
            public T Attachment;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class CreateNewAttachmentKeyResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("attachment")]
            public T Attachment;

            [JsonProperty("key")]
            public string Key;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion

        #region Classes
        public class AttachmentsResponse
        {
            [JsonProperty("attachments")]
            public List<XfModels.Attachment> Attachments;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentResponse
        {
            [JsonProperty("attachment")]
            public XfModels.Attachment Attachment;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class CreateNewAttachmentKeyResponse
        {
            [JsonProperty("attachment")]
            public XfModels.Attachment Attachment;

            [JsonProperty("key")]
            public string Key;

            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentBinaryResponse : SuccessResponse
        {
            [JsonIgnore]
            public byte[] Data;
        }
        #endregion
    }
}

