using BenchmarkDotNet.Attributes;
using BenchmarkLib.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkExamples
{
    [ThreadingDiagnoser]
    [MemoryDiagnoser]
    [SimpleJob(iterationCount: 5, warmupCount: 5)]
    public class ThreadingPerformance
    {
        private readonly SequenceProcess sequenceProcess;
        private readonly CustomParallelProcess customParallelProcess;
        public ThreadingPerformance()
        {
            sequenceProcess = new SequenceProcess();
            customParallelProcess = new CustomParallelProcess();
        }

        [Params(10)]
        public int messageCount;

        public List<int> messages;

        [Params(50, 100, 1000)]
        public int Size { get; set; }

        private int[,] _square;

        [GlobalSetup]
        public void Setup()
        {
            messages = new List<int>();
            for (int i = 0; i < messageCount; i++)
            {
                messages.Add(i);
            }

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
        public async Task SequenceProcess()
        {
            await sequenceProcess.Process(messages, _square);
        }


        [Benchmark]
        public void CustomParallelProcess()
        {
            Task.WaitAll(customParallelProcess.Process(messages, _square));
        }



    }
}
