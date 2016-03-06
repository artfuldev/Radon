namespace Radon.Client.Http
{
    public interface IJsonHttpPipeline
    {
        void SerializeRequest(IRequest request);
        IApiResponse<T> DeserializeResponse<T>(IResponse response);
    }
}