using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib.Threading
{
    public class SequenceProcess
    {
        public async Task Process(List<int> messages, int[,] square)
        {
            for (int k = 0; k < messages.Count; k++)
            {
                int sum = 0;

                for (int i = square.GetLowerBound(0); i <= square.GetUpperBound(0); i++)
                {
                    for (int j = square.GetLowerBound(1); j <= square.GetUpperBound(0); j++)
                    {
                        sum += square[i, j];
                    }
                }
            }
        }
    }
}
