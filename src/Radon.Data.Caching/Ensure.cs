using System;
using Radon.Data.Caching.Infrastructure;

namespace Radon.Data.Caching
{
    /// <summary>
    ///   Ensure input parameters
    /// </summary>
    internal static class Ensure
    {
        /// <summary>
        /// Checks an argument to ensure it isn't null.
        /// </summary>
        /// <param name = "value">The argument value to check</param>
        /// <param name = "name">The name of the argument</param>
        public static void ArgumentIsNotNull([ValidatedNotNull]object value, string name)
        {
            if (value != null) return;

            throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Checks a string argument to ensure it isn't null or empty.
        /// </summary>
        /// <param name = "value">The argument value to check</param>
        /// <param name = "name">The name of the argument</param>
        public static void ArgumentIsNotNullOrEmptyString([ValidatedNotNull]string value, string name)
        {
            ArgumentIsNotNull(value, name);
            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("String cannot be empty", name);
        }

        /// <summary>
        /// Checks a timespan argument to ensure it is a positive value.
        /// </summary>
        /// <param name = "value">The argument value to check</param>
        /// <param name = "name">The name of the argument</param>
        public static void IsGreaterThanZero([ValidatedNotNull]TimeSpan value, string name)
        {
            ArgumentIsNotNull(value, name);

            if (value.TotalMilliseconds > 0) return;

            throw new ArgumentException("Timespan must be greater than zero", name);
        }

        public static void CacheKeysAreNotEqual(CacheKey a, CacheKey b, string message = null)
        {
            if (a.CompareTo(b) == 0)
                throw new Exception(message ?? "Cache Keys cannot be equal");
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}