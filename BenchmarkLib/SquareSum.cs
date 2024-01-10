using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkLib
{
    public class SquareSum
    {
        public int Sum(int[,] square)
        {
            int sum = 0;

            for (int i = square.GetLowerBound(0); i <= square.GetUpperBound(0); i++)
            {
                for (int j = square.GetLowerBound(1); j <= square.GetUpperBound(0); j++)
                {
                    sum += square[i, j];
                }
            }
            return sum;

        }
    }
}
