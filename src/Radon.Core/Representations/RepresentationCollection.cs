using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Radon.Core.Links;
using Radon.Core.Serialization;

namespace Radon.Core.Representations
{
    public class RepresentationCollection<T> : ReadOnlyCollection<T>, IRepresentationCollection<T>, ISupportLinks, IHaveSelfLink where T : IRepresentation
    {
        public RepresentationCollection(IEnumerable<T> list) : this(list.ToList())
        {
        }

        private RepresentationCollection(IList<T> list) : base(list)
        {
        }
        
        [LinkRelationType(LinkRelationTypes.First)]
        public Link FirstLink { get; set; }
        [LinkRelationType(LinkRelationTypes.Last)]
        public Link LastLink { get; set; }
        uint IRepresentationCollection.Count => Convert.ToUInt32(Count);
        public IReadOnlyList<Link> Links => this.GetLinks();
        [LinkRelationType(LinkRelationTypes.Self)]
        public Link SelfLink { get; set; }
    }
}