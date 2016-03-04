using System;
using Radon.Data.Contracts;
using Radon.Data.Queries;

namespace Radon.Data.Repositories.Async
{
    public interface IFluentRepositoryAsync<T>
        : IRepositoryAsync<T>, IAllowFluentQueries<T>
        where T : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
    }

    public interface IFluentRepositoryAsync<T, in TKey>
        : IRepositoryAsync<T, TKey>, IAllowFluentQueries<T>
        where T : ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
