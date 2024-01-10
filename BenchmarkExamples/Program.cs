
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkDemo>();
        }
    }
}



