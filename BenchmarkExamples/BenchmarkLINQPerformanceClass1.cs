using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes; // Added missing using statement


namespace BenchmarkExamples
{
    internal class BenchmarkLINQPerformanceClass1
    {
            private readonly List<string>
            data = new List<string>();

            [GlobalSetup]
            public void GlobalSetup()
            {
                for (int i = 65; i < 90; i++)
                {
                    char c = (char)i;
                    data.Add(c.ToString());
                }
            }

            [Benchmark]
            public string Single() => data.SingleOrDefault(x => x.Equals("M"));

            [Benchmark]
            public string First() => data.FirstOrDefault(x => x.Equals("M"));

    }
}
