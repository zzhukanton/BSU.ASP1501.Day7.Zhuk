using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class FibonacciSequence
    {
        public static IEnumerable<int> GetSequence(int number)
        {
            if (number < 1)
                throw new ArgumentException("Number is less than 1");

            yield return 0;

            if (number == 1)
                yield break;
            yield return 1;

            if (number == 2)
                yield break;

            int first = 0, second = 1;
            for (int i = 0; i < number; i++)
            {
                int temp = first + second;
                first = second;
                second = temp;
                yield return second;
            }

            yield break;
        }
    }
}
