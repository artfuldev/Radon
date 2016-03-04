using System;
using Radon.Data.Contracts;
using Radon.Data.Queries;

namespace Radon.Data.Services
{
    public interface IFluentService<T>
        : IService<T>, IAllowFluentQueries<T>
        where T : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
    }

    public interface IFluentService<T, in TKey>
        : IService<T, TKey>, IAllowFluentQueries<T>
        where T : ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
