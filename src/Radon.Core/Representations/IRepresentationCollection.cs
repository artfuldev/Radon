using Radon.Core.Links;

namespace Radon.Core.Representations
{
    public interface IRepresentationCollection : ICollectionRepresentation, ISupportLinks, IHaveSelfLink
    {
        Link FirstLink { get; set; }
        Link LastLink { get; set; }
        uint Count { get; }
    }

    public interface IRepresentationCollection<out T> : IRepresentationCollection, ICollectionRepresentation<T>
        where T : IRepresentation
    {
    }
}