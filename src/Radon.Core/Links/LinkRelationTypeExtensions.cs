using System;
using System.Reflection;

namespace Radon.Core.Links
{
    public static class LinkRelationTypeExtensions
    {
        public static string GetLinkRelationType(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType != typeof(Link))
                throw new NotSupportedException();
            return propertyInfo.GetCustomAttribute<LinkRelationTypeAttribute>()?.LinkRelationType;
        }
    }
}