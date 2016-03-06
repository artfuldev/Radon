using System;
using Radon.Data;

namespace Radon.Server.Resources
{
    public interface IResource : IEntity
    {

    }

    public interface IResource<out TKey> : IResource, IEntity<TKey> where TKey : IComparable
    {
        
    }
}