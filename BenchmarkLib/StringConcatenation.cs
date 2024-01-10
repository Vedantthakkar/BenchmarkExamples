using System.Net.Http.Headers;
using System.Text;

namespace BenchmarkLib
{
    public class StringConcatenation
    {
        public string StringConcatWithJoin(string[] input)
        {
            return string.Join(",", input);
        }

        public string StringConcatWithStringBuilder(string[] input)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                str.Append(input[i]);
                str.Append(",");
            }

            return str.ToString().Trim(',');

        }

        public string StringConcatWithPlusOperator(string[] input)
        {
            string str=string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
               str += input[i] + ",";
            }

            return str.ToString().Trim(',');

        }
    }
}
