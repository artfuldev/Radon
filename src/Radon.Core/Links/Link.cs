using System.Text;
using Radon.UriTemplates;

namespace Radon.Core.Links
{
    public class Link
    {
        public Link(UriTemplate uri, string relationType = LinkRelationTypes.Self, string title = null,
            string description = null, string contentType = null, string method = null)
        {
            Uri = uri;
            RelationType = relationType;
            Title = title;
            Description = description;
            ContentType = contentType;
            Method = method;
        }

        public string Description { get; }
        public string RelationType { get; }
        public string ContentType { get; }
        public string Method { get; }
        public string Title { get; }
        public UriTemplate Uri { get; }
        private string _linkValue;
        public string LinkValue
        {
            get
            {
                if (_linkValue != null) return _linkValue;
                var sb = new StringBuilder();
                sb.Append($"<{Uri}>;rel=\"{RelationType}\"");
                if (!string.IsNullOrWhiteSpace(Title))
                    sb.Append($";title=\"{Title}\"");
                if (!string.IsNullOrWhiteSpace(ContentType))
                    sb.Append($";type=\"{ContentType}\"");
                if (!string.IsNullOrWhiteSpace(Method))
                    sb.Append($";method=\"{Method}\"");
                return (_linkValue = sb.ToString());
            }
        }

        public override string ToString()
        {
            return LinkValue;
        }
    }
}