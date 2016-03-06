using System;
using System.Linq;
using Radon.Core.Links;

namespace Radon.Client.Http
{
    public static class ApiInfoExtensions
    {
        public static Uri GetNextPageUrl(this ApiInfo info)
        {
            Ensure.ArgumentIsNotNull(info, "info");
            var link = info.Links.FirstOrDefault(x => x.RelationType == LinkRelationTypes.Next);
            return link == null ? null : new Uri(link.Uri.ToString(), UriKind.RelativeOrAbsolute);
        }
    }
}
