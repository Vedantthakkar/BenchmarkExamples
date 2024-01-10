using Microsoft.AspNetCore.Http;

namespace BenchmarkLib.EndpointLookup
{
    public interface IApiRouteEndpointLookup
    {
        bool TryGet(PathString path, out string endpoint);
    }
}
