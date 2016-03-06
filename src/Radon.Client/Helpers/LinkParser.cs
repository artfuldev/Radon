using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Radon.Core.Links;
using Radon.UriTemplates;

namespace Radon.Client.Helpers
{
    public static class LinkParser
    {
        private static readonly Regex LinkRegex =
            new Regex(
                "<(?<UriTemplate>(.+))>;rel=\"(?<RelationType>.*?)\"(;title=\"(?<Title>.*?)\")?(;type=\"(?<ContentType>.*?)\")?(;method=\"(?<Method>.*?)\")?",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static IReadOnlyList<Link> Parse(string input)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(input, nameof(input));

            var links = input.Split(',')
                .Where(headerValue => headerValue.IsLink())
                .Select(ParseSingleLink).ToList();

            return links;
        }

        public static IReadOnlyList<Link> Parse(IEnumerable<string> input)
        {
            Ensure.ArgumentIsNotNull(input, nameof(input));

            var links = input
                .Where(value => value.IsLink())
                .Select(ParseSingleLink).ToList();

            return links;
        }

        private static Link ParseSingleLink(string input)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(input, nameof(input));
            if (!input.IsLink()) return null;

            var match = LinkRegex.Match(input);
            var template = match.Groups["UriTemplate"].ToString();
            var relationType = match.Groups["RelationType"].ToString();
            var title = match.Groups["Title"]?.ToString();
            var contentType = match.Groups["ContentType"]?.ToString();
            var method = match.Groups["Method"]?.ToString();
            var uriTemplate = new UriTemplate(template);
            var link = new Link(uriTemplate, relationType, title, null, contentType, method);
            return link;
        }

        private static bool IsLink(this string input)
        {
            try
            {
                Ensure.ArgumentIsNotNullOrEmptyString(input, nameof(input));
            }
            catch
            {
                return false;
            }
            return LinkRegex.IsMatch(input);
        }
    
}
}