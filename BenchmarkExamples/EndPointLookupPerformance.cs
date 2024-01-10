using BenchmarkDotNet.Attributes;
using BenchmarkLib.EndpointLookup;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkExamples
{
    [MemoryDiagnoser]
    [RankColumn]
    public class EndPointLookupPerformance
    {
        private DictionaryPlusStringManipulation? _dictionaryPlusStringManipulation;
        private ArrayIterationPlusPathBeginsWith? _arrayIterationPlusPathBeginsWith;
        private PathString _path;

        [GlobalSetup]
        public void Setup()
        {
            var routes = CreateRouteMap(MaxRoutes);
            _path = $"/route{MaxRoutes - 1}/some/more/things/in/the/path";

            _dictionaryPlusStringManipulation = new DictionaryPlusStringManipulation(routes);
            _arrayIterationPlusPathBeginsWith = new ArrayIterationPlusPathBeginsWith(routes);
        }


        [Params(10, 100, 1000)] public int MaxRoutes { get; set; }

        [Benchmark]
        public string DictionaryPlusStringManipulation()
        {           
            _dictionaryPlusStringManipulation!.TryGet(_path, out var endpoint);
            return endpoint;
        }

        [Benchmark]
        public string ArrayIterationPlusPathBeginsWith()
        {
            _arrayIterationPlusPathBeginsWith!.TryGet(_path, out var endpoint);
            return endpoint;
        }


        private Dictionary<string, string> CreateRouteMap(int maxRoutes)
          => Enumerable
              .Range(0, maxRoutes)
              .ToDictionary(i => $"route{i}", i => $"route{i}endpoint");

    }
}
