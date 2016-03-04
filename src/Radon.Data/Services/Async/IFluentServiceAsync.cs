using System;
using Radon.Data.Contracts;
using Radon.Data.Queries;

namespace Radon.Data.Services.Async
{
    public interface IFluentServiceAsync<T>
        : IServiceAsync<T>, IAllowFluentQueries<T>
        where T : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
    }

    public interface IFluentServiceAsync<T, in TKey>
        : IServiceAsync<T, TKey>, IAllowFluentQueries<T>
        where T : ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
