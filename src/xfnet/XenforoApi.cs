using System;
using xfnet.Routes;

namespace xfnet
{
    public class XenforoApi
    {
        public readonly string XfToken;
        public readonly bool IsVerbose;
        public readonly string BaseUrl;

        public Alerts Alerts { get; private set; }
        public Attachments Attachments { get; private set; }
        public Auth Auth { get; private set; }
        public ConversationMessages ConversationMessages { get; private set; }
        public Conversations Conversations { get; private set; }
        public Featured Featured { get; private set; }
        public Forums Forums { get; private set; }
        public Index Index { get; private set; }
        public Me Me { get; private set; }
        public Nodes Nodes { get; private set; }
        public OAuth2 OAuth2 { get; private set; }
        public OEmbed OEmbed { get; private set; }
        public Posts Posts { get; private set; }
        public ProfilePostComments ProfilePostComments { get; private set; }
        public ProfilePosts ProfilePosts { get; private set; }
        public Search Search { get; private set; }
        public SearchForums SearchForums { get; private set; }
        public Stats Stats { get; private set; }
        public Threads Threads { get; private set; }
        public Users Users { get; private set; }

        public XenforoApi(string xfToken, bool isVerbose, string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("Base URL cannot be empty.", "baseUrl");

            XfToken = xfToken ?? string.Empty;
            IsVerbose = isVerbose;
            BaseUrl = NormalizeBaseUrl(baseUrl);

            Alerts = new Alerts(XfToken, IsVerbose, BaseUrl);
            Attachments = new Attachments(XfToken, IsVerbose, BaseUrl);
            Auth = new Auth(XfToken, IsVerbose, BaseUrl);
            ConversationMessages = new ConversationMessages(XfToken, IsVerbose, BaseUrl);
            Conversations = new Conversations(XfToken, IsVerbose, BaseUrl);
            Featured = new Featured(XfToken, IsVerbose, BaseUrl);
            Forums = new Forums(XfToken, IsVerbose, BaseUrl);
            Index = new Index(XfToken, IsVerbose, BaseUrl);
            Me = new Me(XfToken, IsVerbose, BaseUrl);
            Nodes = new Nodes(XfToken, IsVerbose, BaseUrl);
            OAuth2 = new OAuth2(XfToken, IsVerbose, BaseUrl);
            OEmbed = new OEmbed(XfToken, IsVerbose, BaseUrl);
            Posts = new Posts(XfToken, IsVerbose, BaseUrl);
            ProfilePostComments = new ProfilePostComments(XfToken, IsVerbose, BaseUrl);
            ProfilePosts = new ProfilePosts(XfToken, IsVerbose, BaseUrl);
            Search = new Search(XfToken, IsVerbose, BaseUrl);
            SearchForums = new SearchForums(XfToken, IsVerbose, BaseUrl);
            Stats = new Stats(XfToken, IsVerbose, BaseUrl);
            Threads = new Threads(XfToken, IsVerbose, BaseUrl);
            Users = new Users(XfToken, IsVerbose, BaseUrl);
        }

        public XenforoApi(string xfToken, string baseUrl, bool isVerbose = false) : this(xfToken, isVerbose, baseUrl) { }

        string NormalizeBaseUrl(string baseUrl)
        {
            string normalizedBaseUrl = baseUrl.Trim();

            if (normalizedBaseUrl.EndsWith("/api/", StringComparison.OrdinalIgnoreCase))
                return normalizedBaseUrl;

            if (normalizedBaseUrl.EndsWith("/api", StringComparison.OrdinalIgnoreCase))
                return normalizedBaseUrl + "/";

            if (!normalizedBaseUrl.EndsWith("/"))
                normalizedBaseUrl += "/";

            return normalizedBaseUrl + "api/";
        }
    }
}
