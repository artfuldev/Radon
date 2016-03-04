using System;

namespace Radon.Core.Links
{
    public sealed class LinkRelationTypeAttribute : Attribute
    {
        public LinkRelationTypeAttribute(string linkRelationType)
        {
            LinkRelationType = linkRelationType;
        }

        public string LinkRelationType { get; }
    }
}