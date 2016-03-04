using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Radon.Core.Annotations;
using Radon.Core.Links;

namespace Radon.Core.Representations
{
    public static class RepresentationExtensions
    {
        public static string GetMediaType(this IRepresentation representation)
        {
            return representation.GetType().GetMediaType();
        }

        public static string GetMediaType(this Type type)
        {
            if (!(typeof(IRepresentation).IsAssignableFrom(type)))
                throw new TypeAccessException();
            var mediaTypeAttribute = type.GetTypeInfo().GetCustomAttribute<MediaTypeAttribute>();
            return mediaTypeAttribute == null ? $"application/vnd.{type.FullName}+json" : mediaTypeAttribute.MediaType;
        }

        public static IEnumerable<PropertyInfo> GetLinkProperties(this IRepresentation representation)
        {
            return representation.GetType()
                .GetProperties()
                .Where(x => typeof (Link).IsAssignableFrom(x.PropertyType));
        } 

        public static IReadOnlyList<Link> GetLinks(this IRepresentation representation)
        {
            return representation.GetLinkProperties()
                .Where(x => x.GetValue(representation) != null)
                .Select(x => x.GetValue(representation))
                .Cast<Link>()
                .ToList();
        }
    }
}