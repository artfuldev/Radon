namespace Radon.Data.Contracts
{
    /// <summary>
    /// Indicates that this is a converter that converts a <seealso cref="TSource"/> object to a 
    /// <seealso cref="TDestination"/> object.
    /// </summary>
    /// <typeparam name="TSource">The source type of the conversion.</typeparam>
    /// <typeparam name="TDestination">The destination type of the conversion.</typeparam>
    public interface IConverter<in TSource,TDestination>
    {
        TDestination Convert(TSource source);
        bool TryConvert(TSource source, out TDestination result);
    }
}