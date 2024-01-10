using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib.EndpointLookup
{
    public class DictionaryPlusStringManipulation : IApiRouteEndpointLookup
    {
        private readonly Dictionary<string, string> endpointMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public DictionaryPlusStringManipulation(Dictionary<string, string> endpointMap)
        {
            this.endpointMap = endpointMap;
        }

        public bool TryGet(PathString path, out string endpoint)
        {
            endpoint = string.Empty;

            if (path.HasValue)
            {
                var pathString = path.Value;
                var basePathEnd = pathString.Substring(1, pathString.Length - 1).IndexOf('/');
                var basePath = pathString.Substring(1, basePathEnd > 0 ? basePathEnd : pathString.Length - 1);
                return endpointMap.TryGetValue(basePath, out endpoint!);
            }
            return false;

        }
    }

}
