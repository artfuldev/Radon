namespace Radon.Data.Contracts
{
    /// <summary>
    /// Indicates that this is convertible from a <seealso cref="TSource"/> object.
    /// </summary>
    /// <typeparam name="TSource">The type from which this is convertible.</typeparam>
    public interface IConvertible<in TSource>
    {
        void InitializeFrom(TSource source);
    }
}