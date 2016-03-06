using Radon.Core.Representations;

namespace Radon.Server.Resources
{
    public interface IResourceCollection : ICollectionRepresentation
    {

    }

    public interface IResourceCollection<T> : IResourceCollection where T : IResource
    {
        
    }
}