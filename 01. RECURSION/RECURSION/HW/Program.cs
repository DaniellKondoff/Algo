using System;
using System.Linq;

namespace HW
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            string[] arr = new string[k];

            CombinationWithRepetition(n, 0, arr, 1);
        }

        public static void ReverseArray(string[] arr, string[] revArr, int swapIndex)
        {
            if (swapIndex >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", revArr));
                return;
            }

            revArr[swapIndex] = arr[(arr.Length - 1) - swapIndex];
            ReverseArray(arr, revArr, ++swapIndex);
        }

        public static void NestedLoops(int n, string[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i.ToString();
                NestedLoops(n, arr, index + 1);
            }
        }

        public static void CombinationWithRepetition()
        {
            int n = 3;
            int k = 2;

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    Console.WriteLine($"{i} {j}");
                }
            }
        }

        public static void CombinationWithRepetition(int n, int index, string[] arr, int border)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = border; i <= n; i++)
            {
                arr[index] = i.ToString();
                CombinationWithRepetition(n, index + 1, arr, i);
            }
        }
    }
}
