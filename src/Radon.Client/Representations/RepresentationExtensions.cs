using System.Collections.Generic;
using System.Linq;
using Radon.Client.Helpers;
using Radon.Client.Http;
using Radon.Core.Links;
using Radon.Core.Representations;

namespace Radon.Client.Representations
{
    public static class RepresentationExtensions
    {
        public static void DecorateWithLinks(this IRepresentation representation, IResponse response)
        {
            Ensure.ArgumentIsNotNull(representation, nameof(representation));
            Ensure.ArgumentIsNotNull(response, nameof(response));

            representation.DecorateWithLinks(response.ApiInfo.Links);
            var collection = representation as IRepresentationCollection;
            collection?.DecorateWithLinks();
        }

        private static void DecorateWithLinks(this IRepresentation representation, IReadOnlyList<Link> links)
        {
            Ensure.ArgumentIsNotNull(representation, nameof(representation));
            Ensure.ArgumentIsNotNull(links, nameof(links));

            var linkRelationToProperties =
                representation.GetLinkProperties()
                    .Where(x => x.GetLinkRelationType() != null)
                    .ToDictionary(x => x.GetLinkRelationType(), x => x);
            foreach (var link in links.Where(link => linkRelationToProperties.ContainsKey(link.RelationType)))
            {
                linkRelationToProperties[link.RelationType].SetValue(representation, link);
            }
        }

        private static void DecorateWithLinks(this IRepresentationCollection collection)
        {
            Ensure.ArgumentIsNotNull(collection, nameof(collection));

            var embeddedLinksSupporters = collection.OfType<ISupportEmbeddedLinks>();
            foreach (var embeddedLinksSupporter in embeddedLinksSupporters)
            {
                if (embeddedLinksSupporter._links == null || !embeddedLinksSupporter._links.Any())
                    break;
                var representation = embeddedLinksSupporter as IRepresentation;
                if (representation == null)
                    break;
                var links = LinkParser.Parse(embeddedLinksSupporter._links);
                representation.DecorateWithLinks(links);
            }
        }
    }
}