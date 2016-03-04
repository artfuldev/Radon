using System;
using System.Collections.Generic;
using System.Reflection;
using Humanizer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Radon.Core.Links;

namespace Radon.Core.Serialization
{
    internal class RepresentationResolver : DefaultContractResolver
    {
        private static readonly List<Type> IgnoredTypes = new List<Type> {typeof (Link), typeof (IReadOnlyList<Link>)};
        protected override string ResolvePropertyName(string propertyName) => propertyName.Underscore();

        private JsonProperty CreatePropertyWithIgnoreRule(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (member.GetCustomAttribute<SerializeIgnoreAttribute>() != null)
                property.ShouldSerialize = instance => false;
            return property;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = CreatePropertyWithIgnoreRule(member, memberSerialization);
            if (IgnoredTypes.Contains(property.PropertyType))
                property.ShouldSerialize = instance => false;
            return property;
        }
    }
}