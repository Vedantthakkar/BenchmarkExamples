using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkExamples
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net60, baseline:true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class SquareSumPerformance
    {

        private readonly SquareSum _squareSum;
        public SquareSumPerformance()
        {
            _squareSum = new SquareSum();
        }

        private int[,] _square;

        [Params(1000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            int count = 0;
            _square = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _square[i, j] = count++;
                }
            }
        }

        [Benchmark]
        public void Sum()
        {
            _squareSum.Sum(_square);
        }

    }
}
