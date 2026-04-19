using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XenForoSharp.Routes
{
    public partial class Attachments
    {
        public Task<AttachmentsResponse<T>> GetAllAsync<T>(string attachment_key, CancellationToken cancellationToken = default(CancellationToken)) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments", Method.Get);
            AddParameter(request, "key", attachment_key);

            return ExecuteAsync<AttachmentsResponse<T>>(request, cancellationToken);
        }

        public Task<AttachmentsResponse> GetAllAsync(string attachment_key, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments", Method.Get);
            AddParameter(request, "key", attachment_key);

            return ExecuteAsync<AttachmentsResponse>(request, cancellationToken);
        }

        public Task<AttachmentResponse<T>> UploadAsync<T>(string attachment_key, byte[] file_bytes, string file_name, CancellationToken cancellationToken = default(CancellationToken)) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments", Method.Post);
            AddParameter(request, "key", attachment_key);
            AddFile(request, "attachment", file_bytes, file_name);

            return ExecuteAsync<AttachmentResponse<T>>(request, cancellationToken);
        }

        public Task<AttachmentResponse> UploadAsync(string attachment_key, byte[] file_bytes, string file_name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments", Method.Post);
            AddParameter(request, "key", attachment_key);
            AddFile(request, "attachment", file_bytes, file_name);

            return ExecuteAsync<AttachmentResponse>(request, cancellationToken);
        }

        public Task<CreateNewAttachmentKeyResponse<T>> CreateNewKeyAsync<T>(string type, Dictionary<string, string> context = null, byte[] file_bytes = null, string file_name = null, CancellationToken cancellationToken = default(CancellationToken)) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments/new-key", Method.Post);
            AddParameter(request, "type", type);
            AddJsonParameter(request, "context", context);
            AddFile(request, "attachment", file_bytes, file_name);

            return ExecuteAsync<CreateNewAttachmentKeyResponse<T>>(request, cancellationToken);
        }

        public Task<CreateNewAttachmentKeyResponse> CreateNewKeyAsync(string type, Dictionary<string, string> context = null, byte[] file_bytes = null, string file_name = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments/new-key", Method.Post);
            AddParameter(request, "type", type);
            AddJsonParameter(request, "context", context);
            AddFile(request, "attachment", file_bytes, file_name);

            return ExecuteAsync<CreateNewAttachmentKeyResponse>(request, cancellationToken);
        }

        public Task<AttachmentResponse<T>> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default(CancellationToken)) where T : XfModels.Attachment
        {
            RestRequest request = CreateRequest("attachments/" + id, Method.Get);
            return ExecuteAsync<AttachmentResponse<T>>(request, cancellationToken);
        }

        public Task<AttachmentResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments/" + id, Method.Get);
            return ExecuteAsync<AttachmentResponse>(request, cancellationToken);
        }

        public Task<SuccessResponse> DeleteByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments/" + id, Method.Delete);
            return ExecuteAsync<SuccessResponse>(request, cancellationToken);
        }

        public async Task<AttachmentBinaryResponse> GetBinaryByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments/" + id + "/data", Method.Get);
            RestResponse response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrWhiteSpace(response.Content))
                return Deserialize<AttachmentBinaryResponse>(response);

            return new AttachmentBinaryResponse
            {
                Data = response.RawBytes
            };
        }

        public Task<UrlResponse> GetRetinaUrlByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments/" + id + "/retina-thumbnail", Method.Get);
            return ExecuteUrlAsync(request, cancellationToken);
        }

        public Task<UrlResponse> GetUrlByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            RestRequest request = CreateRequest("attachments/" + id + "/thumbnail", Method.Get);
            return ExecuteUrlAsync(request, cancellationToken);
        }
    }
}
