using System.Collections.Generic;
using Radon.Core.Links;
using Radon.Core.Serialization;

namespace Radon.Core.Representations
{
    public abstract class Representation : IRepresentation, ISupportLinks, ISupportEmbeddedLinks
    {
        public IReadOnlyList<Link> Links => this.GetLinks();
        public IEnumerable<string> _links { get; set; }
    }
}