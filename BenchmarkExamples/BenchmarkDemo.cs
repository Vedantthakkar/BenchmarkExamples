using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkExamples
{

    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class MyBenchmarkDemo
    {

        private static HttpClient _httpClient;
        [GlobalSetup]
        public void GlobalSetup()
        {
            //Write your initialization code here
      
        }

        [Benchmark]
        public void MyFirstBenchmarkMethod()
        {
            //Write your code here   
        }
        [Benchmark]
        public void MySecondBenchmarkMethod()
        {
            //Write your code here
        }
    }

}
