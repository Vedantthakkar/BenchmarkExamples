
using BenchmarkDotNet.Running;

namespace BenchmarkExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
           // var summary = BenchmarkRunner.Run<StringConcatPerformance>();

           //var summary = BenchmarkRunner.Run<EndPointLookupPerformance>();

           // var summary = BenchmarkRunner.Run<EndpointLookupwithMockPerformance>();    

           //var summary = BenchmarkRunner.Run<SquareSumPerformance>();           
       
           // var summary = BenchmarkRunner.Run<ThreadingPerformance>();     

            var summary = BenchmarkRunner.Run<PercentileExample>();                           
        }
    }
}

