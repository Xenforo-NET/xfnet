using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;

namespace xfnet.Routes
{
    public class Attachments
    {
        readonly string xfToken;
        readonly bool isVerbose;
        readonly string baseUrl;

        readonly RestClient _client;

        public Attachments(string xfToken, bool isVerbose, string baseUrl)
        {
            this.xfToken = xfToken;
            this.isVerbose = isVerbose;
            this.baseUrl = baseUrl;

            this._client = new RestClient(this.baseUrl);
        }

        /// <summary>
        /// Gets the attachments associated with the provided API attachment key. Only returns attachments that have not been associated with content.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="attachment_key">The API attachment key.</param>
        /// <returns></returns>
        public AttachmentsResponse<T> GetAll<T>(string attachment_key) where T : XfModels.Attachment
        {
            RestRequest request = new RestRequest("attachments", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("key", attachment_key);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentsResponseVerbose<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentsResponse<T>>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets the attachments associated with the provided API attachment key. Only returns attachments that have not been associated with content.
        /// </summary>
        /// <param name="attachment_key">The API attachment key.</param>
        /// <returns></returns>
        public AttachmentsResponse GetAll(string attachment_key)
        {
            RestRequest request = new RestRequest("attachments", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("key", attachment_key);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentsResponseVerbose>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentsResponse>(encoding.GetString(response.RawBytes));
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
            RestRequest request = new RestRequest("attachments", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("key", attachment_key);
            request.AddFile("attachment", file_bytes, file_name);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentResponse<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentResponseVerbose<T>>(encoding.GetString(response.RawBytes));
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
            RestRequest request = new RestRequest("attachments", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("key", attachment_key);
            request.AddFile("attachment", file_bytes, file_name);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentResponseVerbose>(encoding.GetString(response.RawBytes));
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
        public CreateNewAttachmentKeyResponse<T> CreateNewKey<T>(string type, Dictionary<string, string> context, byte[] file_bytes, string file_name) where T : XfModels.Attachment
        {
            RestRequest request = new RestRequest("attachments/new-key", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("type", type);
            request.AddParameter("context", JsonConvert.SerializeObject(context));
            request.AddFile("attachment", file_bytes, file_name);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponse<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponseVerbose<T>>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Creates a new attachment key, allowing attachments to be uploaded separately from the related content.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="type">The content type of the attachment. Default types include post, conversation_message. Add-ons may add more.</param>
        /// <param name="context">Key-value pairs representing the context of the attachment. This will vary depending on content type and the action being taken. See relevant actions for further details.</param>
        /// <returns></returns>
        public CreateNewAttachmentKeyResponse<T> CreateNewKey<T>(string type, Dictionary<string, string> context) where T : XfModels.Attachment
        {
            RestRequest request = new RestRequest("attachments/new-key", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("type", type);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponse<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponseVerbose<T>>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Creates a new attachment key, allowing attachments to be uploaded separately from the related content.
        /// </summary>
        /// <param name="type">The content type of the attachment. Default types include post, conversation_message. Add-ons may add more.</param>
        /// <param name="context">Key-value pairs representing the context of the attachment. This will vary depending on content type and the action being taken. See relevant actions for further details.</param>
        /// <param name="file_bytes">The attachment file bytes.</param>
        /// <param name="file_name">The attachment file name.</param>
        /// <returns></returns>
        public CreateNewAttachmentKeyResponse CreateNewKey(string type, Dictionary<string, string> context, byte[] file_bytes, string file_name)
        {
            RestRequest request = new RestRequest("attachments/new-key", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("type", type);
            request.AddParameter("context", JsonConvert.SerializeObject(context));
            request.AddFile("attachment", file_bytes, file_name);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponseVerbose>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Creates a new attachment key, allowing attachments to be uploaded separately from the related content.
        /// </summary>
        /// <param name="type">The content type of the attachment. Default types include post, conversation_message. Add-ons may add more.</param>
        /// <param name="context">Key-value pairs representing the context of the attachment. This will vary depending on content type and the action being taken. See relevant actions for further details.</param>
        /// <returns></returns>
        public CreateNewAttachmentKeyResponse CreateNewKey(string type, Dictionary<string, string> context)
        {
            RestRequest request = new RestRequest("attachments/new-key", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            request.AddParameter("type", type);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<CreateNewAttachmentKeyResponseVerbose>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets information about the specified attachment.
        /// </summary>
        /// <typeparam name="T">A class that inherits XfModels.Attachment.</typeparam>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentResponse<T> GetById<T>(int id) where T : XfModels.Attachment
        {
            RestRequest request = new RestRequest($"attachments/{id}", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentResponse<T>>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentResponseVerbose<T>>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets information about the specified attachment.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentResponse GetById(int id)
        {
            RestRequest request = new RestRequest($"attachments/{id}", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentResponseVerbose>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Delete's the specified attachment.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentSuccessResponse DeleteById(int id)
        {
            RestRequest request = new RestRequest($"attachments/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentSuccessResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentSuccessResponseVerbose>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets the data that makes up the specified attachment. The output is the raw binary data.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentBinaryResponse GetBinaryById(int id)
        {
            RestRequest request = new RestRequest($"attachments/{id}/data", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentBinaryResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentBinaryResponseVerbose>(encoding.GetString(response.RawBytes));
        }

        /// <summary>
        /// Gets the URL to the attachment's thumbnail, if it has one. URL returned via a 301 redirect.
        /// </summary>
        /// <param name="id">Attachment id.</param>
        /// <returns></returns>
        public AttachmentUrlResponse GetUrlById(int id)
        {
            RestRequest request = new RestRequest($"attachments/{id}/thumbnail", Method.Get);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("XF-Api-Key", xfToken);

            RestResponse response = _client.Execute(request);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            if (isVerbose) return JsonConvert.DeserializeObject<AttachmentUrlResponse>(encoding.GetString(response.RawBytes));
            return JsonConvert.DeserializeObject<AttachmentUrlResponseVerbose>(encoding.GetString(response.RawBytes));
        }

        #region TemplateClasses
        public class AttachmentsResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("attachments")]
            public List<T> Attachments;
        }

        public class AttachmentsResponseVerbose<T> : AttachmentsResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("attachment")]
            public T Attachment;
        }

        public class AttachmentResponseVerbose<T> : AttachmentResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class CreateNewAttachmentKeyResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("attachment")]
            public T Attachment;

            [JsonProperty("key")]
            public string Key;
        }

        public class CreateNewAttachmentKeyResponseVerbose<T> : CreateNewAttachmentKeyResponse<T> where T : XfModels.Attachment
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion

        #region Classes
        public class AttachmentsResponse
        {
            [JsonProperty("attachments")]
            public List<XfModels.Attachment> Attachments;
        }

        public class AttachmentsResponseVerbose : AttachmentsResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentResponse
        {
            [JsonProperty("attachment")]
            public XfModels.Attachment Attachment;
        }

        public class AttachmentResponseVerbose : AttachmentResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class CreateNewAttachmentKeyResponse
        {
            [JsonProperty("attachment")]
            public XfModels.Attachment Attachment;

            [JsonProperty("key")]
            public string Key;
        }

        public class CreateNewAttachmentKeyResponseVerbose : CreateNewAttachmentKeyResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentSuccessResponse
        {
            [JsonProperty("success")]
            public bool Success;
        }

        public class AttachmentSuccessResponseVerbose : AttachmentSuccessResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentBinaryResponse
        {
            [JsonProperty("data")]
            public byte[] Data;
        }

        public class AttachmentBinaryResponseVerbose : AttachmentBinaryResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }

        public class AttachmentUrlResponse
        {
            [JsonProperty("url")]
            public string Url;
        }

        public class AttachmentUrlResponseVerbose : AttachmentUrlResponse
        {
            [JsonProperty("errors")]
            public List<XfModels.Error> Errors;
        }
        #endregion
    }
}
