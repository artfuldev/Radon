using System.Net.Http;

namespace Radon.Core
{
    public static class HttpVerb
    {
        public static HttpMethod Patch { get; } = new HttpMethod("PATCH");
    }
}
