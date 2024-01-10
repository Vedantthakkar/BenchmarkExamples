using BenchmarkDotNet.Attributes;
using BenchmarkLib.EndpointLookup;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkExamples
{
    [MemoryDiagnoser]
    public class EndpointLookupwithMockPerformance
    {
        private DictionaryPlusStringManipulationWithIO? _dictionaryPlusStringManipulation;
        private Mock<IDataSource> mockDataSource;
        private PathString _path;

        [GlobalSetup]
        public void Setup()
        {
            var routes = CreateRouteMap(MaxRoutes);
            _path = $"/route{MaxRoutes - 1}/some/more/things/in/the/path";

            mockDataSource = new Mock<IDataSource>();
            mockDataSource.Setup(x => x.GetData()).Returns(routes);
            _dictionaryPlusStringManipulation = new DictionaryPlusStringManipulationWithIO(mockDataSource.Object);
           
        }


        [Params(10)] public int MaxRoutes { get; set; }

        [Benchmark]
        public string DictionaryPlusStringManipulationWithIoOperation()
        {
            _dictionaryPlusStringManipulation!.TryGet(_path, out var endpoint);
            return endpoint;
        }


        private Dictionary<string, string> CreateRouteMap(int maxRoutes)
          => Enumerable
              .Range(0, maxRoutes)
              .ToDictionary(i => $"route{i}", i => $"route{i}endpoint");
    }
}
