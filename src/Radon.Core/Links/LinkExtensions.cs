using System.Collections.Generic;
using System.Linq;

namespace Radon.Core.Links
{
    public static class LinkExtensions
    {
        public static Link Bind(this Link link, string key, string value)
        {
            return
                new Link(link.Uri.GetResolver().Bind(key, value).ResolveTemplate(),
                    link.RelationType, link.Title, link.Description, link.ContentType, link.Method);
        }

        public static Link Bind(this Link link, string key, IEnumerable<string> values)
        {
            return
                new Link(link.Uri.GetResolver().Bind(key, values).ResolveTemplate(),
                    link.RelationType, link.Title, link.Description, link.ContentType, link.Method);
        }

        public static Link Bind(this Link link, string key, IDictionary<string, string> values)
        {
            return
                new Link(link.Uri.GetResolver().Bind(key, values).ResolveTemplate(),
                    link.RelationType, link.Title, link.Description, link.ContentType, link.Method);
        }

        public static Link Bind(this Link link, IDictionary<string, string> keyValues)
        {
            return keyValues.Aggregate(link, (current, next) => current.Bind(next.Key, next.Value));
        }

        public static Link SetLinkRelationType(this Link link, string linkRelationType)
        {
            return new Link(link.Uri, linkRelationType, link.Title, link.Description, link.ContentType, link.Method);
        }

        public static Link SetMethod(this Link link, string method)
        {
            return new Link(link.Uri, link.RelationType, link.Title, link.Description, link.ContentType, method);
        }
    }
}