using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib.EndpointLookup
{
    public class ArrayIterationPlusPathBeginsWith : IApiRouteEndpointLookup
    {
        private readonly (string route, string endpoint)[] endpointCollection;

        public ArrayIterationPlusPathBeginsWith(Dictionary<string, string> endpointMap)
        {
            endpointCollection = endpointMap.Select(e => (route: $"/{e.Key}", endpoint: e.Value)).ToArray();
        }

        public bool TryGet(PathString path, out string endpoint)
        {
            foreach (var e in endpointCollection)
            {
                if (path.StartsWithSegments(e.route))
                {
                    endpoint = e.endpoint;
                    return true;
                }
            }

            endpoint = string.Empty;
            return false;
        }
    }
}
