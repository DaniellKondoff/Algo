using System;
using System.Linq;
using Sorting.QuickSort;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Quick.Sort(new int[] { 10, 7, 8, 9, 1, 5 });
            //Quick.Sort(new int[] { 1, 2, 3, 6, 5, 4 });

            //var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //QuickSortGen.Sort(arr);

            Console.WriteLine(BinarySearch.IndexOf(new int[] { -1, 0, 1, 2, 4 }, 2));
            Console.WriteLine(BinarySearch.IndexOf(new int[] { 1,2,3,4,5 }, 1));
            Console.WriteLine(BinarySearch.IndexOf(new int[] { -1, 0, 1, 2, 4 }, 2, 0, 5));
            Console.WriteLine(BinarySearch.IndexOf(new int[] { 1, 2, 3, 4, 5 }, 1, 0, 5));
        }
    }
}
