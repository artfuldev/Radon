using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radon.Client.Helpers
{
    /// <summary>
    /// Reflects a collection of data returned from an API that can be paged.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadOnlyPagedCollection<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// Returns the next page of items.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyPagedCollection<T>> GetNextPage();
    }
}
