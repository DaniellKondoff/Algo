using System;
using System.Collections.Generic;
using System.Linq;

namespace SubSetSum
{
    class Program
    {
        public static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int>();

            result.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                foreach (var number in result.Keys.ToList())
                {
                    var newSum = number + currentNumber;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }
                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            var numbers = new int[] { 3, 5, 1, 4, 2 };
        }
    }
}
