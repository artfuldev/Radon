using Radon.Core.Links;

namespace Radon.Core.Representations
{
    public interface IPagedCollection : IRepresentationCollection
    {
        Link NextLink { get; set; }
        Link PreviousLink { get; set; }
        uint Page { get; set; }
        uint PerPage { get; set; }
        uint TotalCount { get; set; }
    }

    public interface IPagedCollection<out T> : IPagedCollection, IRepresentationCollection<T>
        where T : IRepresentation
    {

    }
}