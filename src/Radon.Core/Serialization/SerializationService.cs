using Newtonsoft.Json;

namespace Radon.Core.Serialization
{
    public class SerializationService : ISerializationService
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            ContractResolver = new RepresentationResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public T Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value, Settings);

        public string Serialize<T>(T value) => JsonConvert.SerializeObject(value, Settings);
    }
}