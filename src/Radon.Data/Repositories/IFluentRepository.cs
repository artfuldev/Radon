using System;
using Radon.Data.Contracts;
using Radon.Data.Queries;

namespace Radon.Data.Repositories
{
    public interface IFluentRepository<T>
        : IRepository<T>, IAllowFluentQueries<T>
        where T : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
    }

    public interface IFluentRepository<T, in TKey>
        : IRepository<T, TKey>, IAllowFluentQueries<T>
        where T : ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
