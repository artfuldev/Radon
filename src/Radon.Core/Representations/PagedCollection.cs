using System.Collections.Generic;
using Radon.Core.Links;
using Radon.Core.Serialization;

namespace Radon.Core.Representations
{
    public abstract class PagedCollection<T> : RepresentationCollection<T>, IPagedCollection<T> where T : IRepresentation
    {
        protected PagedCollection(IEnumerable<T> list) : base(list)
        {
        }
        [LinkRelationType(LinkRelationTypes.Next)]
        public Link NextLink { get; set; }
        [LinkRelationType(LinkRelationTypes.Previous)]
        public Link PreviousLink { get; set; }
        [SerializeIgnore]
        public uint Page { get; set; }
        [SerializeIgnore]
        public uint PerPage { get; set; }
        [SerializeIgnore]
        public uint TotalCount { get; set; }
    }
}