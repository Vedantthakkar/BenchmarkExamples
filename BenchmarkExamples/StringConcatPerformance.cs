using BenchmarkDotNet.Attributes;
using BenchmarkLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkExamples
{
    [MemoryDiagnoser]
    public class StringConcatPerformance
    {
        private readonly StringConcatenation strConcat;
        public StringConcatPerformance()
        {
            strConcat = new StringConcatenation();
        }

        [Params(5)]
        public int length;

        private string[]? inputs;

        [GlobalSetup]
        public void Setup()
        {
            inputs = new string[length];
            for (int i = 0; i < length; i++)
            {
                inputs[i] = i.ToString();
            }
        }

        [Benchmark]
        public void StringConcatWithJoin()
        {
            strConcat.StringConcatWithJoin(inputs!);
        }

        [Benchmark]
        public void StringConcatWithStringBuilder()
        {
            strConcat.StringConcatWithStringBuilder(inputs!);
        }

        [Benchmark]
        public void StringConcatWithPlusOperator()
        {
            strConcat.StringConcatWithPlusOperator(inputs!);
        }
    }
}
