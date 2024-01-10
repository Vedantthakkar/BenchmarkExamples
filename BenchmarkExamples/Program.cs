
using BenchmarkDotNet.Running;

namespace BenchmarkExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SquareSumPerformance>();
            Console.ReadLine();
        }
    }
}

