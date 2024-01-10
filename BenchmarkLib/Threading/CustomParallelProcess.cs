using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib.Threading
{
    public class CustomParallelProcess
    {
        public async Task Process(List<int> messages, int[,] square)
        {
            await ParallelAsyncExtensions.ForEachAsync(messages, 3, async (message) =>
            {
                int sum = 0;

                for (int i = square.GetLowerBound(0); i <= square.GetUpperBound(0); i++)
                {
                    for (int j = square.GetLowerBound(1); j <= square.GetUpperBound(0); j++)
                    {
                        sum += square[i, j];
                    }
                }
            });

        }

    }


    public static class ParallelAsyncExtensions
    {
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int degreeofParallelism, Func<T, Task> body)
        {
            return Task.WhenAll(
               from partition in Partitioner.Create(source).GetPartitions(degreeofParallelism)
               select Task.Run(async () =>
               {
                   using (partition)
                   {
                       while (partition.MoveNext())
                       {
                           await body(partition.Current);
                       }
                   }
               }));
        }
    }
}
