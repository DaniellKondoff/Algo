using System;

namespace RECURSION
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4 };
            int n = 2;

            GenComb(array, new int[n], 0, 0);
        }

        private static void Draw(int n)
        {
            if (n < 1)
            {
                return;
            }

            Console.WriteLine(new String('*', n));

            Draw(n - 1);

            Console.WriteLine(new String('#', n));

        }

        private static int Sum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            int currentSum = arr[index] + Sum(arr, index + 1);

            return currentSum;
        }

        private static long Factoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            long currentNum = n * Factoriel(n - 1);

            return currentNum;
        }

        private static void GeneratingVector(int index, int[] vector)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    GeneratingVector(index + 1, vector);
                }
            }
        }

        private static void GenComb(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenComb(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}
