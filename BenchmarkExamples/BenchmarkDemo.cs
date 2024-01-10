using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes; // Added missing using statement

namespace BenchmarkExamples
{

    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class BenchmarkDemo
    {

        private static HttpClient _httpClient;
        [GlobalSetup]
        public void GlobalSetup()
        {
            //Write your initialization code here
      

        //     var factory = new WebApplicationFactory<Startup>()
        // .WithWebHostBuilder(configuration =>
        // {
        //     configuration.ConfigureLogging(logging =>
        //     {
        //         logging.ClearProviders();
        //     });
        // });

        //     _httpClient = factory.CreateClient();
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
