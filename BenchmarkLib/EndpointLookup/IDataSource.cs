using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib.EndpointLookup
{
    public interface IDataSource
    {
        public Dictionary<string, string> GetData();

    }
}
