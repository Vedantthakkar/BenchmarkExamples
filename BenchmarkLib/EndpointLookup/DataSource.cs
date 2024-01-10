using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib.EndpointLookup
{
    public class DataSource : IDataSource
    {
        public Dictionary<string, string> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
