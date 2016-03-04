namespace Radon.Core.Serialization
{
    public interface ISerializationService
    {
        T Deserialize<T>(string value);
        string Serialize<T>(T value);
    }
}