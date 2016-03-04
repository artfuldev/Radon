using Radon.Data;

namespace Radon.Core.Representations
{
    public interface IRepresentation : IDataTransferObject
    {
    }

    public interface IRepresentation<T> : IRepresentation
    {
    }
}