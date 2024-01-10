using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes; // Added missing using statement

namespace BenchmarkLib.EndpointLookup
{
    public interface IDataSource
    {
        public Dictionary<string, string> GetData();

    }
}
