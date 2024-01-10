using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes; // Added missing using statement

namespace BenchmarkExamples
{

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkStringBuilderPerformance
    {
        const string message = "Some text for testing purposes only.";
        const int CTR = 10000;

        [Benchmark]
        public void WithoutStringBuilderCache()
        {
            for (int i = 0; i < CTR; i++)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(message);
            }
        }

        [Benchmark]
        public void WithStringBuilderCache()
        {
            // for (int i = 0; i < CTR; i++)
            // {
            //     var stringBuilder = StringBuilderCache.Acquire();
            //     stringBuilder.Append(message);
            //     _ = StringBuilderCache.GetStringAndRelease(stringBuilder);
            // }
        }
    }
}
