using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XenForoSharp.Routes
{
    public abstract class RouteBase
    {
        protected readonly string xfToken;
        protected readonly bool isVerbose;
        protected readonly string baseUrl;

        protected readonly RestClient _client;

        protected RouteBase(string xfToken, bool isVerbose, string baseUrl)
        {
            this.xfToken = xfToken;
            this.isVerbose = isVerbose;
            this.baseUrl = baseUrl;

            RestClientOptions options = new RestClientOptions(this.baseUrl);
            options.FollowRedirects = false;

            this._client = new RestClient(options);
        }

        protected RestRequest CreateRequest(string resource, Method method)
        {
            RestRequest request = new RestRequest(resource.TrimStart('/'), method);

            if (!string.IsNullOrWhiteSpace(xfToken))
                request.AddHeader("XF-Api-Key", xfToken);

            request.AddHeader("Accept", "application/json");
            return request;
        }

        protected void AddParameter(RestRequest request, string name, object value)
        {
            if (value == null) return;

            IEnumerable enumerable = value as IEnumerable;

            if (value is string || value is byte[] || enumerable == null)
            {
                request.AddParameter(name, NormalizeParameterValue(value).ToString());
                return;
            }

            string collectionName = name.Contains("[") ? name : name + "[]";
            foreach (object item in enumerable)
            {
                if (item == null) continue;
                request.AddParameter(collectionName, NormalizeParameterValue(item).ToString());
            }
        }

        protected void AddParameters(RestRequest request, IDictionary<string, object> parameters)
        {
            if (parameters == null) return;

            foreach (KeyValuePair<string, object> parameter in parameters)
                AddParameter(request, parameter.Key, parameter.Value);
        }

        protected void AddDictionaryParameters(RestRequest request, string prefix, IDictionary<string, object> parameters)
        {
            if (parameters == null) return;

            foreach (KeyValuePair<string, object> parameter in parameters)
                AddParameter(request, prefix + "[" + parameter.Key + "]", parameter.Value);
        }

        protected void AddJsonParameter(RestRequest request, string name, object value)
        {
            if (value == null) return;
            request.AddParameter(name, JsonConvert.SerializeObject(value));
        }

        protected void AddFile(RestRequest request, string name, byte[] file_bytes, string file_name)
        {
            if (file_bytes == null) return;
            request.AlwaysMultipartFormData = true;
            request.AddFile(name, file_bytes, file_name);
        }

        protected RestResponse Execute(RestRequest request)
        {
            return _client.Execute(request);
        }

        protected T Execute<T>(RestRequest request)
        {
            return Deserialize<T>(Execute(request));
        }

        protected T Deserialize<T>(RestResponse response)
        {
            string content = response.Content;

            if (string.IsNullOrWhiteSpace(content) && response.RawBytes != null && response.RawBytes.Length > 0)
                content = Encoding.UTF8.GetString(response.RawBytes);

            if (string.IsNullOrWhiteSpace(content))
                return default(T);

            return JsonConvert.DeserializeObject<T>(content);
        }

        protected UrlResponse ExecuteUrl(RestRequest request)
        {
            RestResponse response = Execute(request);

            foreach (Parameter header in response.Headers)
            {
                string headerName = header.Name;
                object headerValue = header.Value;

                if (headerName == null || headerValue == null) continue;
                if (!headerName.Equals("Location", StringComparison.OrdinalIgnoreCase)) continue;

                return new UrlResponse { Url = headerValue.ToString() };
            }

            if (response.ResponseUri != null)
                return new UrlResponse { Url = response.ResponseUri.ToString() };

            return Deserialize<UrlResponse>(response);
        }

        object NormalizeParameterValue(object value)
        {
            if (value is bool)
                return ((bool)value) ? "true" : "false";

            if (value is Enum)
                return value.ToString().ToLowerInvariant();

            return value;
        }
    }
}

