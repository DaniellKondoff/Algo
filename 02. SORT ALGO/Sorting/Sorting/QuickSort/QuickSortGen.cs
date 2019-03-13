using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting.QuickSort
{
    public class QuickSortGen
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Sort<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(arr, start, end);

            Sort(arr, start, pivot - 1);
            Sort(arr, pivot + 1, end);
        }

        static int Partition<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            T pivot = arr[end];

            int i = (start - 1);
            for (int j = start; j < end; j++)
            {
                if (arr[j].CompareTo(pivot) <= 0)
                {
                    i++;

                    Swap(i, j, arr);
                }
            }

            Swap(i + 1, end, arr);

            return i + 1;
        }

        private static void Swap<T>(int firstIndex, int secondIndex, T[] arr) where T : IComparable<T>
        {
            T temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}
