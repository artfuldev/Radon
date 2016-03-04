using System.Collections;
using System.Collections.Generic;

namespace Radon.Core.Representations
{
    public interface ICollectionRepresentation : IRepresentation, IEnumerable
    {

    }

    public interface ICollectionRepresentation<out T> : ICollectionRepresentation, IEnumerable<T>
    {
    }
}