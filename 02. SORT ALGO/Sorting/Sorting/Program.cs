using System;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Quick.Sort(new int[] { 10, 7, 8, 9, 1, 5 });
            //Quick.Sort(new int[] { 1, 2, 3, 6, 5, 4 });

            //var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //QuickSortGen.Sort(arr);

            //Console.WriteLine(BinarySearch.IndexOf(new int[] { -1, 0, 1, 2, 4 }, 2));
            //Console.WriteLine(BinarySearch.IndexOf(new int[] { 1,2,3,4,5 }, 1));
            //Console.WriteLine(BinarySearch.IndexOf(new int[] { -1, 0, 1, 2, 4 }, 2, 0, 5));
            //Console.WriteLine(BinarySearch.IndexOf(new int[] { 1, 2, 3, 4, 5 }, 1, 0, 5));

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Sort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));

        }

        private static void Sort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(arr, start, end);

            Sort(arr, start, pivot - 1);
            Sort(arr, pivot + 1, end);
        }

        static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];

            int i = (start - 1);
            for (int j = start; j < end; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    Swap(i, j, arr);
                }
            }

            Swap(i + 1, end, arr);

            return i + 1;
        }

        private static void Swap(int firstIndex, int secondIndex, int[] arr)
        {
            int temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}
