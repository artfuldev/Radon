using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;

namespace Radon.Server.Helpers
{
    public static class QueryStringHelper
    {
        public static QueryString SetQueryParameters(this IReadableStringCollection query,
            IDictionary<string, string> values)
        {
            Ensure.ArgumentIsNotNull(query, nameof(query));
            Ensure.ArgumentIsNotNull(values, nameof(values));

            // Add existing and overwrite
            var queryString = query.Keys.Aggregate(new QueryString(), (current, key) => current.Add(key, values.ContainsKey(key) ? values[key] : (string)query[key]));
            // Add new
            queryString = values.Keys.Where(key => !query.ContainsKey(key)).Aggregate(queryString, (current, key) => current.Add(key, values[key]));

            return queryString;
        }
    }
}