namespace Radon.Core.Serialization
{
    /// <summary>
    ///     An interface that provides for serialization and deserialization of known types.
    /// </summary>
    public interface ISerializationService
    {
        T Deserialize<T>(string value);
        string Serialize<T>(T value);
    }
}