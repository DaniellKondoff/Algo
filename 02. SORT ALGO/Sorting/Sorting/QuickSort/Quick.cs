using System;

namespace Sorting.QuickSort
{
    public class Quick
    {
        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length -1); 
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

        //private static int Partition(int[] arr, int start, int end)
        //{
        //    int i = start + 1;
        //    int pivot = arr[i];

        //    for (int j = start+1; j <= end; j++)
        //    {
        //        if (arr[j] < pivot)
        //        {
        //            Swap(i, j, arr);

        //            i += 1;
        //        }
        //    }

        //    Swap(start, i - 1, arr);

        //    return i - 1;
        //}

        static int Partition(int[] arr, int start,
                                   int end)
        {
            int pivot = arr[end];

            // index of smaller element 
            int i = (start - 1);
            for (int j = start; j < end; j++)
            {
                // If current element is smaller  
                // than or equal to pivot 
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    Swap(i, j, arr);
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
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
