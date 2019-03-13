using System;
using System.Linq;
using Sorting.QuickSort;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Quick.Sort(new int[] { 10, 7, 8, 9, 1, 5 });

            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            QuickSortGen.Sort(arr);
        }
    }
}
